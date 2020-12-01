using SuperMetroidvania5Million.Libraries.Sprite.Player;

namespace SuperMetroidvania5Million.Libraries.Sprite.Items
{
    //Author: Nyigel Spann
    public interface IItem : IGameObject
    {
        public void GiveToPlayer(PlayerInventory pInventory);
    }
}
