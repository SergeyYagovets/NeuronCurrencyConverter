using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m; // Вес входящего нейрона.
            public decimal Error { get; private set; }
            public decimal Step { get; set; } = 0.1m;
            public decimal InputData(decimal input) // Получает входящий сигнал, конвертирует в исходящие данные.
            {
                return input * weight;
            }

            public decimal RestoreInputData(decimal output) // Выполняет обратный процесс конвертации.
            {
                return output / weight;
            }

            public void TrainNeuron(decimal input, decimal expectedResult) // Обучение нейрона.
            {
                var actualResult = input * weight;
                Error = expectedResult - actualResult;
                var correction = (Error / actualResult) * Step;
                weight += correction;
            }
        }


        static void Main(string[] args)
        {
            decimal usd = 1;
            decimal ruble = 74.8569m;

            Neuron neuron = new Neuron();

            int i = 0; // Счетчик итераций 
            do
            {
                i++;
                neuron.TrainNeuron(usd, ruble); // Передаем точные данные usd, ruble.
                Console.WriteLine($"Итерация: {i}\tОшибка: \t{neuron.Error}"); // Вывод итераций и ошибок.

            } while (neuron.Error > neuron.Step || neuron.Error < -neuron.Step); // Сравнение значений и повтор цикла.

            Console.WriteLine("Обучение завершено!");

            Console.WriteLine($"{neuron.InputData(100)} ruble в {100} usd");
            Console.WriteLine($"{neuron.RestoreInputData(100)} usd в {100} ruble");
            Console.ReadLine();
        }
    }
}
