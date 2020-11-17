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

        private GameStateMachine()
        {
            state = new PlayingState();
        }
        public static GameStateMachine Instance
        {
            get
            {
                return instance;
            }
        }

        public void Pause()
        {
            state = new PausedState();
        }
        public void Play()
        {
            state = new PlayingState();
        }
        public void GameOver()
        {
            state = new GameOverState();
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

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

    }
}
