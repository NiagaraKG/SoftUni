using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            Console.WriteLine(Validation(pass));
        }

        static string Validation(string pass)
        {
            string result = "";
            if(!ValidateLenght(pass))
            {
                result += "Password must be between 6 and 10 characters\n";
            }
            if(!ValidateSymbols(pass))
            {
                result += "Password must consist only of letters and digits\n";
            }
            if(!ValidateDigits(pass))
            {
                result += "Password must have at least 2 digits\n";
            }
            if (result == "") { result += "Password is valid"; }
            return result;
        }

        static bool ValidateLenght(string pass)
        {
            if(pass.Length >= 6 && pass.Length <= 10) { return true; }
            return false;
        }

        static bool ValidateSymbols(string pass)
        {
            foreach (var i in pass)
            {
                if(!char.IsLetterOrDigit(i)) { return false; }
            }
            return true;
        }

        static bool ValidateDigits(string pass)
        {
            int br = 0;
            foreach (var i in pass)
            {
                if (char.IsDigit(i)) { br++; if (br == 2) { return true; } }
            }
            return false;
        }

    }
}
