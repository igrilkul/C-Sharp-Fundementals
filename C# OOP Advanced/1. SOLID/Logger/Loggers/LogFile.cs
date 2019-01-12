using Logger.Loggers.Contracts;
using System.Linq;

namespace Logger.Loggers
{
    class LogFile : ILogFile
    {
        private int size;

        public LogFile()
        {
            this.Size = 0;
        }

        public int Size
        {
            get;
            private set;
        }

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}
