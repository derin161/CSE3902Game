using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class PlayerSpriteFactory
    {
        //Player
        private List<Texture2D> playerTextures = new List<Texture2D>();
        private Texture2D rightIdle;
        private Texture2D leftIdle;
        private Texture2D rightWalk;
        private Texture2D leftWalk;
        private Texture2D rightCrouch;
        private Texture2D leftCrouch;
        private Texture2D jump;

        private Texture2D damaged_rightIdle;
        private Texture2D damaged_leftIdle;
        private Texture2D healthBar;
        //Fonts
        private List<SpriteFont> playerFonts = new List<SpriteFont>();
        private SpriteFont healthFont;

        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();
        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            //Player 
            rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdle");
            playerTextures.Add(rightIdle);
            leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdle");
            playerTextures.Add(leftIdle);
            rightWalk = content.Load<Texture2D>("PlayerSprites/SamusRightWalk");
            playerTextures.Add(rightWalk);
            leftWalk = content.Load<Texture2D>("PlayerSprites/SamusLeftWalk");
            playerTextures.Add(leftWalk);
            rightCrouch = content.Load<Texture2D>("PlayerSprites/RightMorph");
            playerTextures.Add(rightCrouch);
            leftCrouch = content.Load<Texture2D>("PlayerSprites/LeftMorph");
            playerTextures.Add(leftCrouch);
            jump = content.Load<Texture2D>("PlayerSprites/Jump");
            playerTextures.Add(jump);

            damaged_rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdleDamaged");
            playerTextures.Add(damaged_rightIdle);
            damaged_leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdleDamaged");
            playerTextures.Add(damaged_leftIdle);
            healthBar = content.Load<Texture2D>("HealthBar");
            playerTextures.Add(healthBar);

            //Fonts
            healthFont = content.Load<SpriteFont>("PlayerHealth");
            playerFonts.Add(healthFont);
        }

        public ISprite CreatePlayerSprite()
        {
            return (ISprite)new Player(playerTextures, playerFonts);
        }


    }
}
