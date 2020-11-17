namespace CrossPlatformDesktopProject.Libraries.CSV
{
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
