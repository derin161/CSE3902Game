using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Design;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Command;

namespace CrossPlatformDesktopProject.Libraries.Controller
{
    class KeyboardController : IController
    {
        //Written by Tristan Roman and Shyamal Shah Please Work 
        private Dictionary<Keys, ICommand> controllerMappings;

        private KeyboardState oldState;
        KeyboardState newState; // ***
        Keys[] pressedKeys;
        private int choice;
        Game1 gameState;

        public KeyboardController(Game1 game, int current)
        {
            oldState = Keyboard.GetState();
            choice = current;
            gameState = game;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public int Update(int current)
        {
            makeDict();
            pressedKeys = Keyboard.GetState().GetPressedKeys();
            choice = current;
            newState = Keyboard.GetState();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key)) 
                {
                controllerMappings[key].Execute();
                }
            }

            oldState = newState;

            return choice;
        }

        public void makeDict()     // If else of possible actions that updates choice
        {
            Jump up = new Jump(gameState);
            Crouch down = new Crouch(gameState);
            MoveLeft left = new MoveLeft(gameState);
            MoveRight right = new MoveRight(gameState);
            Attack attack = new Attack(gameState);
            Special special = new Special(gameState);
            Start start = new Start(gameState);
            Select select = new Select(gameState);
            Damage damage = new Damage(gameState);

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

            RegisterCommand(Keys.X, special);
            RegisterCommand(Keys.M, special);

            RegisterCommand(Keys.R, start);

            RegisterCommand(Keys.Q, select);

            RegisterCommand(Keys.E, damage);

        }

        // Keyboard Dictionary
        /*
        public Boolean Up() { return newState.IsKeyDown(Keys.W) || newState.IsKeyDown(Keys.Up) || oldState.IsKeyDown(Keys.W) || oldState.IsKeyDown(Keys.Up); }
        public Boolean Down() { return newState.IsKeyDown(Keys.S) || newState.IsKeyDown(Keys.Down) || oldState.IsKeyDown(Keys.S) || oldState.IsKeyDown(Keys.Down); }
        public Boolean Left() { return newState.IsKeyDown(Keys.A) || newState.IsKeyDown(Keys.Left) || oldState.IsKeyDown(Keys.A) || oldState.IsKeyDown(Keys.Left); }
        public Boolean Right() { return newState.IsKeyDown(Keys.D) || newState.IsKeyDown(Keys.Right) || oldState.IsKeyDown(Keys.D) || oldState.IsKeyDown(Keys.Right); }
        public Boolean Attack() { return newState.IsKeyDown(Keys.Z) || newState.IsKeyDown(Keys.N) || oldState.IsKeyDown(Keys.Z) || oldState.IsKeyDown(Keys.N); }
        public Boolean Special() { return newState.IsKeyDown(Keys.X) || newState.IsKeyDown(Keys.M) || oldState.IsKeyDown(Keys.X) || oldState.IsKeyDown(Keys.M); }


        public Boolean PowerBeam() { return newState.IsKeyDown(Keys.D1) || newState.IsKeyDown(Keys.NumPad1) || oldState.IsKeyDown(Keys.NumPad1) || oldState.IsKeyDown(Keys.D1); }
        public Boolean WaveBeam() { return newState.IsKeyDown(Keys.D2) || newState.IsKeyDown(Keys.NumPad2) || oldState.IsKeyDown(Keys.NumPad2) || oldState.IsKeyDown(Keys.D2); }
        public Boolean IceBeam() { return newState.IsKeyDown(Keys.D3) || newState.IsKeyDown(Keys.NumPad3) || oldState.IsKeyDown(Keys.NumPad3) || oldState.IsKeyDown(Keys.D3); }
        public Boolean MissleRocket() { return newState.IsKeyDown(Keys.D4) || newState.IsKeyDown(Keys.NumPad4) || oldState.IsKeyDown(Keys.NumPad4) || oldState.IsKeyDown(Keys.D4); }
        public Boolean Bomb() { return newState.IsKeyDown(Keys.D5) || newState.IsKeyDown(Keys.NumPad5) || oldState.IsKeyDown(Keys.NumPad5) || oldState.IsKeyDown(Keys.D5); } // Only in morphball


        public Boolean Start() { return newState.IsKeyDown(Keys.R) || oldState.IsKeyDown(Keys.R); } // Sprint 2 - Restart
        public Boolean Select() { return newState.IsKeyDown(Keys.Q) || oldState.IsKeyDown(Keys.Q); } // Sprint 2 - Quit

        public Boolean CycleBlockLeft() { return newState.IsKeyDown(Keys.T) || oldState.IsKeyDown(Keys.T); } // Sprint 2 - Cycle Blocks (T/Y)
        public Boolean CycleBlockRight() { return newState.IsKeyDown(Keys.Y) || oldState.IsKeyDown(Keys.Y); } // Sprint 2 - Cycle Blocks (T/Y)
        public Boolean CycleItemLeft() { return newState.IsKeyDown(Keys.U) || oldState.IsKeyDown(Keys.U); } // Sprint 2 - Cycle Items (U/I)
        public Boolean CycleItemRight() { return newState.IsKeyDown(Keys.I) || oldState.IsKeyDown(Keys.I); } // Sprint 2 - Cycle Items (U/I)
        public Boolean CycleEnemyLeft() { return newState.IsKeyDown(Keys.O) || oldState.IsKeyDown(Keys.O); } // Sprint 2 - Cycle Enemies (O/P)
        public Boolean CycleEnemyRight() { return newState.IsKeyDown(Keys.P) || oldState.IsKeyDown(Keys.P); } // Sprint 2 - Cycle Enemies (O/P)
        public Boolean Damaged() { return newState.IsKeyDown(Keys.E) || oldState.IsKeyDown(Keys.E); } // Sprint 2 - Damaged (E)
        */
    }
}

