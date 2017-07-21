using System.Linq;
using Bodget.Data;
using Bodget.Logic;
using Bodget.Model;
using Bodget.Windows;
using System;
using System.IO;
using System.Windows.Forms;
using Libod.ReflectionEx;

namespace Bodget
{
        static class Program
        {


                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                [STAThread]
                static void Main ()
                {
                        /*
                         * Do data migration
                         */
                        //DB4O.Migration<Bodget.Category, Bodget.Model.Category> (BaseMng<IBase>.DB_PATH, BaseMng2<IBase>.DB_PATH);
                        //DB4O.Migration<Bodget.Operation, Bodget.Model.Operation> (BaseMng<IBase>.DB_PATH, BaseMng2<IBase>.DB_PATH);

                        test ();

                        createObjectsPropertiesHeaders ();

                        Application.EnableVisualStyles ();
                        Application.SetCompatibleTextRenderingDefault (false);
                        Application.Run (new FrmMain ());

                        //Application.Run (new FrmCategorization ());
                        //Application.Run (new FrmCategorizationAuto (null));
                        //Application.Run (new FrmImExport (ImExport.ActionType.Import));
                        //Application.Run (new FrmBaseCRUD<Cheque> (new Cheque ()));
                        //Application.Run (new FrmChequeList ());
                        //Application.Run (new FrmBaseGrid<Cheque> ());

                }

                static void test ()
                {
                        try
                        {
                                if (!Directory.Exists (DB4O.DB_FOLDER))
                                {
                                        Directory.CreateDirectory (DB4O.DB_FOLDER);
                                }
                                //BaseMng<Compte>.DB_PATH
                        }
                        catch (Exception ex)
                        {
                                MessageBox.Show (ex.GetBaseException ().Message);
                        }
                }

                static void createObjectsPropertiesHeaders ()
                {
                        //BaseMng<PropertyHeader>.Instance.DeleteAll ();
                        new Operation ().CreatePropertiesHeaders ();
                        new Cheque ().CreatePropertiesHeaders ();
                }
        }
}
