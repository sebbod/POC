//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Db4objects.Db4o;
//using Db4objects.Db4o.Linq;
//using Db4objects.Db4o.Query;
//using Db4objects.Db4o.Reflect.Generic;

//namespace Bodget.Data
//{
//        public sealed class BaseMng<T>
//                where T: IBase
//        {
//                public static string DB_PATH = "DB4O.db";

//                /// <summary>
//                /// object 4 instance locker and instance of Base T
//                /// </summary>
//                private static readonly Dictionary<object, BaseMng<T>> _dInstance = new Dictionary<object, BaseMng<T>> ();

//                /// <summary>
//                /// 4 the lock/type
//                /// </summary>
//                private static Type type
//                {
//                        get
//                        {
//                                return typeof (T);
//                        }
//                }

//                /// <summary>
//                /// Very important => Make the default constructor private, so that nothing can directly create it.
//                /// </summary>
//                private BaseMng () { }

//                public static BaseMng<T> Instance
//                {
//                        get
//                        {
//                                lock (type)
//                                {
//                                        if (!_dInstance.ContainsKey (type))
//                                        {

//                                                _dInstance.Add (type, new BaseMng<T> ());
//                                        }
//                                }
//                                return _dInstance[type];
//                        }
//                }

//                public reT UsingIObjectContainer<reT> (Func<IObjectContainer, reT> f)
//                {
//                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                        {
//                                return f (container);
//                        }
//                }

//                private List<T> _all;
//                public IList<T> All
//                {
//                        get
//                        {
//                                if (_all == null)
//                                {
//                                        _all = UsingIObjectContainer (c => c.Query<T> ().ToList ());
//                                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                                        {
//                                                _all = container.Query<T> ().ToList ();
//                                        }
//                                }
//                                return _all;
//                        }
//                }

//                public IList<T> Select (Func<IList<T>, IList<T>> updAction)
//                {
//                        return updAction (All);
//                }


//                public void ConsoleListResult ()
//                {
//                        Console.WriteLine (All.Count ());
//                        foreach (T item in All)
//                        {
//                                Console.WriteLine (item.ToString ());
//                        }
//                }

//                public void Insert (IEnumerable<T> items)
//                {
//                        foreach (T i in items)
//                        {
//                                Insert (i);
//                        }
//                }

//                public void Insert (T item)
//                {
//                        if (item.id == 0)
//                        {
//                                // pas d'id
//                                if (All != null)
//                                {
//                                        item.id = All.Count + 1;
//                                }
//                                else
//                                {
//                                        item.id = 1;
//                                }
//                        }
//                        else
//                        {
//                                // id spécifié
//                                if (All != null && All.Any (x => x.id == item.id))
//                                {
//                                        throw new ArgumentException ("PK constraint : id [" + item.id + "] already exist");
//                                }
//                        }
//                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                        {
//                                container.Store (item);
//                                _all = null;    // 4 refresh
//                        }
//                }

//                public void Update (IEnumerable<T> items, Action<T> updAction)
//                {
//                        foreach (T i in items)
//                        {
//                                Update (i.id, updAction);
//                        }
//                }

//                public void Update (T item, Action<T> updAction)
//                {
//                        Update (item.id, updAction);
//                }

//                public void Update (long id, Action<T> updAction)
//                {
//                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                        {
//                                var o = container.Query<T> ().FirstOrDefault (x => x.id == id);
//                                if (o != null)
//                                {
//                                        updAction (o);
//                                        if (o.id != id)
//                                        {
//                                                throw new ArgumentException ("PK constraint : you can't update id value");
//                                        }
//                                        container.Store (o);
//                                        _all = null;    // 4 refresh
//                                }
//                        }
//                }

//                /// <summary>
//                /// Move the Category with idFirst to idTwo and 
//                /// the Category with idTwo to idFirst
//                /// useful because the id is used to set order
//                /// </summary>
//                /// <param name="idFirst"></param>
//                /// <param name="idTwo"></param>
//                public bool Move (long idFirst, long idTwo)
//                {
//                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                        {
//                                var o1 = container.Query<T> ().FirstOrDefault (x => x.id == idFirst);
//                                var o2 = container.Query<T> ().FirstOrDefault (x => x.id == idTwo);
//                                if (o1 == null || o2 == null)
//                                {
//                                        // si on ne trouve pas en base un des deux objets alors on ne fait rien
//                                        return false;
//                                }
//                                o1.id = idTwo;
//                                o2.id = idFirst;
//                                try
//                                {
//                                        container.Store (o1);
//                                        container.Store (o2);
//                                        container.Commit ();
//                                        _all = null;    // 4 refresh
//                                }
//                                catch
//                                {
//                                        container.Rollback ();
//                                        return false;
//                                }
//                                return true;
//                        }
//                }

//                public void Delete (IEnumerable<T> items)
//                {
//                        foreach (T i in items)
//                        {
//                                Delete (i.id);
//                        }
//                }

//                public void Delete (T item)
//                {
//                        Delete (item.id);
//                }

//                public void Delete (long id)
//                {
//                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                        {
//                                var o = container.Query<T> ().FirstOrDefault (x => x.id == id);
//                                if (o != null)
//                                {
//                                        container.Delete (o);
//                                        _all = null;    // 4 refresh
//                                }
//                        }
//                }

//                public void DeleteAll ()
//                {
//                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
//                        {
//                                IObjectSet lst = container.QueryByExample (typeof (T));
//                                foreach (var item in lst)
//                                {
//                                        container.Delete (item);
//                                }
//                                _all = null;    // 4 refresh
//                        }
//                }


//        }
//}
