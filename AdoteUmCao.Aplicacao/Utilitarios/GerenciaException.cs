using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmCao.Aplicacao.Utilitarios
{
    public class GerenciaException
    {
        public static string LogarErro(Exception exc, string usuario = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("********** {0} **********", DateTime.Now));

            sb.Append("Inner Exception: ");

            if (exc.InnerException != null)
            {
                sb.Append("Tipo do Inner Exception: ");
                sb.AppendLine(exc.InnerException.GetType().ToString());
                sb.Append("Inner Exception Mensagem: ");
                sb.AppendLine(exc.InnerException.Message);
                sb.Append("Inner Source: ");
                sb.AppendLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sb.AppendLine("Inner Stack Trace: ");
                    sb.AppendLine(exc.InnerException.StackTrace);
                }
            }
            else
            {
                sb.AppendLine("Sem informação.");
            }

            sb.Append("Tipo da Exception: ");
            sb.AppendLine(exc.GetType().ToString());
            sb.AppendLine("Exception Mensagem: " + exc.Message);
            sb.AppendLine("Stack Trace: ");

            if (exc.StackTrace != null)
            {
                sb.AppendLine(exc.StackTrace);
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("Sem informação.");
            }

            return sb.ToString();
        }
    }
}
