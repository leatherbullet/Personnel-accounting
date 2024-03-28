using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кадровый_учет
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAdd = "1";
            const string CommandShowAll = "2";
            const string CommandDelite = "3";
            const string CommandSearch = "4";
            const string CommandExit = "5";

            string[] employeesNames = new string[0];
            string[] employeesPosition = new string[0];
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandAdd}: добавить досье");
                Console.WriteLine($"{CommandShowAll}: вывести все досье");
                Console.WriteLine($"{CommandDelite}: удалить досье");
                Console.WriteLine($"{CommandSearch}: поиск по фамилии");
                Console.WriteLine($"{CommandExit}: выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAdd:
                        AddDossier(ref employeesNames, ref employeesPosition, userInput);
                        break;

                    case CommandShowAll:
                        ShowAllEmployees(employeesNames, employeesPosition);
                        break;

                    case CommandDelite:
                        DeliteEmployee(ref employeesNames, ref employeesPosition, userInput);
                        break;

                    case CommandSearch:
                        SearchSurname(employeesNames, employeesPosition, userInput);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("неверный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(ref string[] dataBase, ref string[] position, string input)
        {
            Console.WriteLine("введите Ф.И.О.");
            input = Console.ReadLine();
            
            Console.WriteLine("введите должность");
            input = Console.ReadLine();

            AddEmployee(ref namesData, input);
            AddEmployee(ref position, input)
        }

        static void AddEmployee(ref string[] data, string input)
        {
            string[] tempData = new string[data.Length + 1];

            for (int i = 0; i < data.Length; i++)
                    tempData[i] = data[i];

            tempData[tempData.Length - 1] = input;
            data = tempData;
        }

        static void ShowAllEmployees(string[] namesData, string[] position)
        {
            Console.WriteLine("список сотрудников:");

            for (int i = 0; i < namesData.Length; i++)
                Console.WriteLine($"{i + 1}: {namesData[i]} - {position[i]}");
        }

        static void DeliteEmployee(ref string[] namesData, ref string[] position, string input)
        {
             ShowAllEmployees(namesData, position);

             Console.Write("удаление сотрудника из базы данных. выберете номер:");
             input = Console.ReadLine();

             RemoveEmployee(ref namesData, input);
             RemoveEmployee(ref position, input);
        }

        static void RemoveEmployee(ref string[] data, string input)
        {
            if (int.TryParse(input, out int index))
                if (index > data.Length || index <= 0)
                   Console.WriteLine("неправильный ввод");
               else
              {
                string[] tempBase = new string[data.Length - 1];

                for (int i = 0; i < index - 1; i++)
                       tempBase[i] = data[i];

                for (int i = index; i < data.Length; i++)
                tempBase[i - 1] = data[i];

                data = tempBase;
               }
        }
        
        static void SearchSurname(string[] namesData, string[] position, string input)
        {
            Console.Write("Введите фамилию: ");
            input = Console.ReadLine();

            char empty = ' ';
            
            for (int i = 0; i < namesData.Length; i++)
            {
                string[] name = namesData[i].Split(empty);

                if (name[0] == input)
                    Console.WriteLine($"сотрудник {i + 1}: {namesData[i]} - {position[i]}");
            }
        }
    }
}
