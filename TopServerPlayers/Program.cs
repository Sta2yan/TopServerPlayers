using System;
using System.Collections.Generic;
using System.Linq;

namespace TopServerPlayers
{
    class Progam
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Player> players = new List<Player>();
            int maximumPlayers = 10;
            int maximumLevel = 101;
            int minimumLevel = 1;
            int maximumStrength = 1000;
            int minimumStrength = 10;
            int topThree = 3;


            for (int i = 0; i < maximumPlayers; i++)
            {
                players.Add(new Player($"Player_{i + 1}", random.Next(minimumLevel, maximumLevel), random.Next(minimumStrength, maximumStrength)));
            }

            var filteredPlayersByTopLevel = players.OrderByDescending(player => player.Level).Take(topThree);

            Console.WriteLine("Топ - 3 игрока по уровню прокачки:");

            foreach (var player in filteredPlayersByTopLevel)
            {
                player.ShowInfo();
            }

            Console.WriteLine("---------------------------------------------------");

            var filteredPlayersByTopStrength = players.OrderByDescending(player => player.Strength).Take(topThree);

            Console.WriteLine("Топ - 3 игрока по уровню силы:");

            foreach (var player in filteredPlayersByTopStrength)
            {
                player.ShowInfo();
            }
        }
    }

    class Player
    {
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Player(string nickname, int level, int strength)
        {
            Nickname = nickname;
            Level = level;
            Strength = strength;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Игрок - {Nickname} | Уровень - {Level} | Сила - {Strength}");
        }
    }
}