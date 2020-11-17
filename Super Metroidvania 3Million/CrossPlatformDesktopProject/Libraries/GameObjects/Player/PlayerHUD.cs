using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    //Author: Nyigel Spann
    public class PlayerHUD
    {
        private PlayerInventory inventory;
        private Vector2 tanksPosition = new Vector2(32.0f, 66.0f);
        private float tankSpacing = 20f;
        private Vector2 healthPosition = new Vector2(32.0f, 80.0f);
        //private ISprite rocketSprite = ProjectilesSpriteFactory.Instance.CreateMissileRocketSprite();

        public PlayerHUD(PlayerInventory inv) {
            inventory = inv;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(PlayerSpriteFactory.Instance.HealthFont, "EN -- " + inventory.CurrentEnergyLevel.ToString(), healthPosition, Color.LightSkyBlue);
            for (int i = 0; i < inventory.CurrentEnergyTanks; i++) { //Draws the energy tank boxes. 
                Vector2 pos = new Vector2(tanksPosition.X + tankSpacing * i, tanksPosition.Y);
                //These should prolly be stored in a collection rather than making a new one everytime but that's a later issue...
                if (i < inventory.CurrentEnergyTanksFilled) {
                    PlayerSpriteFactory.Instance.FullTankSprite(pos).Draw(spriteBatch);
                }
                else {
                    PlayerSpriteFactory.Instance.EmptyTankSprite(pos).Draw(spriteBatch);
                }
            }

        }

    }
}
