using SuperMetroidvania5Million.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.GameObjects.Player;
using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.GameStates;
using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    public class Samus : IPlayer
    {
        public IPlayerState State { get; set; }
        public PlayerInventory Inventory { get; set; }
        public Rectangle space { get; set; }
        private Rectangle playerHitBox;
        private Game1 game;
        private bool isDead;
        private bool godMode;
        public int missile;
        public GameTime gameTime;
        public PlayerPhysics Physics { get; private set; }
        public PlayerHUD HUD { get; private set; }
        public bool Jumping { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float missileSpeed { get; private set; }
        public Vector2 HealthPosition { get; private set; }
        private ICommand gameOverCommand;

        private int spriteHeight = 64;
        private int rightIdleOffset = 13;
        private int idleWidth = 40;
        private int leftIdleOffset = 11;
        private int rightWalkOffset = 14;
        private int leftWalkOffset = 13;
        private int walkWidth = 37;
        private int jumpRightOffset = 9;
        private int jumpLeftOffset = 8;
        private int jumpWidth = 47;
        private int jumpHeight = 52;
        private bool morph;
        private bool invincible;
        private int timer = 0;
        private int interval = 1000;


        public Samus(Vector2 l, Game1 g, GameTime g2)
        {
            morph = false;
            invincible = false;
            gameTime = g2;
            game = g;
            isDead = false;
            x = l.X;
            y = l.Y;
            space = new Rectangle((int)x, (int)y, 64, 64);
            playerHitBox = new Rectangle(space.X + rightIdleOffset, space.Y, idleWidth, spriteHeight);
            missile = 1;
            Inventory = new PlayerInventory(30);
            Physics = new PlayerPhysics(this);
            State = new RightIdleSamusState(this);
            Jumping = false;
            HUD = new PlayerHUD(this);
            gameOverCommand = new SetMenuStateCommand(new GameOverState(g));
            godMode = false;
        }

        public void Attack()
        {
            if ((!morph && missile == 0 && Inventory.CurrentMissileRocketCount > 0)){
                State.Attack();
                Inventory.useRocket();
                SoundManager.Instance.Projectiles.MissileRocketFireSound.PlaySound();
            }else if (!morph && missile == 2 && Inventory.HasWaveBeam){
                State.Attack();
                SoundManager.Instance.Projectiles.WaveBeamFireSound.PlaySound();
            }
            else if (morph || missile == 1){
                State.Attack();
                SoundManager.Instance.Projectiles.PowerBeamFireSound.PlaySound();
            }
        }
        public void CycleBeamMissile()
        {
            if (missile == 2)
            {
                missile = 0;
            }
            else
            {
                missile++;
            }
        }
        public void Jump()
        {
            if (Inventory.HasHighJump){
                Physics.setHighJump();
            }
            State.Jump();
        }
        public void Morph()
        {
            if (!morph)
            {
                State.Morph();
                morph = true;
            }
            else
            {
                morph = false;
                State.Idle();
            }
        }
        public void MoveRight()
        {
            State.MoveRight();
        }
        public void MoveLeft()
        {
            State.MoveLeft();
        }
        public void AimUp()
        {
            State.AimUp();
        }
        public void TakeDamage(int damage)
        {
            if (Inventory.HasHiddenPuzzles){
                setGodMode();
            }
            if (!godMode && !invincible)
            {
                Inventory.Damage(damage, this);
                State = new DamagedPlayerStateDecorator(State, Color.Red);
                invincible = true;
                SoundManager.Instance.Player.PlayerDamageSound.PlaySound();
            }
        }
        public void Upgrade(IItem item)
        {
            item.GiveToPlayer(Inventory);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            Physics.Update();
            HUD.Update();
            if (invincible && (timer += (int)gameTime.ElapsedGameTime.TotalMilliseconds) > interval)
            {
                invincible = false;
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
            HUD.Draw(spriteBatch);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void Idle()
        {
            State.Idle();
        }

        public void Kill()
        {
            isDead = true;
            gameOverCommand.Execute();
        }

        public Rectangle SpaceRectangle()
        {
            return space;
        }

        public Rectangle SpriteRectangle()
        {
            return space;
        }

        public Vector2 GetPlayerLocation(){
            return new Vector2(x, y);
        }

        public void UpdateLocation(Vector2 l)
        {
            x = l.X;
            y = l.Y;
            space = new Rectangle((int)x, (int)y, 64, 64);
        }

        public void UpdateRightIdleHitBox()
        {
            playerHitBox = new Rectangle(space.X + rightIdleOffset, space.Y, idleWidth, spriteHeight);
        }

        public void UpdateLeftIdleHitBox()
        {
            playerHitBox = new Rectangle(space.X + leftIdleOffset, space.Y, idleWidth, spriteHeight);
        }

        public void UpdateRightWalkHitBox()
        {
            playerHitBox = new Rectangle(space.X + rightWalkOffset, space.Y, walkWidth, spriteHeight);
        }

        public void UpdateLeftWalkHitBox()
        {
            playerHitBox = new Rectangle(space.X + leftWalkOffset, space.Y, walkWidth, spriteHeight);
        }

        public void UpdateJumpRightHitBox()
        {
            playerHitBox = new Rectangle(space.X + jumpRightOffset, space.Y, jumpWidth, jumpHeight);
        }

        public void UpdateJumpLeftHitBox()
        {
            playerHitBox = new Rectangle(space.X + jumpLeftOffset, space.Y, jumpWidth, jumpHeight);
        }

        public void UpdateAimHitBox()
        {
            playerHitBox = new Rectangle(space.X, space.Y, space.Width, space.Height);
        }

        public bool getMorph()
        {
            return morph;
        }

        public void setGodMode(){
            godMode = true;
        }

    }
}
