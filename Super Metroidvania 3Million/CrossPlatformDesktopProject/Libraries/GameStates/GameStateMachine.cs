using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public class GameStateMachine
    {


        private static GameStateMachine instance = new GameStateMachine();
        private IGameState state;


        public static GameStateMachine Instance
        {
            get
            {
                return instance;
            }
        }

        public void Pause()
        {
            
        }
        public void Play()
        {
            
        }
        public void GameOver()
        {

        }
        public void GameWin()
        {

        }
        public void RoomTransition()
        {

        }
        public void ItemUpgradeSelection()
        {

        }

    }
}
