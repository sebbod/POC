using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Reflect.Generic;
using Libod.Ctrl;
using Libod.ReflectionEx;

namespace Bodget.Data
{
        public static class DB4O
        {
                public static string DB_FOLDER = "DB4O\\";

                public static string BaseMngDB_PATH (Type type)
                {
                        Type BaseMngOfType = typeof (BaseMng<>).MakeGenericType (type);
                        PropertyInfo pi = BaseMngOfType.GetProperty ("DB_PATH");
                        return (string) pi.GetValue( null);
                }

                public static string BaseHasMngDB_PATH (Type type)
                {
                        Type BaseHasMngOfType = typeof (BaseHasMng<>).MakeGenericType (type);
                        PropertyInfo pi = BaseHasMngOfType.GetProperty ("DB_PATH");
                        return (string)pi.GetValue (null);
                }

                public static dynamic CreateInstanceOfBaseMng (Type type)
                {
                        return Activator.CreateInstance (typeof (BaseMng<>).MakeGenericType (type), true);
                }

                public static dynamic CreateInstanceOfBaseHasMng (Type type)
                {
                        return Activator.CreateInstance (typeof (BaseHasMng<>).MakeGenericType (type), true);
                }

                public static void read_db (string db)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (db))
                        {
                                IQuery query = container.Query ();
                                IEnumerable allObjects = query.Execute ();

                                foreach (Object item in allObjects)
                                {
                                        GenericObject dbObject = (GenericObject)item; // Note: If db4o finds actuall class, it will be the right class, otherwise GenericObject. You may need to do some checks and casts
                                        dbObject.GetGenericClass ().GetDeclaredFields (); // Find out fields
                                        object fieldData = dbObject.Get (0); // Get the field at index 0. The GetDeclaredFields() tells you which field is at which index
                                }
                        }
                }

                public static object GetValue (object o, string PropertyName)
                {
                        return o.GetType ().GetProperty (PropertyName).GetValue (o, null);
                }

                public static void SetValue (object o, string PropertyName, object value)
                {
                        o.GetType ().GetProperty (PropertyName).SetValue (o, value);
                }

                public static void Migration<T1, T2> (string db1, string db2)
                        where T2: new ()
                {
                        using (IObjectContainer c1 = Db4oFactory.OpenFile (db1))
                        {
                                using (IObjectContainer c2 = Db4oFactory.OpenFile (db2))
                                {
                                        foreach (T1 o1 in c1.Query<T1> ())
                                        {
                                                T2 o2 = new T2 ();
                                                var commonProp = o1.GetPropertyTypeName ().Intersect (o2.GetPropertyTypeName ());
                                                foreach (var pi in commonProp)
                                                {
                                                        SetValue (o2, pi.Name, GetValue (o1, pi.Name));
                                                }
                                                c2.Store (o2);
                                        }
                                }
                        }
                }

                /// <summary>
                /// copy d'un fichier db4o vers un autre fichier db4o
                /// </summary>
                /// <param name="type"></param>
                /// <param name="db1"></param>
                /// <param name="db2"></param>
                public static void Migration (Type type, string db1, string db2)
                {
                        System.IO.FileInfo fi1 = new System.IO.FileInfo (db1);
                        System.IO.FileInfo fi2 = new System.IO.FileInfo (db2);
                        if (fi1.FullName == fi2.FullName)
                        {
                                throw new Exception ("File already exist here : " + Environment.NewLine + db2);
                        }
                        using (IObjectContainer c1 = Db4oFactory.OpenFile (db1))
                        {
                                using (IObjectContainer c2 = Db4oFactory.OpenFile (db2))
                                {
                                        foreach (var o1 in c1.Query (type))
                                        {
                                                c2.Store (o1);
                                        }
                                }
                        }
                }
        }
}
