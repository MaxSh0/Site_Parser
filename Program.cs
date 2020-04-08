using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using ParserLibrary;
namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserHeadline parser = new ParserHeadline();
            parser.Parse("https://ru.lipsum.com/");

        }
    }
}
