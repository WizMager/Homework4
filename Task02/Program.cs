using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayHelper;

namespace Task02
{
    /*2. а)Дописать класс для работы с одномерным массивом.
           Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, 
           которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, 
           умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов.
           В Main продемонстрировать работу класса.
     *   б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл. 
     */
    class Program
    {

        static void Main(string[] args)
        {
            MyArray myArray = new MyArray(5, 10, 2);
            ArrayHelper.Program.PrintIntArray(myArray.Array);
            Console.WriteLine($"Сумма элементов массива равна: {myArray.Sum()}.");
            Console.WriteLine();

            MyArray myArray1 = new MyArray(7, -5, 3);
            ArrayHelper.Program.PrintIntArray(myArray1.Array);
            myArray1.Inverse();
            Console.WriteLine($"Массив после замены знака элементов: {myArray1.PrintArray()}");
            Console.WriteLine();

            MyArray myArray2 = new MyArray(4, 0, 7);
            ArrayHelper.Program.PrintIntArray(myArray2.Array);
            myArray2.Multi(2);
            Console.WriteLine($"Массив с перемноженными элементами: {myArray2.PrintArray()}.");
            Console.WriteLine();

            MyArray myArray3 = new MyArray() { Array = ArrayHelper.Program.CreateIntArray(15, 1, 10) };
            ArrayHelper.Program.PrintIntArray(myArray3.Array);
            Console.WriteLine($"Число максимальных значений в массиве: {myArray3.MaxCount()}.");
            Console.WriteLine();

            var fileNameLoad = AppDomain.CurrentDomain.BaseDirectory + "ArrayListLoad.txt";
            MyArray myArray4 = new MyArray(fileNameLoad);
            ArrayHelper.Program.PrintIntArray(myArray4.Array);
            Console.WriteLine();

            var fileNameSave = AppDomain.CurrentDomain.BaseDirectory + "ArrayListSave.txt";
            MyArray myArray5 = new MyArray(fileNameSave);
            Console.WriteLine("Массив, который сейчас в файле.");
            ArrayHelper.Program.PrintIntArray(myArray5.Array);
            MyArray myArray6 = new MyArray() { Array = ArrayHelper.Program.CreateIntArray(8, -100, 100) };
            myArray6.SaveArray(fileNameSave);
            MyArray myArray7 = new MyArray(fileNameSave);
            Console.WriteLine("Новый массив, сохранённый в файле.");
            ArrayHelper.Program.PrintIntArray(myArray7.Array);
            Console.ReadKey();
        }

    }

    public class MyArray
    {
        private int[] array;

        public MyArray()
        {

        }

        #region Task2.2
        public MyArray(string fileName)
        {
            LoadArray(fileName);
        }
        #endregion

        #region Task2.1
        public MyArray(int dim, int startNum, int plusNum)
        {
            array = new int[dim];
            array[0] = startNum;
            for (int i = 1; i < dim; i++)
            {
                startNum += plusNum;
                array[i] = startNum;
            }
        }

        public int[] Array 
        { 
            get { return array; } 
            set { array = value; }
        }

        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        /// <summary>
        /// Return string with all element in array.
        /// </summary>
        /// <returns>Return string line of kind "1 2 3..."</returns>
        public string PrintArray()
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            return result;
        }

        /// <summary>
        /// Return int number of sum all array elements.
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        /// <summary>
        /// Return inverse sign of numbers in current array.
        /// </summary>
        /// <returns></returns>
        public void Inverse()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = -Array[i];
            }
        }

        /// <summary>
        /// Return multiplicated elements on input number.
        /// </summary>
        /// <param name="mult">Number on which multiplication array</param>
        /// <returns></returns>
        public void Multi(int mult)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] *= mult;
            }
        }

        /// <summary>
        /// Return int number of count maximum elements in array.
        /// </summary>
        /// <returns></returns>
        public int MaxCount()
        {
            int maxNumber = Array[0];
            int counterMaxNumber = 1;
            for (int i = 1; i < Array.Length; i++)
            {
                if(maxNumber < Array[i])
                {
                    maxNumber = Array[i];
                    counterMaxNumber = 1;
                } else if(maxNumber == Array[i])
                {
                    counterMaxNumber++;
                }
            }
            return counterMaxNumber;
        }
        #endregion

        #region Task2.2
        /// <summary>
        /// Save current array in input file.
        /// </summary>
        /// <param name="fileName">Name of file</param>
        public void SaveArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine(Array.Length);
                for (int i = 0; i < Array.Length; i++)
                {
                    sw.WriteLine(Array[i]);
                }
                sw.Close();
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
                StreamReader sr = new StreamReader(fileName);
                int dim = int.Parse(sr.ReadLine());
                array = new int[dim];
                for (int i = 0; i < dim; i++)
                {
                    array[i] = int.Parse(sr.ReadLine());
                }
                sr.Close();
            }
            else
            {
                throw new FileNotFoundException("Файла с таким именем не существует в директории программы.");
            }
        }
        #endregion

    }
}
