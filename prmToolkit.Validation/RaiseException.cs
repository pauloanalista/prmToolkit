using System;
using System.Text.RegularExpressions;

namespace prmToolkit.Validation
{
    public class RaiseException
    {
        /// <summary>
        /// Se são iguais levanta exceção
        /// </summary>
        public static Exception IfEquals(object object1, object object2, string message, bool generateIndividualException = false)
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
        /// Se não são iguais levanta exceção
        /// </summary>
        public static Exception IfNotEquals(object object1, object object2, string message, bool generateIndividualException = false)
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
        /// Se o valor passado for verdadeiro, levanta exceção
        /// </summary>
        public static Exception IfTrue(bool boolValue, string message, bool generateIndividualException = false)
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
        /// Se for falso levanta exceção
        /// </summary>
        public static Exception IfFalse(bool boolValue, string message, bool generateIndividualException = false)
        {
            if (boolValue == false)
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
        /// Se passar do comprimento máximo levanta exceção
        /// </summary>
        public static Exception IfLength(string stringValue, int maximum, string message, bool generateIndividualException = false)
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
        /// Se não atender o valor mínimo e máximo levanta exceção
        /// </summary>
        public static Exception IfLength(string stringValue, int minimum, int maximum, string message, bool generateIndividualException = false)
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
        /// Se a expressão regular não for válida levanta exceção
        /// </summary>
        public static Exception IfNotMatches(string pattern, string stringValue, string message, bool generateIndividualException = false)
        {
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(stringValue) == false)
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
        /// Se for nulo levanta exceção
        /// </summary>
        public static Exception IfNull(string stringValue, string message, bool generateIndividualException = false)
        {
            if (stringValue == null)
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
        /// Se for nulo levanta exceção
        /// </summary>
        public static Exception IfNull(object objectValue, string message, bool generateIndividualException = false)
        {
            if (objectValue == null)
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
        /// Se não for nulo levanta exceção
        /// </summary>
        public static Exception IfNotNull(object object1, string message, bool generateIndividualException = false)
        {
            if (object1 != null)
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
        /// Se for nulo ou vazio, levanta exceção
        /// </summary>
        public static Exception IfNullOrEmpty(string stringValue, string message, bool generateIndividualException = false)
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
        /// Se é vazio levanta exceção
        /// </summary>
        public static Exception IfEmpty(string stringValue, string message, bool generateIndividualException = false)
        {
            if (stringValue == null || stringValue.Trim().Length <= 0)
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
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static Exception IfNotRange(double value, double minimum, double maximum, string message, bool generateIndividualException = false)
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
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static Exception IfNotRange(float value, float minimum, float maximum, string message, bool generateIndividualException = false)
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
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static Exception IfNotRange(int value, int minimum, int maximum, string message, bool generateIndividualException = false)
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
        /// Se não atende o limite entre um minimo e máximo
        /// </summary>
        public static Exception IfNotRange(long value, long minimum, long maximum, string message, bool generateIndividualException = false)
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
        /// Se não for um email válido levanta exceção
        /// </summary>
        public static Exception IfNotEmail(string email, string message, bool generateIndividualException = false)
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
        /// Se o primeiro valor não for maior que o segundo levanta exceção
        /// </summary>
        public static Exception IfNotGreaterThan(int value1, int value2, string message, bool generateIndividualException = false)
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
        /// Se o primeiro valor não for maior que o segundo levanta exceção
        /// </summary>
        public static Exception IfNotGreaterThan(decimal value1, decimal value2, string message, bool generateIndividualException = false)
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
        /// Se o primeiro valor não for maior ou igual que o segundo levanta exceção
        /// </summary>
        public static Exception IfNotGreaterOrEqualThan(int value1, int value2, string message, bool generateIndividualException = false)
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
        /// Se não for uma url válida, levanta uma exceção.
        /// </summary>
        public static Exception IfNotUrl(string url, string message, bool generateIndividualException = false)
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
        /// Se não conter o o valor informado, levanta uma exceção
        /// </summary>
        public static Exception IfNotContains(string value1, string expected, string message, bool generateIndividualException = false)
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

        /// <summary>
        /// Se não for um Guid, levanta uma exceção
        /// </summary>
        public static Exception IfNotGuid(string stringValue, string message, bool generateIndividualException = false)
        {
            Guid x;

            if (Guid.TryParse(stringValue, out x) == false)
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
        /// Se não for um CPF válido, levanta exceção
        /// </summary>
        public static Exception IfNotCpf(string cpf, string message, bool generateIndividualException = false)
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
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
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
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        /// <summary>
        /// Se não for um Cnpj válido levanta uma exceção
        /// </summary>
        public static Exception IfNotCnpj(string cnpj, string message, bool generateIndividualException = false)
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
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
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

            if(isValid == false)
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
