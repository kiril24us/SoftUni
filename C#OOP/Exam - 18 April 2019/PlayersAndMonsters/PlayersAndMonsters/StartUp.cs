using System;

namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPlayerRepository playerRepository = new PlayerRepository();
            IPlayerFactory playerFactory = new PlayerFactory();
            ICardRepository cardRepository = new CardRepository();
            ICardFactory cardFactory = new CardFactory();
            IBattleField battleField = new BattleField();


            IManagerController managerController = new ManagerController(playerRepository,playerFactory,cardFactory,cardRepository,battleField);
            IEngine engine = new Engine(reader, writer, managerController);
            engine.Run();
        }
    }
}