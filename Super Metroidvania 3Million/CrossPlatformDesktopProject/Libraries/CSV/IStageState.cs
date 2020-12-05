namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman
    public interface IStageState
    {
        void LeftDoor(Game1 game);
        void RightDoor(Game1 game);
        void TopLeftDoor(Game1 game);
        void TopRightDoor(Game1 game);
        void BottomLeftDoor(Game1 game);
        void BottomRightDoor(Game1 game);
    }
}
