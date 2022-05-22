using System;
using System.Text;

namespace ProdajaPica
{
    public static class ExpectionExtensions
    {

        public static string CompleteExceptionMessage(this Exception e)
        {
            StringBuilder sb = new StringBuilder();
            while (e != null)
            {
                sb.AppendLine(e.Message);
                e = e.InnerException;
            }
            return sb.ToString();
        }
    }
}