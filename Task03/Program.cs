using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    // 3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.Создайте структуру Account, содержащую Login и Password.
    class Program
    {
        #region Task3
        struct Account
        {
            public string login;
            public string password;
        }
        #endregion

        static bool Autorization(string login, string password)
        {
            Account accountVeryfy = LoadAccount();
            bool isAutorized = false;
            if (login == accountVeryfy.login && password == accountVeryfy.password)
                isAutorized = true;
            return isAutorized;
        }

        static void Veryfication()
        {
            int count = 3;
            string login, password;

            do
            {
                Console.WriteLine($"Введите логин и пароль. У вас есть {count} попыток.");
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();

                if (Autorization(login, password))
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели верный логин и пароль.");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели неверный логин и/или пароль.");
                    count--;
                }

            } while (count > 0);

            Console.ReadKey();
        }

        #region Task3
        static Account LoadAccount()
        {
            Account accountVeryfy;
            var fileName = AppDomain.CurrentDomain.BaseDirectory + "AccountsFile.txt";
            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(fileName);
                accountVeryfy.login = sr.ReadLine();
                accountVeryfy.password = sr.ReadLine();
                return accountVeryfy;
            }
            else
            {
                throw new FileNotFoundException("Данный файл не существует в директории программы.");
            }
        }
        #endregion

        static void Main(string[] args)
        {
            /// root, GeekBrains
            Veryfication();
        }


    }
}
