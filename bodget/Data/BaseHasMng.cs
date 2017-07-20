using System.IO;
using Db4objects.Db4o;
using Libod.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bodget.Data
{
        public sealed class BaseHasMng<T>
                where T: IBaseHas
        {
                /// <summary>
                /// object 4 instance locker and instance of Base T
                /// </summary>
                private static readonly Dictionary<object, BaseHasMng<T>> _dInstance = new Dictionary<object, BaseHasMng<T>> ();

                /// <summary>
                /// 4 the lock/type
                /// </summary>
                private static Type type
                {
                        get
                        {
                                return typeof (T);
                        }
                }

                public static string DB_PATH
                {
                        get
                        {
                                return Path.Combine (DB4O.DB_FOLDER, type.Name);
                        }
                }

                /// <summary>
                /// Very important => Make the default constructor private, so that nothing can directly create it.
                /// </summary>
                private BaseHasMng () { }

                public static BaseHasMng<T> Instance
                {
                        get
                        {
                                lock (type)
                                {
                                        if (!_dInstance.ContainsKey (type))
                                        {

                                                _dInstance.Add (type, new BaseHasMng<T> ());
                                        }
                                }
                                return _dInstance[type];
                        }
                }

                public reT UsingIObjectContainer<reT> (Func<IObjectContainer, reT> f)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                return f (container);
                        }
                }

                private List<T> _all;
                public IList<T> All
                {
                        get
                        {
                                if (_all == null)
                                {
                                        //_all = UsingIObjectContainer (c => c.Query<T> ().ToList ());
                                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                                        {
                                                _all = new List<T> ();
                                                foreach (T o in container.Query<T> ())
                                                {
                                                        o.id = container.Ext ().GetObjectInfo (o).GetInternalID ();
                                                        _all.Add (o);
                                                }
                                                // replace \/ \/ by /\ /\
                                                //_all = container.Query<T> ().ToList ();
                                        }
                                }
                                return _all;
                        }
                }


                public void ConsoleListResult ()
                {
                        Console.WriteLine (All.Count ());
                        foreach (T item in All)
                        {
                                Console.WriteLine (item.ToString ());
                        }
                }

                public T Get (long id1, long id2)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                return Get (container, id1, id2);
                        }
                }

                private T Get (IObjectContainer container, long id1, long id2)
                {
                        var o = container.Query<T> ().FirstOrDefault (x => x.id1 == id1 && x.id2 == id2);
                        if (o != null)
                        {
                                o.id = container.Ext ().GetObjectInfo (o).GetInternalID ();
                        }
                        return o;
                }

                public bool Exist (long id1, long id2)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                return (Get (container, id1, id2) != null);
                        }
                }

                /// <summary>
                /// transactionné
                /// </summary>
                /// <param name="items"></param>
                public void Insert (IEnumerable<T> items)
                {
                        _all = All.ToList ();   // must do before \/ because open the file too and create a DatabaseFileLockedException
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                try
                                {
                                        foreach (T i in items)
                                        {
                                                Insert (container, i);
                                        }
                                        container.Commit ();
                                }
                                catch (Exception ex)
                                {
                                        container.Rollback ();
                                        throw ex;
                                }
                        }
                }

                /// <summary>
                /// l'id est incrémenté automatiquement si non renseigné
                /// </summary>
                /// <param name="item"></param>
                public void Insert (T item)
                {
                        _all = All.ToList ();   // must do before \/ because open the file too and create a DatabaseFileLockedException
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                Insert (container, item);
                        }
                }

                /// <summary>
                /// l'id est incrémenté automatiquement si non renseigné
                /// </summary>
                /// <param name="item"></param>
                public void Insert (IObjectContainer container, T item)
                {
                        if (_all == null)
                        {
                                throw new ArgumentNullException ();
                        }

                        if (item.id1 == 0 && item.id2 == 0)
                        {
                                // pas d'id
                                throw new NotImplementedException ("you must specifie id1 and id2");
                        }

                        // id spécifié
                        if (_all.Any (x => x.id1 == item.id1 && x.id2 == item.id2))
                        {
                                throw new ArgumentException ("PK constraint : id1 [" + item.id1 + "] && id2 [" + item.id2 + "] already exist");
                        }

                        // vérifier si existe déja
                        if (_all.Contains (item))
                        {
                                throw new OperationCanceledException ("Insert::Already exist in DB!");
                        }

                        // enregistre en base
                        container.Store (item);

                        // retrouve l'id DB4O
                        item.id = container.Ext ().GetObjectInfo (item).GetInternalID ();

                        // ajoute à la liste memory cache
                        _all.Add (item);
                }

                public void Update (IEnumerable<T> items, Action<T> updAction)
                {
                        foreach (T i in items)
                        {
                                Update (i.id1, i.id2, updAction);
                        }
                }

                public void Update (T item, Action<T> updAction)
                {
                        Update (item.id1, item.id2, updAction);         // update dans la base
                        updAction (item);                               // update l'instance de l'objet en mémoire
                }

                private void Update (long id1, long id2, Action<T> updAction)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                var o = Get (container, id1, id2);
                                if (o != null)
                                {
                                        updAction (o);
                                        if (o.id1 != id1 && o.id2 != id2)
                                        {
                                                throw new ArgumentException ("PK constraint : you can't update id value");
                                        }
                                        container.Store (o);
                                        _all = null;    // 4 refresh
                                }
                        }
                }



                public void Delete (IEnumerable<T> items)
                {
                        foreach (T i in items)
                        {
                                Delete (i.id1, i.id2);
                        }
                }

                public void Delete (T item)
                {
                        Delete (item.id1, item.id2);
                }

                public void Delete (long id1, long id2)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                var o = Get (container, id1, id2);
                                if (o != null)
                                {
                                        container.Delete (o);
                                        _all = null;    // 4 refresh
                                }
                        }
                }

                public void DeleteAll ()
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                IObjectSet lst = container.QueryByExample (typeof (T));
                                foreach (var item in lst)
                                {
                                        container.Delete (item);
                                }
                                _all = null;    // 4 refresh
                        }
                }


        }
}
