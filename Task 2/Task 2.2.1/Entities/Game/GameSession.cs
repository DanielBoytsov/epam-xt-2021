using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2._2._1.Buffs;
using Task_2._2._1.Strategies;

namespace Task_2._2._1
{
    public class GameSession
    {
        public int CountSteps { get; set; }
        public Map Map { get; set; }
        public Human Hero;
        public List<Creature> Creatures;
        public List<GameObject> GameObjects;

        public GameSession() : base() { }
        public GameSession(Map map, List<Creature> creatures, List<GameObject> gameObjects)
        {
            Map = map;
            Creatures = creatures;
            GameObjects = gameObjects;
        }

        public int GameStart()
        {
            Hero = (Human)Creatures.FirstOrDefault(c => c.Type == "Hero");
            if (Hero == null)
            {
                Console.WriteLine("Hero not created");
                return -1;
            }
            else
            {
                CountSteps = 0;
                int isGameFinished = 0;
                while (isGameFinished == 0)
                {
                    isGameFinished = GameStep();
                }
                return isGameFinished;
            }
        }
        public int GameStep()
        {
            CountSteps++;
            Print();
            int countBonuses = GameObjects.Count(c => c.Type == "Bonus");
            if (countBonuses == 0)
            {
                return 1;
            }
            else if (Hero.HealthPoints <= 0)
            {
                return -1;
            }
            else
            {
                if (!Hero.Buffs.Exists(c => c.State == "AcrossObstacles"))
                {
                    int countObstaclesNear = CalculateObstaclesNear(Hero);
                    if (countObstaclesNear == 4)
                    {
                        return -1;
                    }
                }
                Hero.Strategy.NextStep(Hero, this);
                for (int i = 0; i < Creatures.Count; i++)
                {
                    if (Creatures[i].Type == "Hero")
                    {
                        continue;
                    }
                    if (Creatures[i].HealthPoints <= 0)
                    {
                        Creatures.RemoveAt(i);
                        i--;
                        continue;
                    }
                    if (Creatures[i] is Enemy && !Creatures[i].Buffs.Exists(c => c.State == "AcrossObstacles"))
                    {
                        int countObstaclesNear = CalculateObstaclesNear(Creatures[i]);
                        if (countObstaclesNear == 4)
                        {
                            Creatures.Remove(Creatures[i]);
                            i--;
                            continue;
                        }
                    }
                    if (Creatures[i].Buffs.Count > 0)
                    {
                        for (int j = 0; j < Creatures[i].Buffs.Count; j++)
                        {
                            if (Creatures[i].Buffs[j].StepsCount == 0)
                            {
                                Creatures[i].Buffs.RemoveAt(j);
                                j--;
                                continue;
                            }
                            Creatures[i].Buffs[j].Conduct.NextStep(Creatures[i].Buffs[j]);
                        }
                    }
                    if (Creatures[i].Strategy != null)
                    {
                        Creatures[i].Strategy.NextStep(Creatures[i], this);
                    }
                }
                return 0;
            }
        }

        public void GenerateGame()
        {
            Map = new Map(15, 10);
            Creatures = new List<Creature>();
            GameObjects = new List<GameObject>();
            Creatures.Add(new Human(1, 1, "Richard", "Hero", 1, 100, 0, new HeroStrategy()));
            Creatures.Add(new Enemy(15, 10, "Alan", "Zombie", 2, 200, 30, 5, new ZombieStrategy()));
            GameObjects.Add(new GameObject(3, 3, "Rune", "Bonus", new Blueberry()));
            GameObjects.Add(new GameObject(7, 7, "Rune", "Bonus", new Raspberry()));
            GameObjects.Add(new GameObject(10, 10, "Rune", "Bonus", new Strawberry()));
            GameObjects.Add(new GameObject(5, 2, "Stone", "Obstacle"));
            GameObjects.Add(new GameObject(5, 5, "Stone", "Obstacle"));
            GameObjects.Add(new GameObject(8, 8, "Tree", "Obstacle"));
            GameObjects.Add(new GameObject(5, 1, "Stone", "Obstacle"));
            GameObjects.Add(new GameObject(3, 1, "Stone", "Obstacle"));
            GameObjects.Add(new GameObject(3, 2, "Tree", "Obstacle"));
            GameObjects.Add(new GameObject(4, 2, "Stone", "Obstacle"));
            GameObjects.Add(new GameObject(4, 1, "Tree", "Obstacle"));
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("HP: " + Hero.HealthPoints);
            for (int i = Map.Height; i > 0; i--)
            {
                for (int j = 1; j <= Map.Width; j++)
                {
                    if (Creatures.Exists(c => c.X == j && c.Y == i && c.Type == "Hero"))
                    {
                        Console.Write("P");
                    }
                    else if (Creatures.Exists(c => c.X == j && c.Y == i && c.Type == "Zombie"))
                    {
                        Console.Write("Z");
                    }
                    else if (GameObjects.Exists(c => c.X == j && c.Y == i && c.Type == "Obstacle"))
                    {
                        Console.Write("#");
                    }
                    else if (GameObjects.Exists(c => c.X == j && c.Y == i && c.Type == "Bonus"))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                Console.WriteLine();
            }
        }

        public int CalculateObstaclesNear(Entity entity)
        {
            int countObstaclesNear = GameObjects.Count(c => c.Type == "Obstacle" &&
                                                            c.X == entity.X && (c.Y == entity.Y + 1 || c.Y == entity.Y - 1) ||
                                                            c.Y == entity.Y && (c.X == entity.X + 1 || c.X == entity.X - 1));
            if (entity.X == Map.Width || entity.X == 1)
            {
                countObstaclesNear++;
            }
            if (entity.Y == Map.Height || entity.Y == 1)
            {
                countObstaclesNear++;
            }
            return countObstaclesNear;
        }
    }
}
