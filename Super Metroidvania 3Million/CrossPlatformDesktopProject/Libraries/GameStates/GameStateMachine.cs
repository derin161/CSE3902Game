using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Controller;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public class GameStateMachine
    {


        private static GameStateMachine instance = new GameStateMachine();
        private IGameState state;
        private KeyboardController controller;

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
        public void RegisterKeyboardController(KeyboardController c)
        {
            controller = c;
            controller.MakePlayDict();
        }

        public void Pause()
        {
            state = new PausedState();
            controller.MakePausedDict();
        }
        public void Play()
        {
            state = new PlayingState();
            controller.MakePlayDict();
        }
        public void GameOver()
        {

        }
        public void GameWin()
        {
            state = new GameWinState();
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
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

    }
}
