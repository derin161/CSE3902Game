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

        public IGameState Pause
        {
            get { return new PausedState(); }
        }
        public IGameState Play
        {
            get { return new PlayingState(); }
        }
        public IGameState GameOver
        {
            get { return new GameOverState(); }
        }
        public IGameState GameWin
        {
            get { return new GameWinState(); }
        }
        public IGameState RoomTransition
        {
            get { return new RoomTransitionState(); }
        }
        public IGameState ItemUpgradeSelection
        {
            get { return new ItemUpgradeSelectionState(); }
        }

    }
}
