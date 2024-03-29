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
            const string CommandAddEmployees = "1";
            const string CommandShowAllDossier = "2";
            const string CommandDeliteDossier = "3";
            const string CommandSearchBySurname = "4";
            const string CommandExit = "5";

            string[] employeesNames = new string[0];
            string[] employeesPosition = new string[0];
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandAddEmployees}: добавить досье");
                Console.WriteLine($"{CommandShowAllDossier}: вывести все досье");
                Console.WriteLine($"{CommandDeliteDossier}: удалить досье");
                Console.WriteLine($"{CommandSearchBySurname}: поиск по фамилии");
                Console.WriteLine($"{CommandExit}: выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddEmployees:
                        AddDossier(ref employeesNames, ref employeesPosition);
                        break;

                    case CommandShowAllDossier:
                        ShowAllEmployees(employeesNames, employeesPosition);
                        break;

                    case CommandDeliteDossier:
                        DeliteEmployee(ref employeesNames, ref employeesPosition);
                        break;

                    case CommandSearchBySurname:
                        SearchSurname(employeesNames, employeesPosition);
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

        static void AddDossier(ref string[] namesData, ref string[] position)
        {
            Console.WriteLine("введите Ф.И.О.");
            string input = Console.ReadLine();
            
            AddData(ref namesData, input);
            
            Console.WriteLine("введите должность");
            input = Console.ReadLine();
            
            AddData(ref position, input);
        }

        static void AddData(ref string[] data, string input)
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

        static void DeliteEmployee(ref string[] namesData, ref string[] position)
        {
             ShowAllEmployees(namesData, position);

             Console.Write("удаление сотрудника из базы данных. выберете номер:");
             string input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                if (index > data.Length || index <= 0)
                {
                    Console.WriteLine("неправильный ввод");
                }
                else
                {
                    DeleteData(ref namesData, index);
                    DeleteData(ref position, index);
                }
            }   
        }

        static void DeleteData(ref string[] data, int index)
        {
                  string[] tempBase = new string[data.Length - 1];

                  for (int i = 0; i < index - 1; i++)
                       tempBase[i] = data[i];

                  for (int i = index; i < data.Length; i++)
                       tempBase[i - 1] = data[i];

                     data = tempBase;
        }
        
        static void SearchSurname(string[] namesData, string[] position)
        {
            Console.Write("Введите фамилию: ");
            string input = Console.ReadLine();

            bool canFind = false;
        
            for (int i = 0; i < namesData.Length; i++)
            {
                string[] name = namesData[i].Split();

                if (name[0] == input)
                {
                    canFind = true;
                    Console.WriteLine($"сотрудник {i + 1}: {namesData[i]} - {position[i]}");
                }
            }

            if (canFind == false)
                Console.WriteLine("сотрудника с такой фамилией нет");
        }
    }
}
