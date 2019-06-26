using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class Program
    {
        public static double Input(string sentence, double minBorder = double.MinValue, double maxBorder = double.MaxValue)
        {
            double result = 0;
            bool ok = true;
            do
            {
                Console.Write(sentence);
                ok = double.TryParse(Console.ReadLine(), out result);
                if (result < minBorder || result > maxBorder)
                {
                    ok = false;
                }
            }
            while (!ok);
            return result;
        }
        public static int IntInput(string sentence, int minBorder = int.MinValue, int maxBorder = int.MaxValue)
        {
            int result = 0;
            bool ok = true;
            do
            {
                Console.Write(sentence);
                ok = int.TryParse(Console.ReadLine(), out result);
                if (result < minBorder || result > maxBorder)
                {
                    ok = false;
                }
            }
            while (!ok);
            return result;
        }
        static double[] ParseNumbers(string sentence, int len)
        {
            double[] result = new double[0];
            bool ok = true;
            do
            {
                try
                {
                    Console.Write(sentence);
                    string input = Console.ReadLine().Replace('.', ',');
                    result = input.Split(' ').Select(x => double.Parse(x)).ToArray();
                    if (result.Length != len) throw new IndexOutOfRangeException();
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат строки");
                    ok = false;

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Неверное количество чисел в строке");
                    ok = false;
                }

            }
            while (!ok);
            return result;
        }
        public static double[] GetMaxValues(double[][] matrix)
        {
            int size = matrix.Length;
            double[] maxValues = new double[size];

            for (int i = 0; i < size; i++)
            {
                maxValues[i] = double.MinValue;
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i][j] > maxValues[i]) maxValues[i] = matrix[i][j];

                }
            }
            return maxValues;
        }
        public static double GetSum(double[] maxValues)
        {
            double sum = 0;
            for (int i = 0, j = maxValues.Length - 1; i < maxValues.Length; i++, j--)
            {
                sum += maxValues[i] * maxValues[j];
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задача №5 (400)\n" +
                "Дана действительная квадратная матрица порядка n. \n" +
                "Получить x1xn + x2xn-1+…+xnx1, где xk – наибольшее значение элементов \nk-й строки данной матрицы.\n");
            int size = IntInput("Введите порядок матрицы: ");
            Console.WriteLine("Введите построчно элементы матрицы через пробел. Например: 1 2 5 4 ");
            double[][] matrix = new double[size][];

            for(int i = 0; i < size; i++)
            {
                matrix[i] = ParseNumbers($"Введите {i + 1} строку элементов матрицы: ", size);
            }
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
            
            
            
            Console.WriteLine($"Результат: {GetSum(GetMaxValues(matrix))}");
            Console.ReadKey();
        }
    }
}
