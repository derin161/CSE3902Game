using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite
{
    public class PlayerSprite : IPlayer
    {
        public enum State
        {
            Attack, Item1, Item2, Item3, Item4, Item5, MoveRight, MoveLeft, Crouch, Jump, Idle
        }
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
        public int currentFrame = 0;
        private int pixelSize;
        private int lowerBound = 480;
        private int rightBound = 800;
        private int xIncrease = 10;
        private int yIncrease = 15;

        private Texture2D rightIdle;
        private Texture2D leftIdle;
        private Texture2D rightWalk;
        private Texture2D leftWalk;
        private Texture2D rightCrouch;
        private Texture2D leftCrouch;
        private Texture2D jump;
        private Texture2D currentText;

        private int health = 100;

        public PlayerSprite(List<Texture2D> texture)
        {
            currentState = State.Idle;
            facingRight = true;
            currentFrame = 0;
            rightIdle = texture.ElementAt(0);
            leftIdle = texture.ElementAt(1);
            rightWalk = texture.ElementAt(2);
            leftWalk = texture.ElementAt(3);
            rightCrouch = texture.ElementAt(4);
            leftCrouch = texture.ElementAt(5);
            jump = texture.ElementAt(6);
            currentText = rightIdle;
            pixelSize = currentText.Height;
            lowerBound = 480 - pixelSize;
            rightBound = 800 - pixelSize;
            Location = new Vector2(0, lowerBound);
            ice = false;
            wave = false;
            elong = true;
            rTime = 80;
            jTime = (rTime*7)/8;

        }

        public void UpdateState(State newState, int newFrame, bool rightFace) 
        {
            currentState = newState;
            currentFrame = newFrame;
            facingRight = rightFace;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            //User actions based on switch case of states that change when a new action is selected
            switch (currentState){
                case State.Attack: // Attack
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        currentFrame++;
                    }
                    break;
                /*case State.Item1: // Item1 - PowerBeam
                    break;
                case State.Item2: // Item2 - WaveBeam
                    break;
                case State.Item3: // Item3 - IceBeam
                    break;
                case State.Item4: // Item4 - MissleRocket
                    break;
                case State.Item5: // Item5 - Bomb
                    break;*/
                case State.MoveRight: // Move Right
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        currentFrame++;
                        Location = new Vector2(Location.X + xIncrease, Location.Y);
                        if (Location.X > rightBound){
                            Location = new Vector2(rightBound, Location.Y);
                        }
                    }
                    break;
                case State.MoveLeft: // Move Left
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        currentFrame++;
                        Location = new Vector2(Location.X - xIncrease, Location.Y);
                        if (Location.X < 0){
                            Location = new Vector2(0, Location.Y);
                        }
                    }

                    break;
                case State.Jump: // Jump
                    if (timeSinceLastFrame > jTime){
                        timeSinceLastFrame -= jTime;
                        currentFrame++;                   
                        if (currentFrame == 1 || currentFrame == 2 || currentFrame == 3 || currentFrame == 4){
                            Location = new Vector2(Location.X, Location.Y - yIncrease);
                        }else if (currentFrame == 6 || currentFrame == 7 || currentFrame == 8 || currentFrame == 9){
                            Location = new Vector2(Location.X, Location.Y + yIncrease);
                        }
                        if (Location.Y < 0){
                            Location = new Vector2(Location.X, 0);
                        }
                    }
                    break;
                case State.Crouch: // Crouch: Nothing needs to be updated.
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                        currentFrame++;
                    }                    
                    break;
                case State.Idle: // Idle
                    if (timeSinceLastFrame > rTime){
                        timeSinceLastFrame -= rTime;
                    } 
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
                /*case State.Item1: // Item1 - PowerBeam
                    PowerBeamAnimation(spriteBatch);
                    break;
                case State.Item2: // Item2 - WaveBeam
                    WaveBeamAnimation(spriteBatch);
                    break;
                case State.Item3: // Item3 - IceBeam
                    IceBeamAnimation(spriteBatch);
                    break;
                case State.Item4: // Item4 - MissleRocket
                    MissleRocketAnimation(spriteBatch);
                    break;
                case State.Item5: // Item5 - Bomb
                    BombAnimation(spriteBatch);
                    break;*/
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
            }
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
            currentFrame = 0;
        }

        public void AttackAnimation(SpriteBatch spriteBatch) 
        {
            currentState = State.Idle;
            IdleAnimation(spriteBatch);
        }

        /*
        public void PowerBeamAnimation(SpriteBatch spriteBatch)
        {
            //Put Code for animation
        }

        public void WaveBeamAnimation(SpriteBatch spriteBatch)
        {
            //Put Code for animation
        }
        public void IceBeamAnimation(SpriteBatch spriteBatch)
        {
            //Put Code for animation
        }
        public void MissleRocketAnimation(SpriteBatch spriteBatch)
        {
            //Put Code for animation
        }
        public void BombAnimation(SpriteBatch spriteBatch)
        {
            //Put Code for animation
        }
        */

        public void MoveLeftAnimation(SpriteBatch spriteBatch)
        {
            facingRight = false;
            currentText = leftWalk;
            int adjFrame = currentFrame;
            if (currentFrame % 4 == 0){
                adjFrame = 3;
            }else if (currentFrame % 4 == 1){
                adjFrame = 2;
            }else if (currentFrame % 4 == 2){
                adjFrame = 1;
            }else if (currentFrame % 4 == 3){
                adjFrame = 0;
            }

            int width = currentText.Width / 4;
            int height = currentText.Height;
            Rectangle srcRec = new Rectangle((width * adjFrame), 0, width, height);
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            if (currentFrame == 7)
            {
                currentState = State.Idle;
            }

        }

        public void MoveRightAnimation(SpriteBatch spriteBatch)
        {
            facingRight = true;
            currentText = rightWalk;
            int width = currentText.Width / 4;
            int height = currentText.Height;
            Rectangle srcRec = new Rectangle((width * (currentFrame % 4)), 0, width, height);
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White); 
            if (currentFrame == 7){
                currentState = State.Idle;
            }
        }

        public void CrouchAnimation(SpriteBatch spriteBatch)
        {
            int adjFrame = currentFrame;
            int width;
            int height;
            Rectangle srcRec;
            Rectangle destRec;
            if (facingRight){
                currentText = rightCrouch;
                if (currentFrame == 0 || currentFrame == 4){
                    adjFrame = 0;
                }else if (currentFrame == 1 || currentFrame == 3){
                    adjFrame = 1;
                }else if (currentFrame == 2){
                    adjFrame = 2;
                }
            }else {
                currentText = leftCrouch;
                if (currentFrame == 0 || currentFrame == 4){
                    adjFrame = 2;
                }else if (currentFrame == 1 || currentFrame == 3){
                    adjFrame = 1;
                }else if (currentFrame == 2){
                    adjFrame = 0;
                }
            }
            width = currentText.Width / 3;
            height = currentText.Height;
            srcRec = new Rectangle((width * adjFrame), 0, width, height);
            destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            if (currentFrame == 4)
            {
                currentState = State.Idle;
            }
        }

        public void JumpAnimation(SpriteBatch spriteBatch)
        {
            currentText = jump;
            int width;
            int height;
            int adjFrame = currentFrame;
            Rectangle srcRec;
            Rectangle destRec;

            if (currentFrame == 0 || currentFrame == 10){
                if (currentFrame == 10){
                    currentState = State.Idle;
                }
                currentFrame = 0;
                IdleAnimation(spriteBatch);
            }else if (currentFrame == 1 || currentFrame == 9){
                adjFrame = currentFrame;
                currentFrame = 1;
                CrouchAnimation(spriteBatch);
                currentFrame = adjFrame;
            }else if (facingRight){
                width = currentText.Width / 4;
                height = currentText.Height;
                if (currentFrame == 2 || currentFrame == 6){
                   adjFrame = 0;
                }
                else if (currentFrame == 3 || currentFrame == 7){
                    adjFrame = 1;
                }else if (currentFrame == 4 || currentFrame == 8){
                    adjFrame = 2;
                }else if (currentFrame == 5){
                    adjFrame = 3;
                }
                srcRec = new Rectangle((width * adjFrame), 0, width, height);
                destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            }else {
                width = currentText.Width / 4;
                height = currentText.Height;
                if (facingRight){
                    if (currentFrame == 2 || currentFrame == 6){
                        adjFrame = 0;
                    }
                    else if (currentFrame == 3 || currentFrame == 7){
                        adjFrame = 1;
                    }else if (currentFrame == 4 || currentFrame == 8){
                        adjFrame = 2;
                    }else if (currentFrame == 5){
                        adjFrame = 3;
                    }
                }else {
                    if (currentFrame == 2 || currentFrame == 6){
                        adjFrame = 3;
                    }else if (currentFrame == 3 || currentFrame == 7){
                        adjFrame = 2;
                    }else if (currentFrame == 4 || currentFrame == 8){
                        adjFrame = 1;
                    }else if (currentFrame == 5){
                        adjFrame = 0; 
                    }
                }
                srcRec = new Rectangle((width * adjFrame), 0, width, height);
                destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            }
        }

        public void DamageAnimation(SpriteBatch spriteBatch)
        {
            int x = 1 + 1;
        }

        public bool IsDead() {
            return false;
        }

    }
}
