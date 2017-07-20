using System;
using System.Globalization;
using System.Threading;

namespace Libod
{


    public static class DecimalEx
    {
        public static bool isNullOrZero(this Decimal? val)
        {
            return val == null || val == 0;
        }


        //private const string formatAffichageChiffreCA = "{0:0,0}";  // avec separateur de milier 
        private const string formatAffichageChiffreCA = "{0:#,0}";  // avec separateur de milier évite le 00 ou 01 ou 05
        private const string formatAffichageChiffreVolume = "{0:0}";

        public static String Format(this Decimal? val, bool isCAtype)
        {
            if (val == null) return null;
            return val.Value.Format(isCAtype);
        }
        public static String Format(this Decimal val, bool isCAtype)
        {
            if (isCAtype) return string.Format(formatAffichageChiffreCA, val);
            return string.Format(formatAffichageChiffreVolume, val);
        }


        public static Decimal? ArrondiALEntierSuperieur(this Decimal? val)
        {
            if (val == null) return null;
            return val.Value.ArrondiALEntierSuperieur();
        }
        public static Decimal ArrondiALEntierSuperieur(this Decimal val)
        {
            //return ((long)val + 1);
            return Math.Ceiling(val);
        }


        public static Decimal? ArrondiALEntierLePlusProche(this Decimal? val)
        {
            if (val == null) return null;
            return val.Value.ArrondiALEntierLePlusProche();
        }
        public static Decimal ArrondiALEntierLePlusProche(this Decimal val)
        {
            return Math.Round(val, 0);
        }


        public static Decimal? ArrondiALEntierInferieur(this Decimal? val)
        {
            if (val == null) return null;
            return val.Value.ArrondiALEntierInferieur();
        }
        public static Decimal ArrondiALEntierInferieur(this Decimal val)
        {
            //return (long)val;
            return Math.Floor(val);
        }


    }
}
