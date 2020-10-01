using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.Command.PlayerCommands;

namespace CrossPlatformDesktopProject.Libraries.Controller
{
    public class KeyboardController : IController
    {
        //Written by Tristan Roman and Shyamal Shah
        private Dictionary<Keys, ICommand> controllerMappings = new Dictionary<Keys, ICommand>();

        private KeyboardState oldState;
        private KeyboardState newState; // ***
        private Keys[] pressedKeys;
        private Game1 gameState;

        public KeyboardController(Game1 game)
        {
            oldState = Keyboard.GetState();
            gameState = game;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            if (!controllerMappings.ContainsKey(key))
            {
                controllerMappings.Add(key, command);
            }
            else {
                controllerMappings[key] = command;
            }
        }
        public void Update()
        {
            makeDict();
            pressedKeys = Keyboard.GetState().GetPressedKeys();
            newState = Keyboard.GetState();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key)){
                    controllerMappings[key].Execute();
                }
            }

            oldState = newState;

        }

        public void makeDict()     // If else of possible actions that updates choice
        {
            ICommand up = new Jump(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand down = new Crouch(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand left = new MoveLeft(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand right = new MoveRight(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            ICommand attack = new Command.ShootBeam(gameState, (PlayerSprite) gameState.SpriteList.ElementAt(0));
            //ICommand special = new Special(gameState);
            ICommand start = new Start(gameState);
            ICommand select = new Select(gameState);
            //ICommand damage = new Damage(gameState);

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

            //RegisterCommand(Keys.X, special);
            //RegisterCommand(Keys.M, special);

            RegisterCommand(Keys.Q, start);

            RegisterCommand(Keys.R, select);

            //RegisterCommand(Keys.E, damage);

        }
    }
}

