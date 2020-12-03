using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Command.PlayerCommands;
using Microsoft.Xna.Framework;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Controller
{
    public class KeyboardController : IController
    {
        //Written by Tristan Roman and Shyamal Shah and Nyigel Spann and Will Floyd
        private Dictionary<Keys, ICommand> controllerPressMappings = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> controllerReleaseMappings = new Dictionary<Keys, ICommand>();

        private KeyboardState oldState;
        private KeyboardState newState;
        private Game1 game;

        public KeyboardController(Game1 game)
        {
            oldState = Keyboard.GetState();
            this.game = game;
        }
        public void RegisterCommand(Keys key, ICommand releaseCommand)
        {
            if (!controllerReleaseMappings.ContainsKey(key))
            {
                controllerReleaseMappings.Add(key, releaseCommand);
            }
            else
            {
                controllerReleaseMappings[key] = releaseCommand;
            }
        }

        public void RegisterCommand(Keys key, ICommand pressCommand, ICommand releaseCommand)
        {
            if (!controllerPressMappings.ContainsKey(key))
            {
                controllerPressMappings.Add(key, pressCommand);
                controllerReleaseMappings.Add(key, releaseCommand);
            }
            else
            {
                controllerPressMappings[key] = pressCommand;
                controllerReleaseMappings[key] = releaseCommand;
            }
        }

        public void Update(GameTime gameTime)
        {
            newState = Keyboard.GetState();

            foreach (Keys key in oldState.GetPressedKeys())
            {
                if (controllerPressMappings.ContainsKey(key) && newState.IsKeyDown(key))
                {
                    controllerPressMappings[key].Execute();
                }
                else if (controllerReleaseMappings.ContainsKey(key) && !newState.IsKeyDown(key))
                {
                    controllerReleaseMappings[key].Execute();
                }

            }

            oldState = newState;

        }


        public void MakePlayDict()     // If else of possible actions that updates choice
        {
            IPlayer player = GameObjectContainer.Instance.Player; // The player sprite

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();

            IDisableableCommand jump = new PlayerJumpCommand(player);
            RegisterCommand(Keys.Space, jump, new EnableCommandCommand(jump));

            IDisableableCommand aimUp = new PlayerAimUpCommand(player);
            RegisterCommand(Keys.W, aimUp, new EnableCommandCommand(aimUp));
            RegisterCommand(Keys.Up, aimUp, new EnableCommandCommand(aimUp));

            RegisterCommand(Keys.S, new PlayerMorphCommand(player), new PlayerIdleCommand(player));
            RegisterCommand(Keys.Down, new PlayerMorphCommand(player), new PlayerIdleCommand(player));

            RegisterCommand(Keys.A, new PlayerMoveLeftCommand(player), new PlayerIdleCommand(player));
            RegisterCommand(Keys.Left, new PlayerMoveLeftCommand(player), new PlayerIdleCommand(player));

            RegisterCommand(Keys.D, new PlayerMoveRightCommand(player), new PlayerIdleCommand(player));
            RegisterCommand(Keys.Right, new PlayerMoveRightCommand(player), new PlayerIdleCommand(player));

            IDisableableCommand attack = new PlayerAttackCommand(player);
            RegisterCommand(Keys.Z, attack, new EnableCommandCommand(attack));
            RegisterCommand(Keys.N, attack, new EnableCommandCommand(attack));

            IDisableableCommand cycleBeamMissile = new CycleBeamMissileCommand(player);
            RegisterCommand(Keys.C, cycleBeamMissile, new EnableCommandCommand(cycleBeamMissile));

            RegisterCommand(Keys.Q, new QuitCommand(game));

            RegisterCommand(Keys.R, new RestartCommand(game));

            RegisterCommand(Keys.T, new CycleLevelCommand(game));

            RegisterCommand(Keys.F, new ToggleFullscreenCommand(game));

            RegisterCommand(Keys.K, new PlayNextThemeCommand());
            RegisterCommand(Keys.L, new ShuffleThemesCommand());
            RegisterCommand(Keys.O, new UnShuffleThemesCommand());
            RegisterCommand(Keys.P, new PauseGameCommand());

            RegisterCommand(Keys.Escape, new SetMenuStateCommand(new InGameMenuState(game)));

        }
        public void MakePausedDict()
        {
            IPlayer player = GameObjectContainer.Instance.Player; // The player GO

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();


            RegisterCommand(Keys.P, new UnpauseGameCommand());

        }
        public void MakeGameWinLoseDict()
        {
            IPlayer player = GameObjectContainer.Instance.Player; // The player GO

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();


            RegisterCommand(Keys.R, new RestartCommand(game));

        }

        public void MakeMenuDict(IMenuState menuState)
        {

            controllerPressMappings.Clear();
            controllerReleaseMappings.Clear();


            RegisterCommand(Keys.W, new MenuUpCommand(menuState));
            RegisterCommand(Keys.Up, new MenuUpCommand(menuState));

            RegisterCommand(Keys.S, new MenuDownCommand(menuState));
            RegisterCommand(Keys.Down, new MenuDownCommand(menuState));

            RegisterCommand(Keys.A, new MenuLeftCommand(menuState));
            RegisterCommand(Keys.Left, new MenuLeftCommand(menuState));

            RegisterCommand(Keys.D, new MenuRightCommand(menuState));
            RegisterCommand(Keys.Right, new MenuRightCommand(menuState));

            RegisterCommand(Keys.Escape, new MenuExitCommand(menuState));

            RegisterCommand(Keys.Enter, new MenuPressCommand(menuState));
        }
    }
}

