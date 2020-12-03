using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Container
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
        public void RoomTransition()
        {

        }
        public void ItemUpgradeSelection()
        {
            //Sprint 5 additional feature
        }

        public void MenuState(IMenuState menuState)
        {
            state = menuState;
            game.Keyboard.MakeMenuDict(menuState);
        }

        public bool IsPlaying()
        {
            return state is PlayingState;
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
