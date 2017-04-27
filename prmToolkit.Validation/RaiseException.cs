using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace prmToolkit.Validation
{
    public class RaiseException
    {
        #region IfEquals
        /// <summary>
        /// Se são iguais levanta exceção, a mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfEquals(object object1, object object2, bool generateIndividualException = false)
        {
            return IfEquals(object1, object2, string.Empty, generateIndividualException);
        }

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
        #endregion

        #region IfNotEquals

        /// <summary>
        /// Se não são iguais levanta exceção, a mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotEquals(object object1, object object2, bool generateIndividualException = false)
        {
            return IfNotEquals(object1, object2, string.Empty, generateIndividualException);
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
        #endregion

        #region IfEqualsZero
        /// <summary>
        /// Se o valor for igual a zero levanta exceção, a mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfEqualsZero(int object1, bool generateIndividualException = false)
        {
            return IfEquals(object1, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se for igual a zero levanta exceção
        /// </summary>
        public static Exception IfEqualsZero(int object1,  string message, bool generateIndividualException = false)
        {
            if (object1.Equals(0))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }
        #endregion

        #region IfTrue
        /// <summary>
        /// Se o valor passado for verdadeiro, levanta exceção.
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfTrue(bool boolValue, bool generateIndividualException = false)
        {
            return IfTrue(boolValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se o valor passado for verdadeiro, levanta exceção.
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
        #endregion

        #region IfFalse
        /// <summary>
        /// Se for falso levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfFalse(bool boolValue, bool generateIndividualException = false)
        {
            return IfFalse(boolValue, string.Empty, generateIndividualException);
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
        #endregion

        #region IfLength
        /// <summary>
        /// Se passar do comprimento máximo levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfLength(string stringValue, int maximum, bool generateIndividualException = false)
        {
            return IfLength(stringValue, maximum, string.Empty, generateIndividualException);
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
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfLength(string stringValue, int minimum, int maximum, bool generateIndividualException = false)
        {
            return IfLength(stringValue, minimum, maximum, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotMatches
        /// <summary>
        /// Se a expressão regular não for válida levanta exceção
        /// </summary>
        public static Exception IfNotMatches(string pattern, string stringValue, bool generateIndividualException = false)
        {
            return IfNotMatches(pattern, stringValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se a expressão regular não for válida levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
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

        #endregion

        #region IfNull
        /// <summary>
        /// Se for nulo levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNull(string stringValue, bool generateIndividualException = false)
        {
            return IfNull(stringValue, string.Empty, generateIndividualException);
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
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNull(object objectValue, bool generateIndividualException = false)
        {
            return IfNull(objectValue, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotNull
        /// <summary>
        /// Se não for nulo levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotNull(object object1, bool generateIndividualException = false)
        {
            return IfNotNull(object1, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNullOrEmpty
        /// <summary>
        /// Se for nulo ou vazio, levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNullOrEmpty(string stringValue, bool generateIndividualException = false)
        {
            return IfNullOrEmpty(stringValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se for nulo ou vazio, levanta exceção
        /// </summary>
        public static Exception IfNullOrEmpty(string stringValue, string message, bool generateIndividualException = false)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }
        #endregion

        #region IfNullOrEmptyOrWhiteSpace
        /// <summary>
        /// Se for nulo ou vazio ou tem espaço vazio, levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNullOrEmptyOrWhiteSpace(string stringValue, bool generateIndividualException = false)
        {
            
            return IfNullOrEmptyOrWhiteSpace(stringValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se for nulo ou vazio, levanta exceção
        /// </summary>
        public static Exception IfNullOrEmptyOrWhiteSpace(string stringValue, string message, bool generateIndividualException = false)
        {
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }
        #endregion

        #region IfEmpty
        /// <summary>
        /// Se é vazio levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfEmpty(string stringValue, bool generateIndividualException = false)
        {
            return IfEmpty(stringValue, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotRange
        /// <summary>
        /// Se não atende o limite entre um minimo e máximo
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotRange(double value, double minimum, double maximum, bool generateIndividualException = false)
        {
            return IfNotRange(value, minimum, maximum, string.Empty, generateIndividualException);
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
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotRange(float value, float minimum, float maximum, bool generateIndividualException = false)
        {
            return IfNotRange(value, minimum, maximum, string.Empty, generateIndividualException);
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
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotRange(int value, int minimum, int maximum, bool generateIndividualException = false)
        {
            return IfNotRange(value, minimum, maximum, string.Empty, generateIndividualException);
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
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotRange(long value, long minimum, long maximum, bool generateIndividualException = false)
        {
            return IfNotRange(value, minimum, maximum, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotEmail
        /// <summary>
        /// Se não for um email válido levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotEmail(string email, bool generateIndividualException = false)
        {
            return IfNotEmail(email, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotGreaterThan
        /// <summary>
        /// Se o primeiro valor não for maior que o segundo levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotGreaterThan(int value1, int value2, bool generateIndividualException = false)
        {
            return IfNotGreaterThan(value1, value2, string.Empty, generateIndividualException);
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
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotGreaterThan(decimal value1, decimal value2, bool generateIndividualException = false)
        {
            return IfNotGreaterThan(value1, value2, string.Empty, generateIndividualException);
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

        #endregion

        #region IfNotGreaterOrEqualThan
        /// <summary>
        /// Se o primeiro valor não for maior ou igual que o segundo levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotGreaterOrEqualThan(int value1, int value2, bool generateIndividualException = false)
        {
            return IfNotGreaterOrEqualThan(value1, value2, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotUrl
        /// <summary>
        /// Se não for uma url válida, levanta uma exceção.
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotUrl(string url, bool generateIndividualException = false)
        {
            return IfNotUrl(url, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotContains
        /// <summary>
        /// Se não conter o o valor informado, levanta uma exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotContains(string value1, string expected, bool generateIndividualException = false)
        {
            return IfNotContains(value1, expected, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotGuid
        /// <summary>
        /// Se não for um Guid, levanta uma exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotGuid(string stringValue, bool generateIndividualException = false)
        {
            return IfNotGuid(stringValue, string.Empty, generateIndividualException);
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
        #endregion

        #region IfNotCpf
        /// <summary>
        /// Se não for um CPF válido, levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotCpf(string cpf, bool generateIndividualException = false)
        {
            return IfNotCpf(cpf, string.Empty, generateIndividualException);
        }
        /// <summary>
        /// Se não for um CPF válido, levanta exceção
        /// </summary>
        public static Exception IfNotCpf(string cpf, string message, bool generateIndividualException = false)
        {
            IfNullOrEmpty(cpf, "Cpf não pode ser nulo.", generateIndividualException);
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
        #endregion

        #region IfNotCnpj
        /// <summary>
        /// Se não for um Cnpj válido levanta uma exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfNotCnpj(string cnpj, bool generateIndividualException = false)
        {
            return IfNotCnpj(cnpj, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se não for um Cnpj válido levanta uma exceção
        /// </summary>
        public static Exception IfNotCnpj(string cnpj, string message, bool generateIndividualException = false)
        {
            IfNullOrEmpty(cnpj, "Cnpj não pode ser nulo.", generateIndividualException);
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
        #endregion

        #region IfCollectionEmpty
        
        #region IEnumerable
        /// <summary>
        /// Se não há itens na coleção levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfCollectionEmpty(IEnumerable<object> colectionValue, bool generateIndividualException = false)
        {
            return IfCollectionEmpty(colectionValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se não há itens na coleção levanta exceção
        /// </summary>
        public static Exception IfCollectionEmpty(IEnumerable<object> colectionValue, string message, bool generateIndividualException = false)
        {
            if (colectionValue == null || colectionValue.Count() < 1)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }

        #endregion
        
        #region Array[]
        /// <summary>
        /// Se não há itens na coleção levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfCollectionEmpty(object[] colectionValue, bool generateIndividualException = false)
        {
            return IfCollectionEmpty(colectionValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se não há itens na coleção levanta exceção
        /// </summary>
        public static Exception IfCollectionEmpty(object[] colectionValue, string message, bool generateIndividualException = false)
        {
            if (colectionValue == null || colectionValue.Count() < 1)
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
        /// Se não há itens na coleção levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfCollectionEmpty(int[] colectionValue, bool generateIndividualException = false)
        {
            return IfCollectionEmpty(colectionValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se não há itens na coleção levanta exceção
        /// </summary>
        public static Exception IfCollectionEmpty(int[] colectionValue, string message, bool generateIndividualException = false)
        {
            if (colectionValue == null || colectionValue.Count() < 1)
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
        /// Se não há itens na coleção levanta exceção
        /// Há mensagem deverá ser definida no método ArgumentsValidator.RaiseExceptionOfInvalidArguments
        /// </summary>
        public static Exception IfCollectionEmpty(string[] colectionValue, bool generateIndividualException = false)
        {
            return IfCollectionEmpty(colectionValue, string.Empty, generateIndividualException);
        }

        /// <summary>
        /// Se não há itens na coleção levanta exceção
        /// </summary>
        public static Exception IfCollectionEmpty(string[] colectionValue, string message, bool generateIndividualException = false)
        {
            if (colectionValue == null || colectionValue.Count() < 1)
            {
                if (generateIndividualException == true)
                {
                    throw new InvalidOperationException(message);
                }

                return new InvalidOperationException(message);
            }

            return null;
        }
        #endregion

        #endregion
    }
}
