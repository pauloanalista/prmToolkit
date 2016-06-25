using System;
using System.Text.RegularExpressions;

namespace prmToolkit.Validation
{
    public class Validate
    {
        /// <summary>
        /// Garante que ambos os objetos sejam iguais
        /// </summary>
        public static Exception IsEquals(object object1, object object2, string message, bool generateIndividualException = false)
        {
            if (!object1.Equals(object2))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que ambos os objetos não sejam iguais
        /// </summary>
        public static Exception IsNotEquals(object object1, object object2, string message, bool generateIndividualException = false)
        {
            if (object1.Equals(object2))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado seja verdadeiro
        /// </summary>
        public static Exception IsTrue(bool boolValue, string message, bool generateIndividualException = false)
        {
            if (!boolValue)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado seja falso
        /// </summary>
        public static Exception IsFalse(bool boolValue, string message, bool generateIndividualException = false)
        {
            if (boolValue)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado atenda o comprimento máximo
        /// </summary>
        public static Exception IsLength(string stringValue, int maximum, string message, bool generateIndividualException = false)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado atenda o comprimento minimo e máximo
        /// </summary>
        public static Exception IsLength(string stringValue, int minimum, int maximum, string message, bool generateIndividualException = false)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que a expressão regular é valida
        /// </summary>
        public static Exception IsMatches(string pattern, string stringValue, string message, bool generateIndividualException = false)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado é nulo
        /// </summary>
        public static Exception IsNull(string stringValue, string message, bool generateIndividualException = false)
        {
            if (stringValue != null)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado não é nulo
        /// </summary>
        public static Exception IsNotNull(object object1, string message, bool generateIndividualException = false)
        {
            if (object1 == null)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado não é nulo ou vazio
        /// </summary>
        public static Exception IsNullOrEmpty(string stringValue, string message, bool generateIndividualException = false)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado é vazio
        /// </summary>
        public static Exception IsEmpty(string stringValue, string message, bool generateIndividualException = false)
        {
            if (stringValue == null || stringValue.Trim().Length > 0)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado atenda o limite entre um minimo e máximo
        /// </summary>
        public static Exception Range(double value, double minimum, double maximum, string message, bool generateIndividualException = false)
        {
            if (value < minimum || value > maximum)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado atenda o limite entre um minimo e máximo
        /// </summary>
        public static Exception Range(float value, float minimum, float maximum, string message, bool generateIndividualException = false)
        {
            if (value < minimum || value > maximum)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado atenda o limite entre um minimo e máximo
        /// </summary>
        public static Exception Range(int value, int minimum, int maximum, string message, bool generateIndividualException = false)
        {
            if (value < minimum || value > maximum)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor passado atenda o limite entre um minimo e máximo
        /// </summary>
        public static Exception Range(long value, long minimum, long maximum, string message, bool generateIndividualException = false)
        {
            if (value < minimum || value > maximum)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor é um e-mail valido
        /// </summary>
        public static Exception IsEmail(string email, string message, bool generateIndividualException = false)
        {
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new Exception(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor o primeiro valor seja maior que o segundo valor
        /// </summary>
        public static Exception IsGreaterThan(int value1, int value2, string message, bool generateIndividualException = false)
        {
            if (!(value1 > value2))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new Exception(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor o primeiro valor seja maior que o segundo valor
        /// </summary>
        public static Exception IsGreaterThan(decimal value1, decimal value2, string message, bool generateIndividualException = false)
        {
            if (!(value1 > value2))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new Exception(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que o valor o primeiro valor seja maior ou igual que o segundo valor
        /// </summary>
        public static Exception IsGreaterOrEqualThan(int value1, int value2, string message, bool generateIndividualException = false)
        {
            if (!(value1 >= value2))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new Exception(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que seja uma url válida. Só irá validar caso o parametro seja preenchido
        /// </summary>
        public static Exception IsUrl(string url, string message, bool generateIndividualException = false)
        {
            // Do not validate if no URL is provided
            // You can call AssertNotEmpty before this if you want
            if (String.IsNullOrEmpty(url))
                return null;

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            if (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new Exception(message);
            }

            return null;
        }

        /// <summary>
        /// Garante que contém o valor informado
        /// </summary>
        public static Exception Contains(string value1, string expected, string message, bool generateIndividualException = false)
        {
            if (!value1.Contains(expected))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }
    }
}
