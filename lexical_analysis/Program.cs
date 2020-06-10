using System;
using System.Linq;

namespace lexical_analysis
{
    class Program
    {
        private static readonly string[] word = { null, "main", "int", "char", "if", "else", "for", "while",
            null, null, "ID", null, null, null, null, null, null, null, null, null, "NUM", "=", "+", "-", "*",
            "/", "(", ")", "[", "]", "{", "}", ",", ":", ";", ">", "<", ">=", "<=", "==", "!=", "&",
            "&&", "||" };
        private static readonly string[] keyWord = { "main", "int", "char", "char", "if", "else", "for", "while" };
        private static readonly string[] opWord = { "=", "+", "-", "*", "/", "(", ")", "[", "]", "{", "}", ",", ":", ";", ">", "<", ">=", "<=", "==", "!=", "&", "&&", "||" };
        private static readonly string[] digit = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private static readonly string[] letter = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D",
            "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
            "X", "Y", "Z" };
        static void Main(string[] args)
        {
            string[] _0 = System.IO.File.ReadAllLines("C:/Users/13519/source/repos/lexical_analysis/lexical_analysis/test.txt");
            Program LA = new Program();
            int x = 0;
            foreach (string line in _0)
            {
                x++;
                string[] _1 = line.Split(new char[3] { ' ', '\n', '\t' });
                foreach (string item in _1)
                {
                    string formatLine = item;
                    foreach (var so in opWord)
                    {
                        //so is special opcode;
                        if(formatLine.IndexOf(so)!=-1)
                        {
                            formatLine = formatLine.Insert(formatLine.IndexOf(so), " ");
                            formatLine = formatLine.Insert(formatLine.IndexOf(so) + 1, " ");
                        }
                        
                    }
                    string[] formated = formatLine.Split(" ");
                    foreach (string block in formated)
                    {
                        if(!block.Equals(""))
                        {
                            string result = LA.Scaner(block);
                            if (result.Equals("error"))
                            {
                                int y = line.IndexOf(block) + 1;
                                LA.PrintError(block, x, y);
                            }
                            else
                            {
                                Console.WriteLine(result);
                            }
                        }  
                    }
                }
            }
            
        }

        private void PrintError(string error,int x,int y)
        {
            Console.WriteLine($"line:{x} column:{y} error:{error}");
        }

        private string Scaner(string block)
        {
            string temp;
            if (IsKeyWord(block))
            {
                temp = $"({word.ToList().IndexOf(block)},{block})";
            }
            else if(IsId(block))
            {
                temp = $"({word.ToList().IndexOf("ID")},{block})";
            }
            else if (IsNum(block))
            {
                temp = $"({word.ToList().IndexOf("NUM")},{block})";
            }
            else if(IsOpWord(block))
            {
                temp = $"({word.ToList().IndexOf(block)},{block})";
            }
            else
            {
                temp = "error";
            }
            return temp;
        }

        private bool IsKeyWord(string block)
        {
            bool ret = true;
            if (keyWord.ToList().IndexOf(block) == -1)
            {
                ret = false;
            }
            return ret;
        }

        private bool IsOpWord(string block)
        {
            bool ret = true;
            if (opWord.ToList().IndexOf(block) == -1)
            {
                ret = true;
            }
            return ret;
        }

        private bool IsId(string block)
        {
            bool ret_0 = true;
            bool ret_1 = true;
            string[] chars = block.Split("");
            if (letter.ToList().IndexOf(chars[0]) == -1) 
            {
                ret_0 = false;
            }
            foreach (string item in chars)
            {
                if(letter.ToList().IndexOf(chars[0]) == -1 && digit.ToList().IndexOf(chars[0]) == -1)
                {
                    ret_1 = false;
                }
            }
            return ret_0 & ret_1;
        }

        private bool IsNum(string block)
        {
            bool ret = true;
            var Num = block.ToList();
            foreach (var item in Num)
            {
                if (digit.ToList().IndexOf(item.ToString()) == -1)
                {
                    ret = false;
                }
            }
            return ret;
        }
    }
}
