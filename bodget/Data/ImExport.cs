using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Bodget.Logic;
using Bodget.Model;
using Db4objects.Db4o;
using Libod;
using Libod.Ctrl;
using OFXSharp;

namespace Bodget.Data
{
        public class ImExport
        {
                public enum ActionType
                {
                        Import = 1,
                        Export = 2,
                }

                public static void FromBankFileOFX (string filePath, bool categoryAuto = true)
                {
                        // error log file
                        StreamWriter sw = new StreamWriter (Path.ChangeExtension (filePath, "log"));

                        var opMng = BaseMng<Operation>.Instance;

                        //opMng.DeleteAll ();

                        /*
                         * Attention le parser ne parse pas les fichiers contenant plusieurs compte (= more than one account header failed)
                         */
                        var parser = new OFXDocumentParser ();
                        var ofxDocument = parser.Import (new FileStream (filePath, FileMode.Open));

                        // création automatique d'un nouveau compte (si besoin)
                        var compte = BaseMng<Compte>.Instance.All.FirstOrDefault (c => c.code == ofxDocument.Account.AccountID);
                        if (compte == null)
                        {
                                compte = new Compte ().CreateWithDefaultValue (ofxDocument.Account.AccountID, ofxDocument.Account.BankAccountType.ToString (), ofxDocument.Account.BankID);
                        }
                        long idCompte = compte.id;
                        long idBeneficiare = compte.Beneficiares ().First ().id;  // par defaut on prend le premier bénéficiare lié au compte

                        // creation d'une liste avec toutes les opérations à importer
                        List<Operation> opLst = new List<Operation> ();
                        try
                        {
                                foreach (var t in ofxDocument.Transactions)
                                {
                                        Operation op = new Operation ();
                                        op.id = t.TransactionID.ToInt64 ();
                                        op.idCompte = idCompte;
                                        op.idBeneficiare = idBeneficiare;
                                        op.dt = t.Date;
                                        op.mt = t.Amount;
                                        op.type = t.Memo;
                                        op.nom = t.Name;
                                        if (categoryAuto)
                                        {
                                                op.idCategory = op.CategoryIdFromRules ();
                                        }
                                        else
                                        {
                                                op.idCategory = 1;
                                        }
                                        opLst.Add (op);
                                }
                        }
                        catch (Exception ex)
                        {
                                sw.WriteLine (ex.Message);
                        }
                        
                        // enregistrement en base transactionné (all or nothing)
                        try
                        {
                                opMng.Insert (opLst);
                        }
                        catch (Exception ex)
                        {
                                sw.WriteLine (ex.Message);
                        }

                        sw.Close ();
                }

                /// <summary>
                /// Import
                /// </summary>
                /// <param name="filePath"></param>
                /// <param name="type"></param>
                public static void FromFile (string filePath, Type type)
                {

                        Action (ActionType.Import, filePath, type);

                }

                /// <summary>
                /// Export
                /// </summary>
                /// <param name="filePath"></param>
                /// <param name="type"></param>
                public static void ToFile (string filePath, Type type)
                {
                        Action (ActionType.Export, filePath, type);
                }

                private static void Action (ActionType actionType, string filePath, Type type)
                {
                        string DB_PATH = null;

                        if (type.GetInterface ("IBase") != null)
                        {
                                DB_PATH = DB4O.BaseMngDB_PATH (type);
                        }
                        if (type.GetInterface ("IBaseHas") != null)
                        {
                                DB_PATH = DB4O.BaseHasMngDB_PATH (type);

                        }
                        if (DB_PATH != null)
                        {
                                switch (actionType)
                                {
                                        case ActionType.Import:
                                                DB4O.Migration (type, filePath, DB_PATH);
                                                break;
                                        case ActionType.Export:
                                                DB4O.Migration (type, DB_PATH, filePath);
                                                break;
                                }
                        }
                        else
                        {
                                throw new ArgumentNullException ();
                        }
                }

                public static IEnumerable<ctrlItem<dbObjectInfo>> GetTypeExportable ()
                {
                        Type[] typelist = Assembly.GetExecutingAssembly ().GetTypesInNamespace ("Bodget.Model");
                        foreach (Type t in typelist)
                        {
                                if (t.GetInterface ("IBase") != null)
                                {
                                        //Console.WriteLine (t.Name);
                                        yield return new ctrlItem<dbObjectInfo> { Text = t.Name, Value = new dbObjectInfo (t) };
                                }
                        }
                }
        }
}
