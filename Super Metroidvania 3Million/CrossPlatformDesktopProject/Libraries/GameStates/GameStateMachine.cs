using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Authors: Will Floyd & Nyigel Spann
    public class GameStateMachine
    {


        private static GameStateMachine instance = new GameStateMachine();
        private IGameState state;
        private Game1 game;

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
        public void RegisterGame(Game1 game)
        {
            this.game = game;
            game.Keyboard.MakePlayDict();
        }

        public void Pause()
        {
            state = new PausedState();
            game.Keyboard.MakePausedDict();
        }
        public void Play()
        {
            state = new PlayingState();
            game.Keyboard.MakePlayDict();
        }
        public void GameOver()
        {
            state = new GameOverState();
            game.Keyboard.MakeGameWinLoseDict();
        }
        public void GameWin()
        {
            state = new GameWinState();
            game.Keyboard.MakeGameWinLoseDict();
        }
        public void RoomTransition()
        {
            
        }
        public void ItemUpgradeSelection()
        {
            //Sprint 5 additional feature
        }

        public void MenuState(IMenuState menuState) {
            state = menuState;
            game.Keyboard.MakeMenuDict(menuState);
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
