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
            const string CommandToAddDossier = "1";
            const string CommandToShowAllDossier = "2";
            const string CommandToDeliteDossier = "3";
            const string CommandToSearchByLastName = "4";
            const string CommandToExit = "5";

            string[] namesDataBase = new string[0];
            string[] jobDataBase = new string[0];
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandToAddDossier}: добавить досье");
                Console.WriteLine($"{CommandToShowAllDossier}: вывести все досье");
                Console.WriteLine($"{CommandToDeliteDossier}: удалить досье");
                Console.WriteLine($"{CommandToSearchByLastName}: поиск по фамилии");
                Console.WriteLine($"{CommandToExit}: выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("введите фамилию");
                        userInput = Console.ReadLine();

                        AddDossier(ref namesDataBase, userInput);

                        Console.WriteLine("введите должность");
                        userInput = Console.ReadLine();

                        AddDossier(ref jobDataBase, userInput);
                        break;

                    case "2":
                        ShowAllDossier(namesDataBase, jobDataBase);
                        break;

                    case "3":
                        ShowAllDossier(namesDataBase, jobDataBase);

                        Console.Write("удаление сотрудника из базы данных. выберете номер:");
                        userInput = Console.ReadLine();

                        DeliteDossier(ref namesDataBase, userInput);
                        DeliteDossier(ref jobDataBase, userInput);
                        break;

                    case "4":
                        Console.WriteLine("Введите фамилию: ");
                        userInput = Console.ReadLine();

                        SearchSurname(namesDataBase, jobDataBase, userInput);
                        break;

                    case "5":
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

        static void AddDossier(ref string[] dataBase, string input)
        {
            string[] tempDataBase = new string[dataBase.Length + 1];

            for (int i = 0; i < dataBase.Length; i++)
                tempDataBase[i] = dataBase[i];

            tempDataBase[tempDataBase.Length - 1] = input;
            dataBase = tempDataBase;
        }

        static void ShowAllDossier(string[] nameBase, string[] jobBase)
        {
            Console.WriteLine("список сотрудников:");

            for (int i = 0; i < nameBase.Length; i++)
                Console.WriteLine($"{i + 1}: {nameBase[i]} - {jobBase[i]}");
        }

        static void DeliteDossier(ref string[] dataBase, string input)
        {
            string[] tempBase = new string[dataBase.Length - 1];

            if (int.TryParse(input, out int index))

            for (int i = 0; i < index - 1; i++)
                    tempBase[i] = dataBase[i];

            for (int i = index; i < dataBase.Length; i++)
                tempBase[i - 1] = dataBase[i];

            dataBase = tempBase;
        }

        static void SearchSurname(string[] nameBase, string[] jobBase, string input)
        {
            for (int i = 0; i < nameBase.Length; i++)
                if(input.ToLower() == nameBase[i].ToLower())
                    Console.WriteLine($"сотрудник {i + 1}: {nameBase[i]} - {jobBase[i]}");
        }
    }
}
