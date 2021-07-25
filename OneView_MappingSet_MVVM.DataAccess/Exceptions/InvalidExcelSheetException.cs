using System;

namespace OneView_MappingSet_MVVM.DataAccess.Exceptions
{
    public class InvalidExcelSheetException : Exception
    {
        public InvalidExcelSheetException()
        {
        }

        public InvalidExcelSheetException(string message)
            : base(message)
        {
        }

        public InvalidExcelSheetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
