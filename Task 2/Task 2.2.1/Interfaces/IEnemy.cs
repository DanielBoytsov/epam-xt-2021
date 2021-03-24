using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._1.Interfaces
{
    public interface IEnemy : IStrategy
    {
        bool MeetHero(Enemy enemy, Human human, GameSession gameSession);
        void NextStep(Enemy enemy, GameSession gameSession);
    }
}
