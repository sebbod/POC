using System.IO;
using System.Linq.Expressions;
using Bodget.Model;
using Db4objects.Db4o;
using Libod;
using Libod.Ctrl;
using Libod.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Libod.ReflectionEx;
using Microsoft.VisualBasic.CompilerServices;

namespace Bodget.Data
{
        public sealed class BaseMng<T>
                where T: IBase
        {
                /// <summary>
                /// object 4 instance locker and instance of Base T
                /// </summary>
                private static readonly Dictionary<object, BaseMng<T>> _dInstance = new Dictionary<object, BaseMng<T>> ();

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
                private BaseMng () { }

                public static BaseMng<T> Instance
                {
                        get
                        {
                                lock (type)
                                {
                                        if (!_dInstance.ContainsKey (type))
                                        {

                                                _dInstance.Add (type, new BaseMng<T> ());
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
                                                _all = container.Query<T> ().ToList ();
                                        }
                                }
                                return _all;
                        }
                }

                //public IEnumerable<ctrlItem<T>> ComboItems ()
                //{
                //        foreach (T i in _all)
                //        {
                //                yield return new ctrlItem<T> { id = i.id, Text = i.nom, Value = i };
                //        }
                //}

                //public IEnumerable<ctrlItem<ICtrlItem>> ComboCtrlItems ()
                //{
                //        foreach (T i in _all)
                //        {
                //                yield return new ctrlItem<ICtrlItem> { id = i.id, 
                //                                                Text = i.nom, 
                //                                                Value = new CtrlItem { id = i.id, nom = i.nom } };
                //        }
                //}

                public void ConsoleListResult ()
                {
                        Console.WriteLine (All.Count ());
                        foreach (T item in All)
                        {
                                Console.WriteLine (item.ToString ());
                        }
                }

                public T Get (long id)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                return Get (container, id);
                        }
                }

                private T Get (IObjectContainer container, long id)
                {
                        return container.Query<T> ().FirstOrDefault (x => x.id == id);
                }

                //public bool Exist (long id)
                //{
                //        using (IObjectContainer container = Db4oFactory.OpenFile (DB4O.DB_PATH))
                //        {
                //                return (Get (container, id) != null);
                //        }
                //}

                public bool Exist (T item)
                {
                        return (Get (item.id) != null);
                }

                /// <summary>
                ///  transactionné
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
                /// <param name="container"></param>
                /// <param name="item"></param>
                /// <param name="all"></param>
                public void Insert (IObjectContainer container, T item)
                {
                        if (_all == null)
                        {
                                throw new ArgumentNullException ();
                        }

                        if (item.id == 0)
                        {
                                // pas d'id
                                long nextId = 1;
                                if(_all.Count > 0)
                                {
                                        //nextId = _all.OrderBy (o => o.id).Last().id;
                                        nextId = _all.Last ().id;       // more quickly
                                }
                                item.id = nextId + 1;
                        }
                        else
                        {
                                // id spécifié
                                if (_all.Any (x => x.id == item.id))
                                {
                                        throw new ArgumentException ("PK constraint : id [" + item.id + "] already exist");
                                        //return; // il ne faut pas insérer cette ligne (operation) elle est déjà dans la base
                                }
                        }

                        // vérifier si existe déja
                        if (_all.Contains (item))
                        {
                                throw new OperationCanceledException ("Insert::Already exist in DB!");
                        }

                        // enregistre en base
                        container.Store (item);

                        // ajoute à la liste memory cache
                        _all.Add (item);
                }

                public void Update (T item, string propName, object value)
                {
                        Action<T> act = (o) =>
                        {
                                var pi = item.GetPropertyInfo (propName);
                                pi.SetValue (o, value);
                        };
                        Update (item, act);
                }

                public void Update (IEnumerable<T> items, Action<T> updAction)
                {
                        foreach (T i in items)
                        {
                                Update (i.id, updAction);
                        }
                }

                public void Update (T item, Action<T> updAction)
                {
                        Update (item.id, updAction);    // update dans la base
                        updAction (item);               // update l'instance de l'objet en mémoire
                }


                //public void SetPropertyValue<T> (Expression<Func<T, Object>> memberLamda, object value)
                //{
                //        MemberExpression memberSelectorExpression;
                //        var selectorExpression = memberLamda.Body;
                //        var castExpression = selectorExpression as UnaryExpression;

                //        if (castExpression != null)
                //                memberSelectorExpression = castExpression.Operand as MemberExpression;
                //        else
                //                memberSelectorExpression = memberLamda.Body as MemberExpression;

                //        // How do I get the value of myCustomerInstance so that I can invoke SetValue passing it in as a param? Is it possible

                //}

                private void Update (long id, Action<T> updAction)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                var o = Get (container, id);
                                if (o != null)
                                {
                                        updAction (o);
                                        if (o.id != id)
                                        {
                                                throw new ArgumentException ("PK constraint : you can't update id value");
                                        }
                                        container.Store (o);
                                        _all = null;    // 4 refresh
                                }
                        }
                }



                /// <summary>
                /// Move the Category with idFirst to idTwo and 
                /// the Category with idTwo to idFirst
                /// useful because the id is used to set order
                /// </summary>
                /// <param name="idFirst"></param>
                /// <param name="idTwo"></param>
                public bool Move (long idFirst, long idTwo)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                var o1 = Get (container, idFirst);
                                var o2 = Get (container, idTwo);
                                if (o1 == null || o2 == null)
                                {
                                        // si on ne trouve pas en base un des deux objets alors on ne fait rien
                                        return false;
                                }
                                o1.id = idTwo;
                                o2.id = idFirst;
                                try
                                {
                                        container.Store (o1);
                                        container.Store (o2);
                                        container.Commit ();
                                        _all = null;    // 4 refresh
                                }
                                catch
                                {
                                        container.Rollback ();
                                        return false;
                                }
                                return true;
                        }
                }

                public void Delete (IEnumerable<T> items)
                {
                        foreach (T i in items)
                        {
                                Delete (i.id);
                        }
                }

                public void Delete (T item)
                {
                        Delete (item.id);
                }

                public void Delete (long id)
                {
                        using (IObjectContainer container = Db4oFactory.OpenFile (DB_PATH))
                        {
                                var o = Get (container, id);
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
