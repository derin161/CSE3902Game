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
        private List<String> enemyList;
        private Dictionary<String, int> enemyDict;

        public EndlessLevel(Game1 game)
        {
            this.game = game;
            enemyList = new List<string>() { "Zeela", "Kraid", "Skree", "SideHopper", "Memu" };

            //Make dictionary with y values for the enemies
            enemyDict = new Dictionary<String, int>();
            enemyDict.Add("Zeela", 384);
            enemyDict.Add("Kraid", 352);
            enemyDict.Add("Skree", 64);
            enemyDict.Add("SideHopper", 352);
            enemyDict.Add("Memu", 128);

        }

        public void LeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void RightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void BottomLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void BottomRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void AddEnemy()
        {
            //Random enemy at random location, y values need to be predetermined and Geega already keeps spawning

            //Make a list of possible enemies to spawn in and pick a random one
            int index = new Random().Next(0, enemyList.Count);
            String enemy = enemyList[index];


            if (GameObjectContainer.Instance.EnemyList.Count == 2)
            {
                int xLocation = new Random().Next(64, 736);
                EnemyObjectGenerator.Instance.createEnemy(new Vector2(xLocation, enemyDict[enemy]), enemy, game);
            }
        }

    }
}
