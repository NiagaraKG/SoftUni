using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < text.Count; i++)
            {
                switch (text[i])
                {
                    case ".-": text[i] = "A"; break;
                    case "-...": text[i] = "B"; break;
                    case "-.-.": text[i] = "C"; break;
                    case "-..": text[i] = "D"; break;
                    case ".": text[i] = "E"; break;
                    case "..-.": text[i] = "F"; break;
                    case "--.": text[i] = "G"; break;
                    case "....": text[i] = "H"; break;
                    case "..": text[i] = "I"; break;
                    case ".---": text[i] = "J"; break;
                    case "-.-": text[i] = "K"; break;
                    case ".-..": text[i] = "L"; break;
                    case "--": text[i] = "M"; break;
                    case "-.": text[i] = "N"; break;
                    case "---": text[i] = "O"; break;
                    case ".--.": text[i] = "P"; break;
                    case "--.-": text[i] = "Q"; break;
                    case ".-.": text[i] = "R"; break;
                    case "...": text[i] = "S"; break;
                    case "-": text[i] = "T"; break;
                    case "..-": text[i] = "U"; break;
                    case "...-": text[i] = "V"; break;
                    case ".--": text[i] = "W"; break;
                    case "-..-": text[i] = "X"; break;
                    case "-.--": text[i] = "Y"; break;
                    case "--..": text[i] = "Z"; break;
                    default: text[i] = " "; break;
                }
            }
            Console.WriteLine(string.Join("", text));
        }
    }
}
