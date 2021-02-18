using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SumOfCoins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> values = Console.ReadLine().Split(new string[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).OrderByDescending(c => c).ToList();
            int sum = Console.ReadLine().Split(": ").Skip(1).Select(int.Parse).First();

            try
            {
                var selectedCoins = ChooseCoins(values, sum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);                
            }
           
        }
        public static Dictionary<int, int> ChooseCoins(List<int> coins, int targetSum)
        {
            var chosen = new Dictionary<int, int>();
            int currentSum = 0, index = 0;
            while (currentSum != targetSum && index < coins.Count)
            {
                int currentCoin = coins[index];
                int remainingSum = targetSum - currentSum;
                int numberOfCoins = remainingSum / currentCoin;
                if (numberOfCoins > 0)
                {
                    chosen.Add(currentCoin, numberOfCoins);
                    currentSum += numberOfCoins * currentCoin;
                }
                index++;
            }
            if (currentSum == targetSum) { return chosen; }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}
