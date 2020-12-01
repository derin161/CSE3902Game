using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    //Author: Nyigel Spann
    public interface IItem : IGameObject
    {
        public void GiveToPlayer(PlayerInventory pInventory);
    }
}
