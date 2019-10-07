using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMenu
{
    static class Menu
    {
        public static void CharacterCreation(Character character)
        {
            ShowGreeting(character.Points);
            while (character.Points > 0)
            {
                DrawStatVisuals(character);

                string statToChange = GetStatToChange();

                for (int i = 0; i < character.Stats.Length; i++)
                {
                    if (statToChange == character.Stats[i].StatName.ToLower())
                    {
                        string operation = GetOperation();
                        int operandPoints = GetOperandPoints(operation);

                        if(operandPoints > character.Points)
                        {
                            Console.WriteLine("У вас недостаточно очков.");
                            Console.ReadKey();
                            break;
                        }

                        if (operation == "+") //повторяющийся код, можно исправить.
                        {
                            int overhead = operandPoints - (10 - character.Stats[i].StatValue);
                            overhead = overhead < 0 ? 0 : overhead;
                            operandPoints -= overhead;

                            character.Stats[i].StatValue = operation == "+" ? character.Stats[i].StatValue + operandPoints : character.Stats[i].StatValue - operandPoints;
                            character.Points = operation == "+" ? character.Points - operandPoints : character.Points + operandPoints;
                            break;
                        }

                        if (operation == "-")
                        {
                            int overhead = character.Stats[i].StatValue - operandPoints;
                            overhead = overhead < 0 ? overhead : 0;
                            operandPoints += overhead;

                            character.Stats[i].StatValue = operation == "+" ? character.Stats[i].StatValue + operandPoints : character.Stats[i].StatValue - operandPoints;
                            character.Points = operation == "+" ? character.Points - operandPoints : character.Points + operandPoints;
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Данная операция либо не подходит, либо не существует вовсе. Попробуйте снова.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }            
            }

            DrawStatVisuals(character);
            character.Age = GetAge(); 
            DrawStatVisuals(character);
            Console.ReadKey();
        }

        // Вывод приветствия и текущего кол-ва очков.
        private static void ShowGreeting(int points)
        {
            Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
            Console.WriteLine($"У вас есть {points} очков, которые вы можете распределить по умениям");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
        }

        // Вывод текущего состояния характеристик.
        private static void DrawStatVisuals(Character character)
        {
            Console.Clear();
            PrepareStatVisuals(character.Stats);

            Console.WriteLine("Поинтов - {0}", character.Points);
            Console.WriteLine("Возраст - {0}", character.Age);
            foreach (Stat stat in character.Stats)
            {
                Console.WriteLine($"{stat.StatName} - {stat.StatVisual}");
            }
        }

        // Помогает методу выше подготовить визуализацию характеристик.
        private static void PrepareStatVisuals(Stat[] stats)
        {
            foreach (Stat stat in stats)
            {
                stat.StatVisual = string.Empty;
                stat.StatVisual = stat.StatVisual.PadLeft(stat.StatValue, '#').PadRight(10, '_');
            }
        }

        // Ввод изменяемой характеристики.
        private static string GetStatToChange()
        {
            Console.WriteLine("Какую характеристику вы хотите изменить?");
            return Console.ReadLine().Trim().ToLower();
        }

        // Ввод операции.
        private static string GetOperation()
        {
            Console.WriteLine(@"Что вы хотите сделать? +\-");
            return Console.ReadLine().Trim();
        }

        // Ввод значения второго операнда.
        private static int GetOperandPoints(string operation)
        {
            Console.WriteLine(@"Количество поинтов которые следует {0}", operation == "+" ? "прибавить" : "отнять");

            string operandPointsRaw = string.Empty;
            int operandPoints = 0;

            do
            {
                operandPointsRaw = Console.ReadLine();
            }
            while (!int.TryParse(operandPointsRaw, out operandPoints));

            return operandPoints;
        }

        // Ввод возраста.
        private static int GetAge()
        {
            Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
            string ageRaw = string.Empty;
            int age;
            ageRaw = Console.ReadLine();           
            if(int.TryParse(ageRaw, out age))
                age = Convert.ToInt32(ageRaw);

            return age;
        }
    }
}
