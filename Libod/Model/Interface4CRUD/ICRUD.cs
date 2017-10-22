
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libod.Ctrl;

namespace Libod.Model
{
        public interface ICRUD<T> //where T : IBase, INom
        {
                List<IpropertyCRUD<T>> propertiesCRUD   /**/{ get; }

                string  /**/ frmTitle                   /**/{ get; }
                string  /**/ lblLstObjet                /**/{ get; }
                string  /**/ ObjectName                 /**/{ get; }

                T       /**/ Object                     /**/{ get; }
                //IEnumerable<ctrlItem<T>> ComboItems ();

                void    /**/ CreateObject               /**/(Panel parentPanel);
                void    /**/ Insert ();
                void    /**/ Update ();
                void    /**/ Delete ();
        }
}
