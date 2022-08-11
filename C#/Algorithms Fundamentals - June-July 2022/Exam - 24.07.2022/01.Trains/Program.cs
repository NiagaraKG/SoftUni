using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class Train
    {
        public double Arrival { get; set; }
        public double Departue { get; set; }
    }
    public class Program
    {
        private static List<Train> trains;
        private static List<Train> currentTrains;
        public static void Main()
        {
            double[] arrivalTimes = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Array.Sort(arrivalTimes);
            double[] departueTimes = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Array.Sort(departueTimes);
            currentTrains = new List<Train>();
            trains = new List<Train>();
            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                trains.Add(new Train { Arrival = arrivalTimes[i], Departue = departueTimes[i] });
            }
            trains = trains.OrderBy(t=>t.Arrival).ThenBy(t=>t.Departue).ToList();
            currentTrains.Add(trains[0]);
            for (int i = 1; i < trains.Count; i++)
            {
                bool arrived = false;
                for (int j = 0; j < currentTrains.Count; j++)                
                {
                    if(trains[i].Arrival >= currentTrains[j].Departue)
                    {
                        currentTrains[j] = trains[i];
                        arrived = true;
                        continue;
                    }
                }
                if(!arrived) { currentTrains.Add(trains[i]); }
            }
            Console.WriteLine(currentTrains.Count);
        }
    }
}