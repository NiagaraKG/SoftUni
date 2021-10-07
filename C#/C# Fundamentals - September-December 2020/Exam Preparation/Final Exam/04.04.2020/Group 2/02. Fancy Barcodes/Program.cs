using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@[#]+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@[#]+)";
            Regex r = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match m = r.Match(barcode);
                if (m.Value == barcode)
                {
                    StringBuilder productGroup = new StringBuilder();
                    foreach (char c in barcode) { if (char.IsDigit(c)) { productGroup.Append(c); } }
                    if(productGroup.Length == 0) { productGroup.Append("00"); }
                    Console.WriteLine("Product group: " + productGroup.ToString());
                }
                else { Console.WriteLine("Ïnvalid barcode"); }
            }
        }
    }
}
