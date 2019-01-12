
namespace Logger
{
    using Logger.Core;
    //log.txt file gets created in debug folder
    class StartUp
    {
        static void Main(string[] args)
        {
            CommandInterpreter ci = new CommandInterpreter();
            Engine engine = new Engine(ci);
            engine.Run();
        }
    }
}
