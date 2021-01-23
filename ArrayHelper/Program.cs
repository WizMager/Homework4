using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayHelper
{
    public class Program
    {
        /// <summary>
        /// Print one-dimentional int[] array in one line.
        /// </summary>
        public static void PrintIntArray(int[] array)
        {
            string result = "Текущий массив: ";
            for(int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// Print two-dimentional int[,] array in two line.
        /// </summary>
        public static void PrintIntArray(int[,] array)
        {
            Console.WriteLine("\\/Текущий массив\\/");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create one dimentional int[] array with random int numbers in range (minVal - maxVal).
        /// </summary>
        /// <param name="numElem">Array elements number</param>
        /// <param name="minVal">Minimal random value</param>
        /// <param name="maxVal">Maximum random value</param>
        /// <returns>Created array[]</returns>
        public static int[] CreateIntArray(int numElem, int minVal, int maxVal)
        {
            int[] array = new int[numElem];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minVal, maxVal);
            }
            return array;
        }

        /// <summary>
        /// Create two dimentional int[,] array with random int numbers in range (minVal - maxVal).
        /// </summary>
        /// <param name="numElemRow">Array rows number</param>
        /// <param name="numElemCol">Array columns number</param>
        /// <param name="minVal">Minimal random value</param>
        /// <param name="maxVal">Maximum random value</param>
        /// <returns>Created array[,]</returns>
        public static int[,] CreateIntArray(int numElemRow, int numElemCol, int minVal, int maxVal)
        {
            int[,] array = new int[numElemRow, numElemCol];
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = random.Next(minVal, maxVal);
                }
            }
            return array;
        }

        /// <summary>
        /// Create one dimentional int[] array with random int numbers.
        /// </summary>
        /// <param name="numElem">Array elements number</param>
        /// <returns>Created array[]</returns>
        public static int[] CreateIntArray(int numElem)
        {
            int[] array = new int[numElem];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        /// <summary>
        /// Create two dimentional int[,] array with random int numbers.
        /// </summary>
        /// <param name="numElemRow">Array rows number</param>
        /// <param name="numElemCol">Array columns number</param>
        /// <returns>Created array[,]</returns>
        public static int[,] CreateIntArray(int numElemRow, int numElemCol)
        {
            int[,] array = new int[numElemRow, numElemCol];
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next();
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
        }
    }
}
