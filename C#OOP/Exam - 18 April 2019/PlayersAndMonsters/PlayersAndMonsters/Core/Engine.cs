﻿using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }


        public void Run()
        {
            while (true)
            {
                var line = this.reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                var commandParts = line.Split();
                var command = commandParts[0];

                var output = string.Empty;
                switch (command)
                {
                    case "AddPlayer":
                        var playerType = commandParts[1];
                        var username = commandParts[2];
                        output = this.managerController.AddPlayer(playerType, username);
                        break;
                    case "AddCard":
                        var cardType = commandParts[1];
                        var cardName = commandParts[2];
                        output = this.managerController.AddCard(cardType, cardName);
                        break;
                    case "AddPlayerCard":
                        var userName = commandParts[1];
                        cardName = commandParts[2];
                        output = this.managerController.AddPlayerCard(userName, cardName);
                        break;
                    case "Fight":
                        var attackUser = commandParts[1];
                        var enemyUser = commandParts[2];
                        output = this.managerController.Fight(attackUser, enemyUser);
                        break;
                    case "Report":
                        this.managerController.Report();
                        break;
                }

                this.writer.WriteLine(output);
            }
        }
    }
}