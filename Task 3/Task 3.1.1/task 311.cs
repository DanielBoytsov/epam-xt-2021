using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input here number of persons");
            int.TryParse(Console.ReadLine(), out int numberPersons);
            Console.WriteLine("Enter the number of people to be crossed out each round:");
            int.TryParse(Console.ReadLine(), out int strikeNumber);

            LinkedList<int> listNumbers = new LinkedList<int>(CreateGameArray(numberPersons));
            var currentPerson = listNumbers.First;
            int tmp = 0;
            int roundNumber = 0;

            if (numberPersons < strikeNumber)
            {
                Console.WriteLine("You can't do this");
            }
            else
            {
                while (listNumbers.Count >= strikeNumber)
                {
                    while (tmp < strikeNumber - 2)
                    {
                        tmp++;
                        currentPerson = currentPerson.Next ?? listNumbers.First;
                    }
                    tmp = 0;
                    listNumbers.Remove(currentPerson.Next ?? listNumbers.First);
                    currentPerson = currentPerson.Next ?? listNumbers.First;
                    foreach (var item in listNumbers)
                    {
                        Console.Write(item + " ");
                    }
                    roundNumber++;
                    Console.WriteLine($" Round {roundNumber}. The man is crossed out. {listNumbers.Count} people left.");
                }

                Console.WriteLine($"The game is over. It is impossible to cross out more people.");
            }
        }
        public static int[] CreateGameArray(int numberPersons)
        {
            var gameArray = new int[numberPersons];
            for (int i = 0; i < numberPersons; i++)
            {
                gameArray[i] = i + 1;
            }
            return gameArray;
        }


    }
   
}
