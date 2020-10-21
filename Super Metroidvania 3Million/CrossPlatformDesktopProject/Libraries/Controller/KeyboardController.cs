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

        //The suppressedKeyTimer keeps track of all the keys and, if mapped to a positive number, how long they are suppressed for.
        private Dictionary<Keys, int> suppressedKeyTimer = new Dictionary<Keys, int>();

        private int msSuppressTimer = 100;
        private KeyboardState oldState;
        private KeyboardState newState;
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
            PlayerSprite player = (PlayerSprite)gameState.SpriteList.ElementAt(0); // The player sprite

            ICommand up = new Jump(gameState, player);
            ICommand down = new Crouch(gameState, player);
            ICommand left = new MoveLeft(gameState, player);
            ICommand right = new MoveRight(gameState, player);
            ICommand attack = new ShootBeam(gameState, player);
            ICommand missleOrBomb = new MissileOrBomb(gameState, player);
            ICommand start = new Start(gameState);
            ICommand select = new Select(gameState);
            ICommand damage = new Damage(gameState, player);

            //enemies
            ICommand nextEnemy = new NextEnemy(gameState);
            ICommand previousEnemy = new PreviousEnemy(gameState);

            //Upgrade Toggles
            ICommand iceToggle = new UpgradeToggle(PlayerSprite.UpgradeType.Icebeam, player);
            ICommand waveToggle = new UpgradeToggle(PlayerSprite.UpgradeType.Wavebeam, player);
            ICommand longToggle = new UpgradeToggle(PlayerSprite.UpgradeType.Longbeam, player);
            ICommand screwToggle = new UpgradeToggle(PlayerSprite.UpgradeType.Screw, player);

            //Items
            ICommand nextItem = new NextItem(gameState);
            ICommand previousItem = new PreviousItem(gameState);

            //Blocks
            ICommand nextBlock = new NextBlock(gameState);
            ICommand previousBlock = new PreviousBlock(gameState);

            //Upgrade Toggles
            RegisterCommand(Keys.D1, iceToggle);
            RegisterCommand(Keys.NumPad1, iceToggle);
            RegisterCommand(Keys.D2, waveToggle);
            RegisterCommand(Keys.NumPad2, waveToggle);
            RegisterCommand(Keys.D3, longToggle);
            RegisterCommand(Keys.NumPad3, longToggle);
            RegisterCommand(Keys.D4, longToggle); //Not fully implemented yet.
            RegisterCommand(Keys.NumPad4, longToggle);

            RegisterCommand(Keys.C, missleOrBomb);

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

            RegisterCommand(Keys.U, previousItem);
            RegisterCommand(Keys.I, nextItem);

            //RegisterCommand(Keys.X, special);
            //RegisterCommand(Keys.M, special);

            RegisterCommand(Keys.Q, start);

            RegisterCommand(Keys.R, select);

            RegisterCommand(Keys.E, damage);

            RegisterCommand(Keys.T, previousBlock);
            RegisterCommand(Keys.Y, nextBlock);


        }
    }
}

