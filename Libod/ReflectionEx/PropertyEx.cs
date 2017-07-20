using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Libod.Attribute;
using Libod.Model;

//using Libod.ClassExtension.IQueryableEx;

namespace Libod.ReflectionEx
{
        public static class PropertyEx
        {
                public static PropertyInfo GetPropertyInfo (this object obj, string propName)
                {
                        return obj.GetType ().GetProperties ().First (p => p.Name == propName);
                }

                public static List<PropertyTypeName> GetPropertyTypeName (this object o)
                {
                        return o.GetType ().GetProperties ().Select (x => new PropertyTypeName
                        {
                                Type = x.PropertyType,
                                Name = x.Name
                        }).ToList ();
                }

                public static List<PropertyTypeNameAttribute> GetPropertyTypeNameAttribute (this object o)
                {
                        return o.GetType ().GetProperties ().Select (x => new PropertyTypeNameAttribute
                        {
                                Type = x.PropertyType,
                                Name = x.Name,
                                PropertyHeader = x.GetCustomAttribute<PropertyHeader> (),
                                ForeignKey = x.GetCustomAttribute<ForeignKey> ()
                        }).ToList ();
                }

                public static List<PropertyTypeNameValue> GetPropertyTypeNameValue (this object o)
                {
                        return o.GetType ().GetProperties ().Select (x => new PropertyTypeNameValue
                        {
                                Type = x.PropertyType,
                                Name = x.Name,
                                Value = x.GetValue (o)
                        }).ToList ();
                }

                public static List<PropertyTypeNameValueAttribute> GetPropertyTypeNameValueAttribute (this IBase o)
                {
                        return o.GetType ().GetProperties ().Select (x => new PropertyTypeNameValueAttribute
                        {
                                Type = x.PropertyType,
                                Name = x.Name,
                                Value = x.GetValue (o),
                                PropertyHeader = x.GetCustomAttribute<PropertyHeader> (),
                                ForeignKey = x.GetCustomAttribute<ForeignKey> ()
                        }).ToList ();
                }
                public static void SetPropertyValue (this object target, string propName, object value)
                {
                        var propInfo = target.GetType ().GetProperty (propName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

                        if (propInfo == null)
                        {
                                throw new ArgumentOutOfRangeException ("propName", "Property not found on target");
                        }
                        propInfo.SetValue (target, value, null);
                }

                public static List<Tret> SelectByPropertyName<Tsrc, Tret> (this List<Tsrc> o, string propertyName)
                {
                        var prop = typeof (Tsrc).GetProperties ().First (p => p.Name == propertyName);
                        var getter = (Func<Tsrc, Tret>)Delegate.CreateDelegate (
                                    typeof (Func<Tsrc, Tret>), prop.GetGetMethod ());
                        return o.Select (getter).ToList ();

                        //foreach (var property in typeof (Tsrc).GetProperties ().Where (p => p.Name == propertyName))
                        //{
                        //        if (property.PropertyType != typeof (Tret))
                        //                continue;

                        //        var getter = (Func<Tsrc, Tret>)Delegate.CreateDelegate (
                        //            typeof (Func<Tsrc, Tret>), property.GetGetMethod ());
                        //        output.Add (o.Select (getter).ToList ());
                        //}
                }

                /// <summary>
                /// see : https://www.codeproject.com/Articles/18450/HyperDescriptor-Accelerated-dynamic-property-acces
                /// to increase performance
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="o"></param>
                /// <param name="propertyName"></param>
                /// <param name="propertyValue"></param>
                /// <returns></returns>
                public static List<T> Where<T> (this List<T> o, string propertyName, object propertyValue)
                {
                        return o.AsQueryable<T> ().Where (propertyName, propertyValue, WhereOperation.Contains).ToList ();
                }

                public enum WhereOperation { Equal, NotEqual, Contains }

                private static IQueryable<T> Where<T> (this IQueryable<T> query, string propertyName, object propertyValue, WhereOperation operation)
                {
                        if (string.IsNullOrEmpty (propertyName))
                                return query;

                        ParameterExpression parameter = Expression.Parameter (query.ElementType, "p");

                        MemberExpression memberAccess = null;
                        foreach (var property in propertyName.Split ('.'))
                                memberAccess = MemberExpression.Property
                                   (memberAccess ?? (parameter as Expression), property);

                        //change param value type
                        //necessary to getting bool from string
                        ConstantExpression filter = Expression.Constant
                            (
                                Convert.ChangeType (propertyValue, memberAccess.Type)
                            );

                        //switch operation
                        Expression condition = null;
                        LambdaExpression lambda = null;

                        if (operation == WhereOperation.Contains && memberAccess.Type != typeof (String))
                        {
                                operation = WhereOperation.Equal;
                        }
                        switch (operation)
                        {
                                //equal ==
                                case WhereOperation.Equal:
                                        condition = Expression.Equal (memberAccess, filter);
                                        lambda = Expression.Lambda (condition, parameter);
                                        break;
                                //not equal !=
                                case WhereOperation.NotEqual:
                                        condition = Expression.NotEqual (memberAccess, filter);
                                        lambda = Expression.Lambda (condition, parameter);
                                        break;
                                //string.Contains()
                                case WhereOperation.Contains:
                                        condition = Expression.Call (memberAccess,
                                            typeof (string).GetMethod ("Contains"),
                                            Expression.Constant (propertyValue));
                                        lambda = Expression.Lambda (condition, parameter);
                                        break;
                        }


                        MethodCallExpression result = Expression.Call (
                               typeof (Queryable), "Where",
                               new[] { query.ElementType },
                               query.Expression,
                               lambda);

                        return query.Provider.CreateQuery<T> (result);
                }


        }
}
