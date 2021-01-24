using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayHelper;

namespace Task04
{
    /* 4. а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.
          Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
          возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
          возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
        * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
         Дополнительные задачи
        * в) Обработать возможные исключительные ситуации при работе с файлами. */
    class Program
    {
        static void Main(string[] args)
        {
            TwoDimentionalArray array1 = new TwoDimentionalArray(2, 5, -10, 10);
            ArrayHelper.Program.PrintIntArray(array1.Array);
            Console.WriteLine($"Сумма элементов массива равна: {array1.SumElements()}.");
            Console.WriteLine();

            TwoDimentionalArray array2 = new TwoDimentionalArray(2, 4, -10, 10);
            ArrayHelper.Program.PrintIntArray(array2.Array);
            Console.WriteLine($"Сумма элементов массива больше заданного равна: {array2.SumElements(0)}.");
            Console.WriteLine();

            TwoDimentionalArray array3 = new TwoDimentionalArray(2, 7, -10, 10);
            ArrayHelper.Program.PrintIntArray(array3.Array);
            Console.WriteLine($"Максимальное число в массиве: {array3.MaxNum}.");
            Console.WriteLine($"Минимальное число в массиве: {array3.MinNum}.");
            Console.WriteLine();

            TwoDimentionalArray array4 = new TwoDimentionalArray(2, 6, -100, 100);
            ArrayHelper.Program.PrintIntArray(array4.Array);
            int[] maxElem = array4.NumMaxElement();
            Console.WriteLine($"Индексы элемента с максимальным значением: {maxElem[0]}, {maxElem[1]}.");
            Console.WriteLine();

            var fileName = AppDomain.CurrentDomain.BaseDirectory + "ArrayList.txt";
            Console.WriteLine("Загрузка с файла.");
            TwoDimentionalArray array5 = new TwoDimentionalArray(fileName);
            ArrayHelper.Program.PrintIntArray(array5.Array);
            TwoDimentionalArray array6 = new TwoDimentionalArray(2, 3, -10, 10);
            Console.WriteLine("Запись в файл и вывод записанного массива.");
            array6.SaveArray(fileName);
            TwoDimentionalArray array7 = new TwoDimentionalArray(fileName);
            ArrayHelper.Program.PrintIntArray(array7.Array);
            Console.ReadKey();
        }
    }

    class TwoDimentionalArray
    {
        private int[,] array;

        public int[,] Array
        {
            get { return array; }
            set { array = value; }
        }

        /// <summary>
        /// Return maximal element of array.
        /// </summary>
        public int MaxNum
        {
            get
            {
                int max = Array[0, 0];
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    for (int j = 1; j < Array.GetLength(1); j++)
                    {
                        if (max < Array[i, j])
                            max = Array[i, j];
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Return minimal element of array.
        /// </summary>
        public int MinNum
        {
            get
            {
                int min = Array[0, 0];
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    for (int j = 1; j < Array.GetLength(1); j++)
                    {
                        if (min > Array[i, j])
                            min = Array[i, j];
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Constructor create two dimentional int[,] array with random int numbers in range (minVal - maxVal).
        /// </summary>
        /// <param name="numElemRow">Array rows number</param>
        /// <param name="numElemCol">Array columns number</param>
        /// <param name="minVal">Minimal random value</param>
        /// <param name="maxVal">Maximum random value</param>
        /// <returns>Created array[,]</returns>
        public TwoDimentionalArray(int numElemRow, int numElemCol, int minVal, int maxVal)
        {
            array = new int[numElemRow, numElemCol];
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minVal, maxVal);
                }
            }
        }

        /// <summary>
        /// Construct loading array from file.
        /// </summary>
        /// <param name="fileName">Path to file</param>
        public TwoDimentionalArray(string fileName)
        {
            LoadArray(fileName);
        }

        /// <summary>
        /// Return sum elements of array.
        /// </summary>
        /// <returns>int</returns>
        public int SumElements()
        {
            int result = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    result += Array[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Return sum elements of array with numbers more than input number.
        /// </summary>
        /// <param name="num">Input number(more than it)</param>
        /// <returns>int</returns>
        public int SumElements(int num)
        {
            int result = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] > num)
                    {
                        result += Array[i, j];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Return array with two element with indexes of element maximal number.
        /// </summary>
        /// <returns>int[2]</returns>
        public int[] NumMaxElement()
        {
            int maxElem = Array[0, 0];
            int[] max = { 0, 0 };

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 1; j < Array.GetLength(1); j++)
                {
                    if (maxElem < Array[i, j])
                    {
                        maxElem = Array[i, j];
                        max[0] = i;
                        max[1] = j;
                    }
                }
            }
            return max;

        }

        /// <summary>
        /// Save current array in input file.
        /// </summary>
        /// <param name="fileName">Name of file</param>
        public void SaveArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(fileName);
                    sw.WriteLine(Array.GetLength(0));
                    sw.WriteLine(Array.GetLength(1));
                    for (int i = 0; i < Array.GetLength(0); i++)
                    {
                        for (int j = 0; j < Array.GetLength(1); j++)
                        {
                            sw.WriteLine(Array[i, j]);
                        }
                    }
                    sw.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                throw new FileNotFoundException("Файла с таким именем не существует в директории программы.");
            }
        }

        /// <summary>
        /// Load array from input file.
        /// </summary>
        /// <param name="fileName">Name of file</param>
        public void LoadArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    StreamReader sr = new StreamReader(fileName);
                    int row = int.Parse(sr.ReadLine());
                    int col = int.Parse(sr.ReadLine());
                    array = new int[row, col];
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            array[i, j] = int.Parse(sr.ReadLine());
                        }
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            else
            {
                throw new FileNotFoundException("Файла с таким именем не существует в директории программы.");
            }
        }
    }
}
