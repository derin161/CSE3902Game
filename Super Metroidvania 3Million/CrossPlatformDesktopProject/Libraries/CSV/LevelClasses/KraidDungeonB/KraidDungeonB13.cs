using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB13 : IStageState
    {
        public KraidDungeonB13()
        {
            
        }

        public void LeftDoor(Game1 game)
        {
           
        }
        public void RightDoor(Game1 game)
        {

        }
        public void TopLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB12.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB12();
            game.SetCamera(false);
        }
        public void TopRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void BottomLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void BottomRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
    }
}
