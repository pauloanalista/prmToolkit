namespace prmToolkit.Log.Enum
{
    public enum EnumModeToSave
    {
        /// <summary>
        /// Salva em todos os lugares configurados, seja banco, txt ou eventviewer
        /// </summary>
        SaveToAll = 0,

        /// <summary>
        /// Salva no primeiro modo configurado, caso de algum erro, entra o modo de contigencia em ação
        /// </summary>
        SaveToContigency = 1
    }
}
