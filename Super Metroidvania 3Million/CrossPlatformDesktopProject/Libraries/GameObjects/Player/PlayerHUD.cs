using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    //Author: Nyigel Spann
    public class PlayerHUD
    {
        private PlayerInventory inventory;
        private Samus samus;
        private Vector2 tanksPosition;
        private float tankSpacing = 20f;
        private Vector2 healthPosition;
        private Vector2 rocketPosition;
        private float xPos;
        //private ISprite rocketSprite = ProjectilesSpriteFactory.Instance.CreateMissileRocketSprite();

        public PlayerHUD(Samus samus)
        {
            inventory = samus.Inventory;
            this.samus = samus;
            xPos = samus.x - 10;
            tanksPosition = new Vector2(xPos, 66.0f);
            healthPosition = new Vector2(xPos, 80.0f);
            rocketPosition = new Vector2(xPos, 94.0f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(PlayerSpriteFactory.Instance.HealthFont, "EN -- " + inventory.CurrentEnergyLevel.ToString(), healthPosition, Color.LightSkyBlue);
            for (int i = 0; i < inventory.CurrentEnergyTanks; i++)
            { //Draws the energy tank boxes. 
                Vector2 pos = new Vector2(tanksPosition.X + tankSpacing * i, tanksPosition.Y);
                //These should prolly be stored in a collection rather than making a new one everytime but that's a later issue...
                if (i < inventory.CurrentEnergyTanksFilled)
                {
                    PlayerSpriteFactory.Instance.FullTankSprite(pos).Draw(spriteBatch);
                }
                else
                {
                    PlayerSpriteFactory.Instance.EmptyTankSprite(pos).Draw(spriteBatch);
                }
            }
            //Put a rocket symbol next to it in the future.
            spriteBatch.DrawString(PlayerSpriteFactory.Instance.HealthFont, "Rockets -- " + inventory.CurrentMissileRocketCount.ToString(), rocketPosition, Color.Red);

        }

        public void Update() {
            xPos = samus.x - 150;
            tanksPosition = new Vector2(xPos, 66.0f);
            healthPosition = new Vector2(xPos, 80.0f);
            rocketPosition = new Vector2(xPos, 94.0f);
        }

    }
}
