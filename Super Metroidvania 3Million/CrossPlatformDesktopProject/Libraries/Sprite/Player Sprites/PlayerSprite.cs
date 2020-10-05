using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite
{
    public class PlayerSprite : IPlayer
    {
        public enum State
        {
            Attack, MoveRight, MoveLeft, Crouch, Jump, Idle, Damage, Dead
        }

        public enum HealthState
        {
            Normal,
            Low, 
            Critical
        };

        public enum UpgradeType{
            Icebeam, Wavebeam, Longbeam, Bomb, EnergyTank, MorphBall, MissileTank, HiJump, Varia, Screw
        }
        public HealthState currentHealthState;

        public Vector2 HealthPosition = new Vector2(20, 20);

        public bool dead = false;
        public int currentHealth = 100;
        public int maxHealth = 100;

        public State currentState;
        public Vector2 Location { get; set; }
        public bool ice { get; set; } //ice beam
        public bool wave { get; set; } //wave beam
        public bool elong { get; set; } //long beam
        public bool facingRight { get; set; }
        public int TotalRockets { get; set; }

        private int timeSinceLastFrame = 0;
        private int rTime;
        private int jTime;
        private int pixelSize;
        private int lowerBound = 480;
        private int rightBound = 800;
        public int xIncrease = 10;
        public int yIncrease = 20;

        private Texture2D rightIdle;
        private Texture2D leftIdle;
        private Texture2D rightWalk;
        private Texture2D leftWalk;
        private Texture2D rightCrouch;
        private Texture2D leftCrouch;
        private Texture2D jump;
        private Texture2D currentText;

        private Texture2D damaged_rightIdle;
        private Texture2D damaged_leftIdle;
        private Texture2D healthBar;
        //private SpriteFont currentFont;
        private SpriteFont healthFont;
        
        public int idleFrames = 0;
        public int moveLeftFrames = -1;
        public int moveRightFrames = -1;
        public int crouchFrames = -1;
        public int jumpFrames = 0;
        public int damageFrames = -1;
        public int invinsibilityFrames = 24;
        
        public bool moveDisabled = false;
        public bool jumpDisabled = false;
        public bool crouchDisabled = false;
        public bool damageDisabled = false;
        public bool varia = false;

        public PlayerSprite(List<Texture2D> texture, List<SpriteFont> font)
        {
            currentState = State.Idle;
            facingRight = true;
            rightIdle = texture.ElementAt(0);
            leftIdle = texture.ElementAt(1);
            rightWalk = texture.ElementAt(2);
            leftWalk = texture.ElementAt(3);
            rightCrouch = texture.ElementAt(4);
            leftCrouch = texture.ElementAt(5);
            jump = texture.ElementAt(6);
            damaged_rightIdle = texture.ElementAt(7);
            damaged_leftIdle = texture.ElementAt(8);
            healthBar = texture.ElementAt(9);
            healthFont = font.ElementAt(0);
            currentText = rightIdle;
            pixelSize = currentText.Height;
            lowerBound = 480 - pixelSize;
            rightBound = 800 - pixelSize;
            Location = new Vector2(0, lowerBound);
            ice = false;
            wave = false;
            elong = false;
            varia = false;
            rTime = 80;
            jTime = (rTime*7)/8;
            TotalRockets = 10;

        }

        public void UpdateState(State newState, int newFrame, bool rightFace) 
        {
            currentState = newState;
            facingRight = rightFace;
                        //User actions based on switch case of states that change when a new action is selected
            switch (currentState){
                case State.Attack: // Attack
                    idleFrames = newFrame;
                    break;
                case State.MoveRight: // Move Right
                    moveRightFrames = newFrame;
                    break;
                case State.MoveLeft: // Move Left
                    moveLeftFrames = newFrame;
                    break;
                case State.Jump: // Jump
                    idleFrames = newFrame;
                    break;
                case State.Crouch: // Crouch: Nothing needs to be updated.
                    crouchFrames = newFrame;               
                    break;
                case State.Idle: // Idle
                    idleFrames = newFrame;
                    break;
                case State.Damage:
                    damageFrames = newFrame;
                    break;
            }
        }

        public void HealthBar(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }
        public void UpdateHealth(int currentHealth, int maxHealth)
        {
            this.maxHealth = maxHealth;
        }

        public void UpdateHealthState()
        {
            float percent = (float)currentHealth / (float)maxHealth;
            if (percent < 0.4)
                currentHealthState = HealthState.Critical;
            else if (percent < 0.7)
                currentHealthState = HealthState.Low;
            else
                currentHealthState = HealthState.Normal;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            //User actions based on switch case of states that change when a new action is selected
            switch (currentState){
                case State.Attack: // Attack
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        idleFrames = 0;
                    }
                    break;
                case State.MoveRight: // Move Right
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        moveRightFrames++;
                        Location = new Vector2(Location.X + xIncrease, Location.Y);
                        if (Location.X > rightBound){
                            Location = new Vector2(rightBound, Location.Y);
                        }
                    }
                    break;
                case State.MoveLeft: // Move Left
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        moveLeftFrames++;
                        Location = new Vector2(Location.X - xIncrease, Location.Y);
                        if (Location.X < 0){
                            Location = new Vector2(0, Location.Y);
                        }
                    }

                    break;
                case State.Jump: // Jump
                    if (timeSinceLastFrame > jTime){
                        timeSinceLastFrame -= jTime;
                        jumpFrames++;                   
                        if (jumpFrames == 1 || jumpFrames == 2 || jumpFrames == 3 || jumpFrames == 4){
                            Location = new Vector2(Location.X, Location.Y - yIncrease);
                        }else if (jumpFrames == 6 || jumpFrames == 7 || jumpFrames == 8 || jumpFrames == 9){
                            Location = new Vector2(Location.X, Location.Y + yIncrease);
                        }
                        if (Location.Y < 0){
                            Location = new Vector2(Location.X, 0);
                        }
                        if (Location.X < 0){
                            Location = new Vector2(0, Location.Y);
                        }
                        if (Location.X > rightBound){
                            Location = new Vector2(rightBound, Location.Y);
                        }
                    }
                    break;
                case State.Crouch: // Crouch: Nothing needs to be updated.
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        crouchFrames++;
                    }                    
                    break;
                case State.Idle: // Idle
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        idleFrames = 0;
                    } 
                    break;
                case State.Damage: // Damaged
                        damageFrames++;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //User actions based on switch case of states that change when a new action is selected
            switch (currentState)
            {
                case State.Attack: // Attack
                    AttackAnimation(spriteBatch);
                    break;
                case State.MoveRight: // Move Right
                    MoveRightAnimation(spriteBatch);
                    break;
                case State.MoveLeft: // Move Left
                    MoveLeftAnimation(spriteBatch);
                    break;
                case State.Jump: // Jump
                    JumpAnimation(spriteBatch);
                    break;
                case State.Crouch: // Crouch
                    CrouchAnimation(spriteBatch);
                    break;
                case State.Idle: // Idle
                    IdleAnimation(spriteBatch);
                    break;
                case State.Damage: // Damage
                    DamageAnimation(spriteBatch);
                    break;

            }

            DamageAnimation(spriteBatch);
        }

        public void IdleAnimation(SpriteBatch spriteBatch)
        {
            if (facingRight)
            {
                currentText = rightIdle;
            }
            else
            {
                currentText = leftIdle;
            }
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, currentText.Width, currentText.Height);
            spriteBatch.Draw(currentText, destRec, Color.White);
            idleFrames = 0;
            jumpDisabled = false;
            crouchDisabled = false;
            moveDisabled = false;
            damageDisabled = false;
        }

        public void AttackAnimation(SpriteBatch spriteBatch) 
        {
            currentState = State.Idle;
            IdleAnimation(spriteBatch);
        }

        public void MoveLeftAnimation(SpriteBatch spriteBatch)
        {
            facingRight = false;
            currentText = leftWalk;
            int adjFrame = moveLeftFrames;
            if (moveLeftFrames % 4 == 0){
                adjFrame = 3;
            }else if (moveLeftFrames % 4 == 1){
                adjFrame = 2;
            }else if (moveLeftFrames % 4 == 2){
                adjFrame = 1;
            }else if (moveLeftFrames % 4 == 3){
                adjFrame = 0;
            }

            int width = currentText.Width / 4;
            int height = currentText.Height;
            Rectangle srcRec = new Rectangle((width * adjFrame), 0, width, height);
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            if (moveLeftFrames == 7)
            {
                currentState = State.Idle;
                moveLeftFrames = -1;
            }

        }

        public void MoveRightAnimation(SpriteBatch spriteBatch)
        {
            facingRight = true;
            currentText = rightWalk;
            int width = currentText.Width / 4;
            int height = currentText.Height;
            Rectangle srcRec = new Rectangle((width * (moveRightFrames % 4)), 0, width, height);
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White); 
            if (moveRightFrames == 7){
                currentState = State.Idle;
                moveRightFrames = -1;
            }
        }

        public void CrouchAnimation(SpriteBatch spriteBatch)
        {
            jumpDisabled = true;
            moveDisabled = true;
            int adjFrame = crouchFrames;
            int width;
            int height;
            Rectangle srcRec;
            Rectangle destRec;
            if (facingRight){
                currentText = rightCrouch;
                if (crouchFrames == 0 || crouchFrames == 4){
                    adjFrame = 0;
                }else if (crouchFrames == 1 || crouchFrames == 3){
                    adjFrame = 1;
                }else if (crouchFrames == 2){
                    adjFrame = 2;
                }
            }else {
                currentText = leftCrouch;
                if (crouchFrames == 0 || crouchFrames == 4){
                    adjFrame = 2;
                }else if (crouchFrames == 1 || crouchFrames == 3){
                    adjFrame = 1;
                }else if (crouchFrames == 2){
                    adjFrame = 0;
                }
            }
            width = currentText.Width / 3;
            height = currentText.Height;
            srcRec = new Rectangle((width * adjFrame), 0, width, height);
            destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            if (crouchFrames == 4)
            {
                jumpDisabled = false;
                moveDisabled = false;
                currentState = State.Idle;
                crouchFrames = -1;
            }
        }

        public void JumpAnimation(SpriteBatch spriteBatch)
        {
            crouchDisabled = true;
            damageDisabled = true;
            currentText = jump;
            int width;
            int height;
            int adjFrame = jumpFrames;
            Rectangle srcRec;
            Rectangle destRec;

            if (jumpFrames == 0 || jumpFrames == 10){
                if (jumpFrames == 10){
                    currentState = State.Idle;
                    crouchDisabled = false;
                    damageDisabled = false;
                }
                jumpFrames = 0;
                IdleAnimation(spriteBatch);
            }else if (jumpFrames == 1 || jumpFrames == 9){
                adjFrame = crouchFrames;
                crouchFrames = 1;
                CrouchAnimation(spriteBatch);
                crouchFrames = adjFrame;
            }else if (facingRight){
                width = currentText.Width / 4;
                height = currentText.Height;
                if (jumpFrames == 2 || jumpFrames == 6){
                   adjFrame = 0;
                }
                else if (jumpFrames == 3 || jumpFrames == 7){
                    adjFrame = 1;
                }else if (jumpFrames == 4 || jumpFrames == 8){
                    adjFrame = 2;
                }else if (jumpFrames == 5){
                    adjFrame = 3;
                }
                srcRec = new Rectangle((width * adjFrame), 0, width, height);
                destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            }else {
                width = currentText.Width / 4;
                height = currentText.Height;
                if (facingRight){
                    if (jumpFrames == 2 || jumpFrames == 6){
                        adjFrame = 0;
                    }
                    else if (jumpFrames == 3 || jumpFrames == 7){
                        adjFrame = 1;
                    }else if (jumpFrames == 4 || jumpFrames == 8){
                        adjFrame = 2;
                    }else if (jumpFrames == 5){
                        adjFrame = 3;
                    }
                }else {
                    if (jumpFrames == 2 || jumpFrames == 6){
                        adjFrame = 3;
                    }else if (jumpFrames == 3 || jumpFrames == 7){
                        adjFrame = 2;
                    }else if (jumpFrames == 4 || jumpFrames == 8){
                        adjFrame = 1;
                    }else if (jumpFrames == 5){
                        adjFrame = 0; 
                    }
                }
                srcRec = new Rectangle((width * adjFrame), 0, width, height);
                destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                spriteBatch.Draw(currentText, destRec, srcRec, Color.Blue);
            }
        }

        public void DamageAnimation(SpriteBatch spriteBatch)
        {
            int width = 0;
            int height = 0;
            if (currentHealth <= 0){
                currentState = State.Dead;
                deadAnimation(spriteBatch);
            }else if (facingRight)
            {
                currentText = damaged_rightIdle;
                width = currentText.Width / 4;
                height = currentText.Height;
            }else
            {
                currentText = damaged_leftIdle;
                width = currentText.Width / 4;
                height = currentText.Height;
            }
            if (damageFrames == 4){
                currentState = State.Idle;
                damageFrames = -1;
                IdleAnimation(spriteBatch);
            }else { 
                Rectangle srcRec = new Rectangle((width * damageFrames), 0, width, height);
                Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
                DrawHealthBar(spriteBatch);
            }
        }

        public void DrawHealthBar(SpriteBatch spriteBatch)
        {
            currentText = healthBar;
            int width = currentText.Width;
            int height = currentText.Height / 9;
            int tmp = 0;
            int amtHealth = currentHealth / 10 ;
            Color tint = Color.Green;

            if (currentHealthState == HealthState.Low){
                tmp = 1;
                tint = Color.Yellow;
            }else if (currentHealthState == HealthState.Critical){
                tmp = 2;
                tint = Color.Red;
            }


            Rectangle srcRec = new Rectangle(0, 3 * tmp, 1, 3);
            Rectangle destRec;
            String text = currentHealth + "/" + maxHealth;

            for (int i = 0; i < amtHealth; i++){
                destRec = new Rectangle((int)HealthPosition.X + ((9+2)*i), (int)HealthPosition.Y, width, height);
                spriteBatch.Draw(healthBar, destRec, srcRec, Color.White);
            }
            spriteBatch.DrawString(healthFont,text, new Vector2(HealthPosition.X + ((9 + 2) * 10), HealthPosition.Y), tint);
            
        }

        public bool IsDead() {
            return dead;
        }

        private void deadAnimation(SpriteBatch spriteBatch){
        }

        public void Upgrade(UpgradeType up){
            switch (up){
                case UpgradeType.Icebeam:
                    ice = !ice;
                    break;
                case UpgradeType.Wavebeam:
                    wave = !wave;
                    break;
                case UpgradeType.Longbeam:
                    elong = !elong;
                    break;
                case UpgradeType.Varia:
                    varia = !varia;
                    break;
                default:
                    break;

            }
        }

    }
}
