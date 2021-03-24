using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1.Strategies
{
    public class HeroStrategy : IStrategy
    {
        public void NextStep(Creature creature, GameSession gameSession)
        {
            if (creature.Buffs.Count > 0)
            {
                for (int j = 0; j < creature.Buffs.Count; j++)
                {
                    if (creature.Buffs[j].StepsCount == 0)
                    {
                        creature.Buffs.RemoveAt(j);
                        j--;
                        continue;
                    }

                    creature.Buffs[j].Conduct.NextStep(creature.Buffs[j]);
                }
            }

            for (int i = 0; i < creature.MoveSpeed; i++)
            {
                char key;
                while (true)
                {
                    Console.WriteLine("Press 'c' to save game");
                    key = Convert.ToChar(Console.ReadKey().KeyChar);
                    if (key == 'w' || key == 's' || key == 'a' || key == 'd' || key == 'c')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" Invalid key (right key: w a s d c)");
                    }
                }

                Move(key, creature, gameSession);
                gameSession.Print();
            }
        }

        public void Move(char key, Creature creature, GameSession gameSession)
        {
            switch (key)
            {
                case 'w':
                    if (creature.Y + 1 > gameSession.Map.Height)
                    {
                        creature.HealthPoints--;
                    }
                    else
                    {
                        if (creature.Buffs.Exists(c => c.State == "AcrossObstacles"))
                        {
                            creature.Y++;
                        }
                        else
                        {
                            if (gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y + 1 &&
                                                                    c.X == creature.X))
                            {
                                creature.HealthPoints--;
                            }
                            else
                            {
                                creature.Y++;
                            }
                        }
                    }

                    break;
                case 's':
                    if (creature.Y - 1 < 1)
                    {
                        creature.HealthPoints--;
                    }
                    else
                    {
                        if (creature.Buffs.Exists(c => c.State == "AcrossObstacles"))
                        {
                            creature.Y--;
                        }
                        else
                        {
                            if (gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y - 1 &&
                                                                    c.X == creature.X))
                            {
                                creature.HealthPoints--;
                            }
                            else
                            {
                                creature.Y--;
                            }
                        }
                    }

                    break;
                case 'a':
                    if (creature.X - 1 < 1)
                    {
                        creature.HealthPoints--;
                    }
                    else
                    {
                        if (creature.Buffs.Exists(c => c.State == "AcrossObstacles"))
                        {
                            creature.X--;
                        }
                        else
                        {
                            if (gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y &&
                                                                    c.X == creature.X - 1))
                            {
                                creature.HealthPoints--;
                            }
                            else
                            {
                                creature.X--;
                            }
                        }
                    }

                    break;
                case 'd':
                    if (creature.X + 1 > gameSession.Map.Width)
                    {
                        creature.HealthPoints--;
                    }
                    else
                    {
                        if (creature.Buffs.Exists(c => c.State == "AcrossObstacles"))
                        {
                            creature.X++;
                        }
                        else
                        {
                            if (gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y &&
                                                                    c.X == creature.X + 1))
                            {
                                creature.HealthPoints--;
                            }
                            else
                            {
                                creature.X++;
                            }
                        }
                    }

                    break;
            }

            GameObject bonus =
                gameSession.GameObjects.FirstOrDefault(c =>
                    c.Type == "Bonus" && c.X == creature.X && c.Y == creature.Y);
            if (bonus != null)
            {
                bonus.Conduct.CharacterStepOn(creature);
                gameSession.GameObjects.Remove(bonus);
            }
        }
    }
}
