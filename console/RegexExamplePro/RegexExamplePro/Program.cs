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
            
            string newString = Regex.Replace(text, "public static void Inject(IServiceCollection services)", "<td>${0}</td>");
            Console.WriteLine(newString);

        }
    }
}