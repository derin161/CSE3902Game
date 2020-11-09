using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

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
        private Texture2D rightAim;
        private Texture2D leftAim;

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
            morph = content.Load<Texture2D>("PlayerSprites/SamusRightIdle");
            jumpRight = content.Load<Texture2D>("PlayerSprites/JumpRightSamusSprite");
            jumpLeft = content.Load<Texture2D>("PlayerSprites/JumpLeftSamusSprite");
            damaged_rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdleDamaged");
            damaged_leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdleDamaged");
            healthBar = content.Load<Texture2D>("HealthBar");
            rightAim = content.Load<Texture2D>("PlayerSprites/SamusRightAim");
            leftAim = content.Load<Texture2D>("PlayerSprites/SamusLeftAim");

            //Fonts
            healthFont = content.Load<SpriteFont>("PlayerHealth");
        }

        public RightIdleSamusSprite RightIdleSprite(Samus s)
        {
            return new RightIdleSamusSprite(rightIdle, s);
        }

        public LeftIdleSamusSprite LeftIdleSprite(Samus s)
        {
            return new LeftIdleSamusSprite(leftIdle, s);
        }

        public RightWalkSamusSprite RightWalkSprite(Samus s)
        {
            return new RightWalkSamusSprite(rightWalk, s);
        }

        public LeftWalkSamusSprite LeftWalkSprite(Samus s)
        {
            return new LeftWalkSamusSprite(leftWalk, s);
        }

        public MorphSamusSprite MorphSprite(Samus s)
        {
            return new MorphSamusSprite(morph, s);
        }

        public JumpRightSamusSprite JumpRightSprite(Samus s)
        {
            return new JumpRightSamusSprite(jumpRight, s);
        }

        public JumpLeftSamusSprite JumpLeftSprite(Samus s)
        {
            return new JumpLeftSamusSprite(jumpLeft, s);
        }

        public RightAimUpSamusSprite RightAimUpSprite(Samus s){
            return new RightAimUpSamusSprite(rightAim, s);
        }

        public LeftAimUpSamusSprite LeftAimUpSprite(Samus s){
            return new LeftAimUpSamusSprite(leftAim, s);
        }

        public Samus CreatePlayerSprite(Vector2 l, Game1 g, GameTime g2)
        {
            return new Samus(l, g, g2);
        }

        public SpriteFont HealthFont(){
            return healthFont;
        }
    }
}
