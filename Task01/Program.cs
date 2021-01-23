using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayHelper;

namespace Task01
{
    /*1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
         Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
         В данной задаче под парой подразумевается два подряд идущих элемента массива.Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4. */
    class Program
    {
        static void Main(string[] args)
        {
            var array = ArrayHelper.Program.CreateIntArray(20, -10000, 10000);

            ArrayHelper.Program.PrintIntArray(array);
            Console.ReadKey();

            Console.WriteLine($"В полученном массиве количество пар элементов массива, в которых хотя бы одно число делится на 3 равно: {CheckPairArray(array)}");
            Console.ReadKey();
        }

        static int CheckPairArray(int[] array)
        {
            int conter = 0;
            for (int i = 1; i < array.Length; i++)
            {
                int previous = array[i - 1];
                int cur = array[i];
                if (previous % 3 == 0 || cur % 3 == 0)
                    conter++;
            }
            return conter;
        }
    }
}
