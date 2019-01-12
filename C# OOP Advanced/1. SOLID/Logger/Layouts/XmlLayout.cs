using Logger.Layouts.Contracts;
using System.Text;

namespace Logger.Layouts
{
    class XmlLayout : ILayout
    {

        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<log>");
                sb.AppendLine("  <date>{0}</date>");
                sb.AppendLine("  <level>{1}</level>");
                sb.AppendLine("  <message>{2}</message>");
                sb.Append("</log>");

                return sb.ToString();
            }
        }
            

            
      }
}
