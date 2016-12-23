using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace prmToolkit.Notification
{
    public static class AddNotification
    {
        /// <summary>
        /// Se são iguais levanta exceção
        /// </summary>
        public static void IfEquals(object object1, object object2, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (object1.Equals(object2))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se não são iguais levanta exceção
        /// </summary>
        public static void IfNotEquals(object object1, object object2, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (!object1.Equals(object2))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se o valor passado for verdadeiro, levanta exceção
        /// </summary>
        public static void IfTrue(bool boolValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (boolValue)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se for falso levanta exceção
        /// </summary>
        public static void IfFalse(bool boolValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (boolValue == false)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se passar do comprimento máximo levanta exceção
        /// </summary>
        public static void IfLength(string stringValue, int maximum, string message, [CallerMemberName] string callerMemberName = "")
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
            {

                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se não atender o valor mínimo e máximo levanta exceção
        /// </summary>
        public static void IfLength(string stringValue, int minimum, int maximum, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se a expressão regular não for válida levanta exceção
        /// </summary>
        public static void IfNotMatches(string pattern, string stringValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(stringValue) == false)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se for nulo levanta exceção
        /// </summary>
        public static void IfNull(string stringValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (stringValue == null)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se for nulo levanta exceção
        /// </summary>
        public static void IfNull(object objectValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (objectValue == null)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se não for nulo levanta exceção
        /// </summary>
        public static void IfNotNull(object object1, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (object1 != null)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se for nulo ou vazio, levanta exceção
        /// </summary>
        public static void IfNullOrEmpty(string stringValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se é vazio levanta exceção
        /// </summary>
        public static void IfEmpty(string stringValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (stringValue == null || stringValue.Trim().Length <= 0)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static void IfNotRange(double value, double minimum, double maximum, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (value < minimum || value > maximum)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

            
        }

        /// <summary>
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static void IfNotRange(float value, float minimum, float maximum, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (value < minimum || value > maximum)
            {

                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

            
        }

        /// <summary>
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static void IfNotRange(int value, int minimum, int maximum, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (value < minimum || value > maximum)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

           
        }

        /// <summary>
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static void IfNotRange(long value, long minimum, long maximum, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (value < minimum || value > maximum)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

            
        }

        /// <summary>
        /// Se não for um email válido levanta exceção
        /// </summary>
        public static void IfNotEmail(string email, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

            
        }

        /// <summary>
        /// Se o primeiro valor não for maior que o segundo levanta exceção
        /// </summary>
        public static void IfNotGreaterThan(int value1, int value2, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (!(value1 > value2))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se o primeiro valor não for maior que o segundo levanta exceção
        /// </summary>
        public static void IfNotGreaterThan(decimal value1, decimal value2, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (!(value1 > value2))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se o primeiro valor não for maior ou igual que o segundo levanta exceção
        /// </summary>
        public static void IfNotGreaterOrEqualThan(int value1, int value2, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (!(value1 >= value2))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
        }

        /// <summary>
        /// Se não for uma url válida, levanta uma exceção.
        /// </summary>
        public static void IfNotUrl(string url, string message, [CallerMemberName] string callerMemberName = "")
        {
            // Do not validate if no URL is provided
            // You can call AssertNotEmpty before this if you want
            if (String.IsNullOrEmpty(url))
                return;

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            if (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se não conter o o valor informado, levanta uma exceção
        /// </summary>
        public static void IfNotContains(string value1, string expected, string message, [CallerMemberName] string callerMemberName = "")
        {
            if (!value1.Contains(expected))
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se não for um Guid, levanta uma exceção
        /// </summary>
        public static void IfNotGuid(string stringValue, string message, [CallerMemberName] string callerMemberName = "")
        {
            Guid x;

            if (Guid.TryParse(stringValue, out x) == false)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

        }

        /// <summary>
        /// Se não for um CPF válido, levanta exceção
        /// </summary>
        public static void IfNotCpf(string cpf, string message, [CallerMemberName] string callerMemberName = "")
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cpf.EndsWith(digito);

            if (isValid == false)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }

         
        }

        /// <summary>
        /// Se não for um Cnpj válido levanta uma exceção
        /// </summary>
        public static void IfNotCnpj(string cnpj, string message, [CallerMemberName] string callerMemberName = "")
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cnpj.EndsWith(digito);

            if (isValid == false)
            {
                NotificationManager.AddNotification(new Notification(message, callerMemberName, MethodBase.GetCurrentMethod().Name));
            }
            
        }
    }
}