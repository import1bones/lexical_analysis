using System;
using System.Linq;

namespace lexical_analysis
{
    class Program
    {
        public string[] word = { "", "", "" };

        static void Main(string[] args)
        {
            string _0 = System.IO.File.ReadAllText("");
            string[] _1 = _0.Split(' ');
        }

        string Scaner(string block)
        {
            string temp = $"({block},{word.ToList().IndexOf(block)})";
            return temp;
        }
    }
}
