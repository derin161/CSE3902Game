﻿using CrossPlatformDesktopProject.Libraries.Command;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    public class Select : ICommand
    {
        private Game1 currentGame;
        public Select(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Restart();
        }
    }
}