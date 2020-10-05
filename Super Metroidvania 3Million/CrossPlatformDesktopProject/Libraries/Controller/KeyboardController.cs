using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.Command.PlayerCommands;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Controller
{
    public class KeyboardController : IController
    {
        //Written by Tristan Roman and Shyamal Shah
        private Dictionary<Keys, ICommand> controllerMappings = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, int> suppressedKeyTimer = new Dictionary<Keys, int>();

        private int msSuppressTimer = 100;
        private KeyboardState oldState;
        private KeyboardState newState; // ***
        private Keys[] pressedKeys;
        private Game1 gameState;

        public KeyboardController(Game1 game)
        {
            oldState = Keyboard.GetState();
            gameState = game;
            makeDict();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            if (!controllerMappings.ContainsKey(key))
            {
                controllerMappings.Add(key, command);
                suppressedKeyTimer.Add(key, 0);
            }
            else {
                controllerMappings[key] = command;
            }
        }
        public void Update(GameTime gameTime)
        {
            pressedKeys = Keyboard.GetState().GetPressedKeys();
            newState = Keyboard.GetState();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key) && suppressedKeyTimer[key] < 0) {
                    controllerMappings[key].Execute();
                    suppressedKeyTimer[key] = msSuppressTimer;
                } else if (controllerMappings.ContainsKey(key)) {
                    suppressedKeyTimer[key] -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }

            oldState = newState;

        }

        public void GameOver(bool gameOver) { 
            //update the controller however necessary for a game over
        }

        private void makeDict()     // If else of possible actions that updates choice
        {
            ICommand up = new Jump(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand down = new Crouch(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand left = new MoveLeft(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand right = new MoveRight(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand attack = new Command.ShootBeam(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            //ICommand special = new Special(gameState);
            ICommand start = new Start(gameState);
            ICommand select = new Select(gameState);
            ICommand damage = new Damage(gameState, (PlayerSprite)gameState.SpriteList.ElementAt(0));

            //enemies
            ICommand nextEnemy = new NextEnemy(gameState);
            ICommand previousEnemy = new PreviousEnemy(gameState);

            //Item select
            List<ICommand> itemSelect = new List<ICommand> { };

            RegisterCommand(Keys.W, up);
            RegisterCommand(Keys.Up, up);

            RegisterCommand(Keys.S, down);
            RegisterCommand(Keys.Down, down);

            RegisterCommand(Keys.A, left);
            RegisterCommand(Keys.Left, left);

            RegisterCommand(Keys.D, right);
            RegisterCommand(Keys.Right, right);
 
            RegisterCommand(Keys.Z, attack);
            RegisterCommand(Keys.N, attack);

            RegisterCommand(Keys.O, previousEnemy);
            RegisterCommand(Keys.P, nextEnemy);

            //RegisterCommand(Keys.X, special);
            //RegisterCommand(Keys.M, special);

            RegisterCommand(Keys.Q, start);

            RegisterCommand(Keys.R, select);

            RegisterCommand(Keys.E, damage);


        }
    }
}

