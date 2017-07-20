//using System;
//using System.Globalization;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Threading;
//using Libod.ReflectionEx;

//namespace Libod
//{
//        public static class ExpressionEx
//        {
//                /*
//                var testdata = EntityRepository.Get<Ownr>().ToList();
//                System.Linq.Expressions.Expression<Func<Ownr, bool>> func = Extentions.strToFunc<Ownr>("OWNR_START_DT", "<=", "2013-10-30");
//                func = Extentions.strToFunc<Ownr>("OWNR_NM", "==", "OwnerSystem1", func);
//                var result = testdata.Where(func.ExpressionToFunc()).ToList();
//                 * */
//                public static Expression<Func<T, bool>> strToFunc<T> (this T obj, string propName, string opr, object value, Expression<Func<T, bool>> expr = null)
//                {
//                        Expression<Func<T, bool>> func = null;
//                        try
//                        {
//                                var prop = obj.GetPropertyInfo (propName);
//                                ParameterExpression tpe = Expression.Parameter (typeof (T));
//                                Expression left = Expression.Property (tpe, prop);
//                                Expression right = Expression.Convert (ToExprConstant (prop, value), prop.PropertyType);
//                                Expression<Func<T, bool>> innerExpr = Expression.Lambda<Func<T, bool>> (ApplyFilter (opr, left, right), tpe);
//                                if (expr != null)
//                                {
//                                        innerExpr = innerExpr.And (expr);
//                                }
//                                func = innerExpr;
//                        }
//                        catch { }
//                        return func;
//                }


//                private static Expression ToExprConstant (PropertyInfo prop, object value)
//                {
//                        object val;
//                        switch (prop.PropertyType.FullName)
//                        {
//                                case "System.Guid":
//                                        throw new NotImplementedException ();
//                                //val = value.ToGuid ();
//                                //break;
//                                default:
//                                        val = Convert.ChangeType (value, Type.GetType (prop.PropertyType.FullName));
//                                        break;
//                        }
//                        return Expression.Constant (val);
//                }

//                private static BinaryExpression ApplyFilter (string opr, Expression left, Expression right)
//                {
//                        BinaryExpression InnerLambda = null;
//                        switch (opr)
//                        {
//                                case "==":
//                                case "=":
//                                        InnerLambda = Expression.Equal (left, right);
//                                        break;
//                                case "<":
//                                        InnerLambda = Expression.LessThan (left, right);
//                                        break;
//                                case ">":
//                                        InnerLambda = Expression.GreaterThan (left, right);
//                                        break;
//                                case ">=":
//                                        InnerLambda = Expression.GreaterThanOrEqual (left, right);
//                                        break;
//                                case "<=":
//                                        InnerLambda = Expression.LessThanOrEqual (left, right);
//                                        break;
//                                case "!=":
//                                        InnerLambda = Expression.NotEqual (left, right);
//                                        break;
//                                case "&&":
//                                        InnerLambda = Expression.And (left, right);
//                                        break;
//                                case "||":
//                                        InnerLambda = Expression.Or (left, right);
//                                        break;
//                        }
//                        return InnerLambda;
//                }

//                public static Expression<Func<T, TResult>> And<T, TResult> (this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
//                {
//                        var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
//                        return Expression.Lambda<Func<T, TResult>> (Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
//                }
                
//                public static Func<T, TResult> ExpressionToFunc<T, TResult> (this Expression<Func<T, TResult>> expr)
//                {
//                        return expr.Compile ();
//                }






//        }
//}
