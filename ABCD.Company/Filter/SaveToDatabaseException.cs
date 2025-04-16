namespace ABCD.Company.Filter
{
    public class SaveToDatabaseException : Exception
    {
        public SaveToDatabaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
