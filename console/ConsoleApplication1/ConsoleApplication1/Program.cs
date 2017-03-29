using ConsoleApplication1.webRequestUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            HTTPRequester httpRequester = new HTTPRequester();
            ResponseData  responseData = httpRequester.GET("https://www.google.com/");

            Console.WriteLine(responseData.statusCode);
            Console.WriteLine(responseData.content);




            Console.Read();
        }
    }
}
