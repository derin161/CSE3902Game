using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Sprite.ISprite;

namespace CrossPlatformDesktopProject.Sprite.PlayerSprite
{
    class PlayerSprite : IPlayer
    {
        public enum State
        {
            Attack, Item1, Item2, Item3, Item4, Item5, MoveRight, MoveLeft, Crouch, Jump, Idle
        }
        private State currentState;
        public Vector2 Location { get; set; }
        public bool ice { get; set; } //ice beam
        public bool wave { get; set; } //wave beam
        public bool elong { get; set; } //long beam
        public bool facingRight { get; set; }
        public int TotalRockets { get; set; }
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 75;
        private int currentFrame = 0;

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
            Location.X = 0;
            Location.Y = 448;
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
            ice = false;
            wave = false;
            elong = false;

        }

        public void UpdateState(State newState) 
        {
            currentState = newState;
        }

        public void Update(GameTime gameTime)
        {
            if (timeSinceLastFrame > millisecondsPerFrame){
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
                //User actions based on switch case of states that change when a new action is selected
                switch (currentState)
                {
                    case Attack: // Attack
                        break;
                    case Item1: // Item1 - PowerBeam
                        break;
                    case Item2: // Item2 - WaveBeam
                        break;
                    case Item3: // Item3 - IceBeam
                        break;
                    case Item4: // Item4 - MissleRocket
                        break;
                    case Item5: // Item5 - Bomb
                        break;
                    case MoveRight: // Move Right
                        if (currentFrame != 0){
                            Location.X += 1;
                            if (Location.X > 768){
                                Location.X = 768;
                            }
                        }
                        break;
                    case MoveLeft: // Move Left
                        if (currentFrame != 0)
                        {
                            Location.X -= 1;
                            if (Location.X < 32)
                            {
                                Location.X = 32;
                            }
                        }
                        break;
                    case Jump: // Jump
                        if (currentFrame > 0 && currentFrame < 6){
                            Location.Y -= 1;
                        }else if (currentFrame > 5 && currentFrame <= 10){
                            Location.Y -= 1;
                        }
                        break;
                    case Crouch: // Crouch: Nothing needs to be updated.
                        break;
                    case Idle: // Idle
                        currentFrame = 0;
                        break;
                }
                timeSinceLastFrame -= millisecondsPerFrame;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //User actions based on switch case of states that change when a new action is selected
            switch (currentState)
            {
                case Attack: // Attack
                    AttackAnimation(spriteBatch);
                    break;
                case Item1: // Item1 - PowerBeam
                    PowerBeamAnimation(spriteBatch);
                    break;
                case Item2: // Item2 - WaveBeam
                    WaveBeamAnimation(spriteBatch);
                    break;
                case Item3: // Item3 - IceBeam
                    IceBeamAnimation(spriteBatch);
                    break;
                case Item4: // Item4 - MissleRocket
                    MissleRocketAnimation(spriteBatch);
                    break;
                case Item5: // Item5 - Bomb
                    BombAnimation(spriteBatch);
                    break;
                case MoveRight: // Move Right
                    MoveRightAnimation(spriteBatch);
                    break;
                case MoveLeft: // Move Left
                    MoveLeftAnimation(spriteBatch);
                    break;
                case Jump: // Jump
                    JumpAnimation(spriteBatch);
                    break;
                case Crouch: // Crouch
                    CrouchAnimation(spriteBatch);
                    break;
                case Idle: // Idle
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
        }

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

        public void MoveLeftAnimation(SpriteBatch spriteBatch)
        {
            facingRight = false;
            currentText = leftWalk;
            int adjFrame = currentFrame;
            if (currentFrame == 0){
                adjFrame = 3;
            }else if (currentFrame == 1){
                adjFrame = 2;
            }else if (currentFrame == 2){
                adjFrame = 1;
            }else if (currentFrame == 3){
                adjFrame = 0;
            }

            int width = currentText.Width / 4;
            int height = currentText.Height;
            Rectangle srcRec = new Rectangle((width * adjFrame), 0, width, height);
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            if (currentFrame == 3)
            {
                currentState = State.Idle;
                currentFrame = 0;
            }

        }

        public void MoveRightAnimation(SpriteBatch spriteBatch)
        {
            facingRight = true;
            currentText = rightWalk;
            int width = currentText.Width / 4;
            int height = currentText.Height;
            Rectangle srcRec = new Rectangle((width * currentFrame), 0, width, height);
            Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White); 
            if (currentFrame == 3){
                currentState = State.Idle;
                currentFrame = 0;
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
                width = currentText.Width / 3;
                height = currentText.Height;
                srcRec = new Rectangle((width * adjFrame), 0, width, height);
            }else {
                currentText = leftCrouch;
                if (currentFrame == 0 || currentFrame == 4){
                    adjFrame = 2;
                }else if (currentFrame == 1 || currentFrame == 3){
                    adjFrame = 1;
                }else if (currentFrame == 2){
                    adjFrame = 0;
                }
                width = currentText.Width / 3;
                height = currentText.Height;
                srcRec = new Rectangle((width * adjFrame), 0, width, height);
            }
            destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
            spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
            if (currentFrame == 4)
            {
                currentState = State.Idle;
                currentFrame = 0;
            }
        }

        public void JumpAnimation(SpriteBatch spriteBatch)
        {
            currentText = jump;
            int width;
            int height;
            int adjFrame;
            Rectangle srcRec;
            Rectangle destRec;
            if (facingRight){
                if (currentFrame <= 1 || currentFrame >= 9)
                {
                    currentText = rightCrouch;
                    width = currentText.Width / 3;
                    height = currentText.Height;
                    if (currentFrame == 0 || currentFrame == 10){
                        adjFrame = 0;
                    }else if (currentFrame == 1 || currentFrame == 9){
                        adjFrame = 1;
                    }
                    srcRec = new Rectangle((width * adjFrame), 0, width, height);
                    destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                    spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
                }else {
                    width = currentText.Width / 4;
                    height = currentText.Height;
                    if (currentFrame == 2 || currentFrame == 6)
                    {
                        adjFrame = 0;
                    }
                    else if (currentFrame == 3 || currentFrame == 7)
                    {
                        adjFrame = 1;
                    }else if (currentFrame == 4 || currentFrame == 8){
                        adjFrame = 2;
                    }
                    srcRec = new Rectangle((width * adjFrame), 0, width, height);
                    destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                    spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
                }
            }
            else {
                if (currentFrame <= 1 || currentFrame >= 9)
                {
                    currentText = leftCrouch;
                    width = currentText.Width / 3;
                    height = currentText.Height;
                    if (currentFrame == 0 || currentFrame == 10)
                    {
                        adjFrame = 2;
                    }
                    else if (currentFrame == 1 || currentFrame == 9)
                    {
                        adjFrame = 1;
                    }
                    srcRec = new Rectangle((width * adjFrame), 0, width, height);
                    destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                    spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
                }
                else
                {
                    width = currentText.Width / 4;
                    height = currentText.Height;
                    if (currentFrame == 2 || currentFrame == 6)
                    {
                        adjFrame = 2;
                    }
                    else if (currentFrame == 3 || currentFrame == 7)
                    {
                        adjFrame = 1;
                    }
                    else if (currentFrame == 4 || currentFrame == 8)
                    {
                        adjFrame = 0;
                    }
                    srcRec = new Rectangle((width * adjFrame), 0, width, height);
                    destRec = new Rectangle((int)Location.X, (int)Location.Y, width, height);
                    spriteBatch.Draw(currentText, destRec, srcRec, Color.White);
                }
            }
        }
        public void DamageAnimation(SpriteBatch spriteBatch)
        {
            //Put Code for animation
        }

    }
}
