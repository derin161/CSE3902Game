namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman
    public interface IStageState
    {
        void LeftDoor(Game1 game);
        void RightDoor(Game1 game);
        void TopLeftDoor();
        void TopRightDoor();
        void BottomLeftDoor();
        void BottomRightDoor();
        void FarBottomLeftDoor();
        void FarBottomRightDoor();
    }
}
