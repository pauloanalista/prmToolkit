using System;
using System.ComponentModel;
namespace prmToolkit.EnumExtension
{
    public static class EnumExtension
    {
        /// <summary>
        /// Obtém o Enum através do nome passado
        /// </summary>
        /// <typeparam name="T">Tipo genérico que representa o Enum</typeparam>
        /// <param name="value">Nome do Enum</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Obter a descrição do atributo definido no enum
        /// </summary>
        /// <param name="value">Valor do Enum</param>
        /// <returns>String contendo a descrição do Enum</returns>
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Obter o atributo customizado do enum
        /// </summary>
        /// <typeparam name="T">Tipo genérico de um Attribute</typeparam>
        /// <param name="value">Valor do Enum</param>
        /// <returns>String contendo o valor da descrição do atributo</returns>
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }
    }
}
