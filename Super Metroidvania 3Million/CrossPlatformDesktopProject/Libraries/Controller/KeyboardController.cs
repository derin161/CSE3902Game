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
        private Dictionary<Keys, ICommand> controllerMappings;

        private KeyboardState oldState;
        KeyboardState newState; // ***
        Keys[] pressedKeys;
        private int choice;

        Jump up = new Jump();
        Crouch down = new Crouch();
        MoveLeft left = new MoveLeft();
        MoveRight right = new MoveRight();
        Attack attack = new Attack();
        Special special = new Special();
        Start start = new Start();
        Select select = new Select();
        Damage damage = new Damage();

        public KeyboardController(int current)
        {
            oldState = Keyboard.GetState();
            choice = current;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update(int current) 
        {
            pressedKeys = Keyboard.GetState().GetPressedKeys();
            choice = current;
            newState = Keyboard.GetState();

            foreach (Keys key in pressedKeys) {
                controllerMappings[key].Execute();
            }

            oldState = newState;
        }

        public void check()     // If else of possible actions that updates choice
        {
            if (Up())
            {
                RegisterCommand(Keys.W, up);
                RegisterCommand(Keys.Up, up);
                choice = 7;
            }
            else if (Down())
            {
                RegisterCommand(Keys.S, down);
                RegisterCommand(Keys.Down, down);
                choice = 8;
            }
            else if (Left())
            {
                RegisterCommand(Keys.A, left);
                RegisterCommand(Keys.Left, left);
                choice = 6;
            }
            else if (Right())
            {
                RegisterCommand(Keys.D, right);
                RegisterCommand(Keys.Right, right);
                choice = 5;
            }
            else if (Attack())
            {
                RegisterCommand(Keys.Z, attack);
                RegisterCommand(Keys.N, attack);
                choice = 1;
            }
            else if (Special())
            {
                // Do nothing - Sprint 2****
                RegisterCommand(Keys.X, special);
                RegisterCommand(Keys.M, special);
            }
            /*
            else if (PowerBeam())
            {
                choice = ;
            }
            else if (WaveBeam())
            {
                choice = ;
            }
            else if (IceBeam())
            {
                choice = ;
            }
            else if (MissleRocket())
            {
                choice = ;
            }
            else if (Bomb())
            {
                choice = ;
            }*/

            else if (Start())
            {
                RegisterCommand(Keys.R, start);
            }
            else if (Select())
            {
                RegisterCommand(Keys.Q, select);
            }

            // vv  Sprint 2 Only Below  vv

            /*
            else if (CycleBlockLeft())
            {
                choice = ;
            }
            else if (CycleBlockRight())
            {
                choice = ;
            }
            else if (CycleItemLeft())
            {
                choice = ;
            }
            else if (CycleItemRight())
            {
                choice = ;
            }
            else if (CycleEnemyLeft())
            {
                choice = ;
            }
            else if (CycleEnemyRight())
            {
                choice = ;
            }*/
            else if (Damaged())
            {
                RegisterCommand(Keys.E, damage);
            }
        }

        // Keyboard Dictionary

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

        public Boolean CycleBlockLeft() { return newState.IsKeyDown(Keys.T) || oldState.IsKeyDown(Keys.T) } // Sprint 2 - Cycle Blocks (T/Y)
        public Boolean CycleBlockRight() { return newState.IsKeyDown(Keys.Y) || oldState.IsKeyDown(Keys.Y); } // Sprint 2 - Cycle Blocks (T/Y)
        public Boolean CycleItemLeft() { return newState.IsKeyDown(Keys.U) || oldState.IsKeyDown(Keys.U); } // Sprint 2 - Cycle Items (U/I)
        public Boolean CycleItemRight() { return newState.IsKeyDown(Keys.I) || oldState.IsKeyDown(Keys.I); } // Sprint 2 - Cycle Items (U/I)
        public Boolean CycleEnemyLeft() { return newState.IsKeyDown(Keys.O) || oldState.IsKeyDown(Keys.O); } // Sprint 2 - Cycle Enemies (O/P)
        public Boolean CycleEnemyRight() { return newState.IsKeyDown(Keys.P) || oldState.IsKeyDown(Keys.P); } // Sprint 2 - Cycle Enemies (O/P)
        public Boolean Damaged() { return newState.IsKeyDown(Keys.E) || oldState.IsKeyDown(Keys.E); } // Sprint 2 - Damaged (E)



    }
}
