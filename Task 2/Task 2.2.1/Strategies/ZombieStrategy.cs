using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Task_2._2._1.Buffs;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1.Strategies
{
    public class ZombieStrategy : IEnemy
    {
        private static Random rnd = new Random();

        public void NextStep(Creature creature, GameSession gameSession)
        {
            if (creature is Enemy enemy)
            {
                NextStep(enemy, gameSession);
            }
            else
            {
                for (int i = 0; i < creature.MoveSpeed; i++)
                {
                    Move(creature, gameSession);
                }
            }
        }
        public void NextStep(Enemy enemy, GameSession gameSession)
        {
            bool isAttacked = false;
            for (int i = 0; i < enemy.MoveSpeed; i++)
            {
                if (isAttacked == true)
                {
                    break;
                }
                List<Creature> heroes = gameSession.Creatures.Where(c => c.Type == "Hero" &&
                    c.X >= enemy.X - enemy.VisionArea && c.X <= enemy.X + enemy.VisionArea &&
                    c.Y >= enemy.Y - enemy.VisionArea && c.Y <= enemy.Y + enemy.VisionArea).ToList();
                if (heroes.Count != 0)
                {
                    isAttacked = MeetHero(enemy, (Human)GetNearest(enemy, heroes), gameSession);
                }
                else
                {
                    List<GameObject> bonuses = gameSession.GameObjects.Where(c => c.Type == "Bonus" &&
                        (c.Conduct is Strawberry || c.Conduct is Raspberry) &&
                        c.X >= enemy.X - enemy.VisionArea && c.X <= enemy.X + enemy.VisionArea &&
                        c.Y >= enemy.Y - enemy.VisionArea && c.Y <= enemy.Y + enemy.VisionArea).ToList();
                    if (bonuses.Count != 0)
                    {
                        MeetObject(enemy, (GameObject)GetNearest(enemy, bonuses), gameSession);
                    }
                    else
                    {
                        Move(enemy, gameSession);
                    }
                }
            }
        }
        public bool MeetHero(Enemy enemy, Human hero, GameSession gameSession)
        {
            if (enemy.X == hero.X && enemy.Y == hero.Y)
            {
                hero.HealthPoints -= enemy.Attack;
                return true;
            }
            else
            {
                MoveTo(enemy, hero, gameSession);
                if (enemy.X == hero.X && enemy.Y == hero.Y)
                {
                    hero.HealthPoints -= enemy.Attack;
                    return true;
                }
                return false;
            }
        }

        public void MeetObject(Enemy enemy, GameObject bonus, GameSession gameSession)
        {
            if (enemy.X == bonus.X && enemy.Y == bonus.Y)
            {
                bonus.Conduct.CharacterStepOn(enemy);
                gameSession.GameObjects.Remove(bonus);
            }
            else
            {
                MoveTo(enemy, bonus, gameSession);
                if (enemy.X == bonus.X && enemy.Y == bonus.Y)
                {
                    bonus.Conduct.CharacterStepOn(enemy);
                    gameSession.GameObjects.Remove(bonus);
                }
            }
        }

        public void Move(Creature creature, GameSession gameSession)
        {
            int direction;
            bool isContinue = true;
            while (isContinue)
            {
                direction = rnd.Next(1, 5);
                if (creature.Buffs.Exists(c => c.State == "AcrossObstacles"))
                {
                    switch (direction)
                    {
                        case 1:
                            if (creature.Y + 1 <= gameSession.Map.Height)
                            {
                                creature.Y++;
                                isContinue = false;
                            }
                            break;
                        case 2:
                            if (creature.X + 1 <= gameSession.Map.Width)
                            {
                                creature.X++;
                                isContinue = false;
                            }
                            break;
                        case 3:
                            if (creature.Y - 1 > 0)
                            {
                                creature.Y--;
                                isContinue = false;
                            }
                            break;
                        case 4:
                            if (creature.X - 1 > 0)
                            {
                                creature.X--;
                                isContinue = false;
                            }
                            break;
                    }
                }
                else
                {
                    switch (direction)
                    {
                        case 1:
                            if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y + 1 &&
                                c.X == creature.X) && creature.Y + 1 <= gameSession.Map.Height)
                            {
                                creature.Y++;
                                isContinue = false;
                            }
                            break;
                        case 2:
                            if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y &&
                                c.X == creature.X + 1) && creature.X + 1 <= gameSession.Map.Width)
                            {
                                creature.X++;
                                isContinue = false;
                            }
                            break;
                        case 3:
                            if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y - 1 &&
                                c.X == creature.X) && creature.Y - 1 > 0)
                            {
                                creature.Y--;
                                isContinue = false;
                            }
                            break;
                        case 4:
                            if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.Y == creature.Y &&
                                c.X == creature.X - 1) && creature.X - 1 > 0)
                            {
                                creature.X--;
                                isContinue = false;
                            }
                            break;
                    }
                }
            }
        }

        public void MoveTo(Creature creature, Entity entity, GameSession gameSession)
        {
            if (creature.Buffs.Exists(c => c.State == "AcrossObstacles"))
            {
                if (creature.X == entity.X)
                {
                    if (entity.Y > creature.Y)
                    {
                        creature.Y++;
                    }
                    else
                    {
                        creature.Y--;
                    }
                }
                else if (creature.X < entity.X)
                {
                    creature.X++;
                }
                else
                {
                    creature.X--;
                }
            }
            else
            {
                if (creature.X == entity.X)
                {
                    if (entity.Y > creature.Y)
                    {
                        if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y + 1))
                        {
                            creature.Y++;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X + 1 &&
                            c.Y == creature.Y))
                        {
                            creature.X++;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X - 1 &&
                            c.Y == creature.Y))
                        {
                            creature.X--;
                        }
                        else
                        {
                            creature.Y--;
                        }
                    }
                    else
                    {
                        if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y - 1))
                        {
                            creature.Y--;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X + 1 &&
                            c.Y == creature.Y))
                        {
                            creature.X++;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X - 1 &&
                            c.Y == creature.Y))
                        {
                            creature.X--;
                        }
                        else
                        {
                            creature.Y++;
                        }
                    }
                }
                else if (creature.X < entity.X)
                {
                    if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X + 1 &&
                            c.Y == creature.Y))
                    {
                        creature.X++;
                    }
                    else if (creature.Y < entity.Y)
                    {
                        if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y + 1))
                        {
                            creature.Y++;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y - 1))
                        {
                            creature.Y--;
                        }
                        else
                        {
                            creature.X--;
                        }
                    }
                    else
                    {
                        if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y - 1))
                        {
                            creature.Y--;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y + 1))
                        {
                            creature.Y++;
                        }
                        else
                        {
                            creature.X--;
                        }
                    }
                }
                else
                {
                    if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X - 1 &&
                            c.Y == creature.Y))
                    {
                        creature.X--;
                    }
                    else if (creature.Y < entity.Y)
                    {
                        if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y + 1))
                        {
                            creature.Y++;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y - 1))
                        {
                            creature.Y--;
                        }
                        else
                        {
                            creature.X++;
                        }
                    }
                    else
                    {
                        if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y - 1))
                        {
                            creature.Y--;
                        }
                        else if (!gameSession.GameObjects.Exists(c => c.Type == "Obstacle" && c.X == creature.X &&
                            c.Y == creature.Y + 1))
                        {
                            creature.Y++;
                        }
                        else
                        {
                            creature.X++;
                        }
                    }
                }
            }
        }

        public T GetNearest<T>(Enemy enemy, List<T> list) where T : Entity
        {
            int temp;
            int index = 0;
            int minDifference = Math.Abs(list[0].X - enemy.X) + Math.Abs(list[0].Y - enemy.Y);
            for (int i = 1; i < list.Count; i++)
            {
                temp = Math.Abs(list[i].X - enemy.X) + Math.Abs(list[i].Y - enemy.Y);
                if (temp < minDifference)
                {
                    minDifference = temp;
                    index = i;
                }
            }
            return list[index];
        }
    }
}
