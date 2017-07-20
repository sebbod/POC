using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Libod
{
    public static class DateTimeEx
    {
        public static string MoisEnTouteLettre(this DateTime model)
        {
            return DateTime.ParseExact(model.Month.ToString() + "/" + model.Year.ToString(), "M/yyyy", null).ToString("MMMM");
        }

        public static DateTime ToFirstDayOfMonth(this DateTime model)
        {
            return new DateTime(model.Year, model.Month, 1);
        }

        public static DateTime ToLastDayOfMonth(this DateTime model)
        {
            //return model.AddMonths(1).AddDays(-1);  // ce code ne fonctionne que si nous somme le 1er du mois
            // il faut en fait faire un ToFirstDayOfMonth avant d'ajouter un mois
            return new DateTime(model.Year, model.Month, 1).AddMonths(1).AddDays(-1);
        }

        public static DateTime ToLastDayOfPreviousMonth(this DateTime model)
        {
            return model.ToFirstDayOfMonth().AddDays(-1);
        }

        public static DateTime MinDate(this DateTime model, DateTime autre)
        {
            return model < autre ? model : autre;
        }

        public static DateTime MaxDate(this DateTime model, DateTime autre)
        {
            return model > autre ? model : autre;
        }

        public static int GetWeekNumber(this DateTime dt)
        {
            var cal = DateTimeFormatInfo.CurrentInfo.Calendar;
            //var ms = cal.GetWeekOfYear(new DateTime(dt.Year, dt.Month, 1), CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            return cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static String ToSqlDateSansHeure(this DateTime valeur)
        {
            StringBuilder sb = new StringBuilder(40);
            sb.Append("TO_DATE('");
            sb.Append(valeur.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            sb.Append("', 'DD/MM/YYYY')");
            return sb.ToString();
        }


        /// <summary>
        /// Renvoie le 1er dimanche du mois sauf si le 1er du mois est un dimanche
        /// Donc si le 1er est un dimanche, alors renvoie le dimanche d'après
        /// </summary>
        public static DateTime premierDimancheApresPremierJourDuMois(this DateTime dt)
        {
            DateTime premierDimancheDuMois = dt.ToFirstDayOfMonth();

            // si le premier jour du mois est un dimanche on retourne le 2nd dimanche du mois
            if (premierDimancheDuMois.DayOfWeek == DayOfWeek.Sunday)
            {
                return premierDimancheDuMois.AddDays(7);
            }

            while (premierDimancheDuMois.DayOfWeek != DayOfWeek.Sunday)
            {
                premierDimancheDuMois = premierDimancheDuMois.AddDays(1);
            }
            return premierDimancheDuMois;

        }
       
    }
}
