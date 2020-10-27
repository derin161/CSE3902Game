using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Command.PlayerCommands;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Controller
{
    public class KeyboardController : IController
    {
        //Written by Tristan Roman and Shyamal Shah and Nyigel Spann
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
            IPlayer player = GameObjectContainer.Instance.Player; // The player sprite

            RegisterCommand(Keys.Space, new PlayerJumpCommand(player));

            RegisterCommand(Keys.W, new PlayerAimUpCommand(player));
            RegisterCommand(Keys.Up, new PlayerAimUpCommand(player));

            RegisterCommand(Keys.S, new PlayerMorphCommand(player));
            RegisterCommand(Keys.Down, new PlayerMorphCommand(player));

            RegisterCommand(Keys.A, new PlayerMoveLeftCommand(player));
            RegisterCommand(Keys.Left, new PlayerMoveLeftCommand(player));

            RegisterCommand(Keys.D, new PlayerMoveRightCommand(player));
            RegisterCommand(Keys.Right, new PlayerMoveRightCommand(player));

            RegisterCommand(Keys.Z, new PlayerAttackCommand(player));
            RegisterCommand(Keys.N, new PlayerAttackCommand(player));

            RegisterCommand(Keys.C, new CycleBeamMissileCommand(player));

            RegisterCommand(Keys.Q, new QuitCommand(gameState));

            RegisterCommand(Keys.R, new RestartCommand(gameState));


        }
    }
}

