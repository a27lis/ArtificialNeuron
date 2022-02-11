using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public class Neuron {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.00001m;
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }
            public void Train(decimal input, decimal ExpectedResult)
            {
                var actualResult = input * weight;
                LastError = ExpectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;

            }
        }
        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();

            int i = 0;
            do
            {
                i++;
                neuron.Train(km, miles);
                Console.WriteLine($"Iter: {i}\tError:\t{neuron.LastError}");
            } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("training completed");
            Console.WriteLine($"{neuron.ProcessInputData(100)} miles in {100} km");
            Console.WriteLine($"{neuron.ProcessInputData(541)} miles in {541} km");
            Console.WriteLine($"{neuron.RestoreInputData(10)} km in {10} miles");
            Console.ReadLine();
        }
    }
}
