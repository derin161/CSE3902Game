namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public interface IStageState
    {
        void LeftDoor();
        void RightDoor();
        void TopLeftDoor();
        void TopRightDoor();
        void BottomLeftDoor();
        void BottomRightDoor();
        void FarBottomLeftDoor();
        void FarBottomRightDoor();
    }
}
