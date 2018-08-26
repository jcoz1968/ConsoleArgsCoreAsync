using McMaster.Extensions.CommandLineUtils;
using System;
using System.Threading.Tasks;

namespace ConsoleArgsCoreAsync
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.HelpOption("-h|--help");
            var optionSubject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
            var optionRepeat = app.Option<int>("-n|--count <N>", "Repeat", CommandOptionType.SingleValue);

            app.OnExecute(async () =>
            {
                var subject = optionSubject.HasValue() ? optionSubject.Value() : "world";

                var count = optionRepeat.HasValue() ? optionRepeat.ParsedValue : 1;
                for (var i = 0; i < count; i++)
                {
                    Console.Write($"Hello");

                    // This pause here is just for indication that some awaitable operation could happens here.
                    await Task.Delay(5000);
                    Console.WriteLine($" {subject}!");
                }
            });

            return app.Execute(args);
        }
    }
}
