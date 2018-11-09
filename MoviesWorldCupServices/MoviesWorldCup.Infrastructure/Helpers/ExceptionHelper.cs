using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesWorldCup.Infrastructure.Helpers
{
    public class ExceptionHelper
    {
        public static string AggregateExceptionMessages(Exception exception)
        {
            Exception next = exception;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"MethodName: {next.TargetSite.Name}");
            sb.AppendLine("FullMessage: ");
            do
            {
                sb.AppendLine(next.Message);
                next = next.InnerException;
            } while (next != null);

            sb.AppendLine($"StackTrace: {exception.StackTrace}");


            return sb.ToString();
        }
    }
}
