using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        private Texture2D rightMorphAnimation;
        private Texture2D leftMorphAnimation;
        private Texture2D movingMorph;
        private Texture2D jumpRight;
        private Texture2D jumpLeft;
        private Texture2D rightAim;
        private Texture2D leftAim;

        private Texture2D damaged_rightIdle;
        private Texture2D damaged_leftIdle;
        private Texture2D healthBar;
        //Fonts
        public SpriteFont HealthFont { get; private set; }
        private Texture2D tankIcon;

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
            rightMorphAnimation = content.Load<Texture2D>("PlayerSprites/RightMorph");
            leftMorphAnimation = content.Load<Texture2D>("PlayerSprites/LeftMorph");
            movingMorph = content.Load<Texture2D>("PlayerSprites/MorphDone");
            jumpRight = content.Load<Texture2D>("PlayerSprites/JumpRightSamusSprite");
            jumpLeft = content.Load<Texture2D>("PlayerSprites/JumpLeftSamusSprite");
            damaged_rightIdle = content.Load<Texture2D>("PlayerSprites/SamusRightIdleDamaged");
            damaged_leftIdle = content.Load<Texture2D>("PlayerSprites/SamusLeftIdleDamaged");
            healthBar = content.Load<Texture2D>("HealthBar");
            rightAim = content.Load<Texture2D>("PlayerSprites/SamusRightAim");
            leftAim = content.Load<Texture2D>("PlayerSprites/SamusLeftAim");
            tankIcon = content.Load<Texture2D>("TankIcon");

            //Fonts
            HealthFont = content.Load<SpriteFont>("PlayerHealth");
        }

        public ISprite RightIdleSprite(Samus s)
        {
            return new IdleSamusSprite(rightIdle, s);
        }

        public ISprite LeftIdleSprite(Samus s)
        {
            return new IdleSamusSprite(leftIdle, s);
        }

        public RightWalkSamusSprite RightWalkSprite(Samus s)
        {
            return new RightWalkSamusSprite(rightWalk, s);
        }

        public LeftWalkSamusSprite LeftWalkSprite(Samus s)
        {
            return new LeftWalkSamusSprite(leftWalk, s);
        }

        public MorphAnimationSamusSprite MorphRightAnimationSprite(Samus s, MorphSamusState currentState)
        {
            return new MorphAnimationSamusSprite(rightMorphAnimation, s, true, currentState);
        }

        public MorphAnimationSamusSprite MorphLeftAnimationSprite(Samus s, MorphSamusState currentState)
        {
            return new MorphAnimationSamusSprite(leftMorphAnimation, s, false, currentState);
        }

        public MorphDoneAnimationSamusSprite MorphMovingAnimationSprite(Samus s, bool facingRight)
        {
            return new MorphDoneAnimationSamusSprite(movingMorph, s, facingRight);
        }

        public ISprite JumpRightSprite(Samus s)
        {
            return new JumpSamusSprite(jumpRight, s);
        }

        public ISprite JumpLeftSprite(Samus s)
        {
            return new JumpSamusSprite(jumpLeft, s);
        }

        public ISprite RightAimUpSprite(Samus s)
        {
            return new AimUpSamusSprite(rightAim, s);
        }

        public ISprite LeftAimUpSprite(Samus s)
        {
            return new AimUpSamusSprite(leftAim, s);
        }

        public Samus CreatePlayerSprite(Vector2 l, Game1 g, GameTime g2)
        {
            return new Samus(l, g, g2);
        }

        public ISprite EmptyTankSprite(Vector2 pos)
        {
            return new EnergyTankSprite(tankIcon, pos, new Rectangle(8, 0, 8, 8));
        }

        public ISprite FullTankSprite(Vector2 pos)
        {
            return new EnergyTankSprite(tankIcon, pos, new Rectangle(0, 0, 8, 8));
        }
    }
}
