namespace prmToolkit.Notification
{
    public class Notification
    {
        public Notification( string message, string methodCallerName, string conditional)
        {
            this.Message = message;
            this.MethodCallerName = methodCallerName;
            this.Conditional = conditional;
        }

        public string Message { get; private set; }
        public string MethodCallerName { get; private set; }
        public string Conditional { get; private set; }

    }
}