using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    /*Author: Shyamal Shah*/
    class PlayerSpriteFactory
    {
        //Player
        private Texture2D rightIdle;
        private Texture2D leftIdle;
        private Texture2D rightWalk;
        private Texture2D leftWalk;
        private Texture2D morph;
        private Texture2D jumpRight;
        private Texture2D jumpLeft;

        private Texture2D damaged_rightIdle;
        private Texture2D damaged_leftIdle;
        private Texture2D healthBar;
        //Fonts
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
            leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdle");
            rightWalk = content.Load<Texture2D>("PlayerSprites/SamusRightWalk");
            leftWalk = content.Load<Texture2D>("PlayerSprites/SamusLeftWalk");
            morph = content.Load<Texture2D>("PlayerSprites/RightMorph");
            jumpRight = content.Load<Texture2D>("PlayerSprites/JumpRightSamusSprite");
            jumpLeft = content.Load<Texture2D>("PlayerSprites/JumpLeftSamusSprite");
            damaged_rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdleDamaged");
            damaged_leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdleDamaged");
            healthBar = content.Load<Texture2D>("HealthBar");

            //Fonts
            healthFont = content.Load<SpriteFont>("PlayerHealth");
        }

        public ISprite RightIdleSprite(Samus s)
        {
            return RightIdleSamusSprite(rightIdle, s);
        }

        public ISprite LeftIdleSprite(Samus s)
        {
            return LeftIdleSamusSprite(leftIdle, s);
        }

        public ISprite RightWalkSprite(Samus s)
        {
            return RightWalkSamusSprite(rightWalk, s);
        }

        public ISprite LeftWalkSprite(Samus s)
        {
            return LeftWalkSamusSprite(leftWalk, s);
        }

        public ISprite MorphSprite(Samus s)
        {
            return MorphSamusSprite(morph, s);
        }

        public ISprite JumpRightSprite(Samus s, bool right, int frame, int y)
        {
            return JumpRightSamusSprite(jumpRight, s, right, frame, y);
        }

        public ISprite JumpLeftSprite(Samus s, bool left, int frame, int y)
        {
            return JumpLeftSamusSprite(jumpLeft, s, left, frame, y);
        }
    }
}
