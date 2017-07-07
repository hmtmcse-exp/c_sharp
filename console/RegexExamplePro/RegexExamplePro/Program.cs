using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexExamplePro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var location = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "RegexExamplePro");
            var textLoc = Path.Combine(location, "AppDependencyInjector.txt");
            var text = File.ReadAllText(textLoc);
            //Console.WriteLine(text);

            string replaceBy = "public static void Inject(IServiceCollection services)\n        {\n            ";
            replaceBy += "services.AddTransient<IOrganizerService, OrganizerService>();";
            string newString = Regex.Replace(text, "public static void Inject\\(IServiceCollection services\\)\\s*{", replaceBy);
            Console.WriteLine(newString);

        }
    }
}