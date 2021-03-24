using System;
using System.Collections.Generic;

namespace Task_2._2._1
{
    enum State
    {
        AcrossObstacles,
        //Invisibility,
        //Heal
    }
    

    class Program
    {
        static void Main(string[] args)
            {
                char key;
                while (true)
                {
                    Console.WriteLine(@"New game: press n ");
                    key = Convert.ToChar(Console.ReadKey().KeyChar);
                    if (key == 'n')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" Invalid key (right key: n)");
                    }
                }

                GameSession gameSession = new GameSession();
                switch (key)
                {
                    case 'n':
                        gameSession.GenerateGame();
                        break;
                }

                int points;
                int IsGameFinished = gameSession.GameStart();
                if (IsGameFinished == 1)
                {
                    points = 10000 + gameSession.Hero.HealthPoints * 100 + 50000 / gameSession.CountSteps;
                    Console.WriteLine("You win!! " +
                                      "\nYour score: " + points);

                }
                else
                {
                    points = 30000 / gameSession.CountSteps;
                    Console.WriteLine("You lose!! " +
                                      "\nYour score: " + points);
                }

                Console.ReadLine();
        }

    }
}

