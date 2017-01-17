using System;

namespace prmToolkit.DateTimeExtension
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Obter o primeiro segundo de dateTime  
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Obter o último segundo de dateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        /// <summary>
        ///Obter o primeiro dia do mês do dateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Obter o último dia do mês do dateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            int numberOfDays = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, numberOfDays);
        }

        /// <summary>
        ///Obter primeiro dia da semana dateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime dateTime)
        {
            DateTime firstDayInWeek = dateTime.Date;

            while (firstDayInWeek.DayOfWeek != DayOfWeek.Monday)
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            return firstDayInWeek.StartOfDay();
        }

        /// <summary>
        /// Obter o último dia da semana dateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(this DateTime dateTime)
        {
            DateTime lastDayInWeek = dateTime.Date;

            while (lastDayInWeek.DayOfWeek != DayOfWeek.Sunday)
                lastDayInWeek = lastDayInWeek.AddDays(1);
            return lastDayInWeek.StartOfDay();
        }

        /// <summary>
        /// Obter o último segundo do último dia do mês dateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfLastDayOfMonth(this DateTime dateTime)
        {
            int numberOfDays = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, numberOfDays, 23, 59, 59);
        }

        /// <summary>
        /// Verifique se a data está dentro de um período
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="startDate">Min date</param>
        /// <param name="endDate">Max date</param>
        /// <returns></returns>
        public static bool IsInPeriod(this DateTime dateTime, DateTime startDate, DateTime endDate)
        {
            if (dateTime >= startDate && dateTime <= endDate)
                return true;
            return false;
        }

        /// <summary>
        /// Verifique se a data está fora de um período
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="startDate">Min date</param>
        /// <param name="endDate">Max date</param>
        /// <returns></returns>
        public static bool IsOutOfPeriod(this DateTime dateTime, DateTime startDate, DateTime endDate)
        {
            if (dateTime < startDate || dateTime > endDate)
                return true;
            return false;
        }

    }
}
