using System.ComponentModel;

namespace prmToolkit.Log.Enum
{
    public enum EnumMessageType
    {
        [Description("Information")]
        Information = 0,

        [Description("Warning")]
        Warning = 1,

        [Description("Error")]
        Error = 2
    }
}
