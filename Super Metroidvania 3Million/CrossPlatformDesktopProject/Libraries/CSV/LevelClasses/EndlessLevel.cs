using Microsoft.Xna.Framework;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV.Object_Generators;
using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using System;
using System.Collections.Generic;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Will Floyd
    public class EndlessLevel : IStageState
    {
        private Game1 game;

        public EndlessLevel(Game1 game)
        {
            this.game = game;
        }

        public void LeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void RightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopLeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void TopRightDoor()
        {
            // Do nothing - door does not exist
        }
        public void BottomLeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void BottomRightDoor()
        {
            // Do nothing - door does not exist
        }
        public void FarBottomLeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void FarBottomRightDoor()
        {
            // Do nothing - door does not exist
        }
        public void AddEnemy()
        {
            //Random enemy at random location, y values need to be predetermined and Geega already keeps spawning

            //Make a list of possible enemies to spawn in and pick a random one
            List<String> enemyList = new List<string>(){ "Zeela", "Kraid", "Skree", "SideHopper", "Memu" };
            int index = new Random().Next(0, enemyList.Count);
            String enemy = enemyList[index];




            //Randomly generate location (Map goes from 32 to 
            int xLocation = new Random().Next(64, 736);

            if (GameObjectContainer.Instance.EnemyList.Count == 2)
            {
                EnemyObjectGenerator.Instance.createEnemy(new Vector2(xLocation, 100), enemy, game);
            }
        }

    }
}
