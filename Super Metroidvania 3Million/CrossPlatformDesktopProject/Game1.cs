using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.SFactory;
using SuperMetroidvania5Million.Libraries.Controller;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV;
using SuperMetroidvania5Million.Libraries.Audio;
using SuperMetroidvania5Million.Libraries.Camera;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million
{
    ///Authors: Alex Nguyen, Tristan Roman, Shyamal Shah, Nyigel Spann, Will Floyd, Danny Attia
    public class Game1 : Game
    {
        public KeyboardController Keyboard { get; private set; }
        public Camera Camera { get; set; }
        public Camera HorizontalCamera;
        public Vector2 StartingCameraPos;

        public bool endlessMode;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameTime gameTime;
        private LevelStatePattern currentLevel;
        private EndlessLevel endlessLevel;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameTime = new GameTime();
            currentLevel = LevelStatePattern.Instance;
            graphics.IsFullScreen = false;
            endlessLevel = new EndlessLevel(this);

            //graphics.PreferredBackBufferWidth = 1920;
            //graphics.PreferredBackBufferHeight = 1080;

            //Standard NES resolution:
            graphics.PreferredBackBufferWidth = 256*2;        
            graphics.PreferredBackBufferHeight = 240*2;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ProjectilesSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            MenuSpriteFactory.Instance.LoadAllTextures(Content);

            Vector2 playerSpawnLocation = new Vector2(368, 352);
            GameObjectContainer.Instance.RegisterPlayer(PlayerSpriteFactory.Instance.CreatePlayerSprite(playerSpawnLocation, this, gameTime));
            HorizontalCamera = new HorizontalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
            SetCamera(true); // Horizontal camera
            SoundManager.Instance.LoadAllSounds(Content);
            SoundManager.Instance.Songs.PlayBrinstarTheme();

            Keyboard = new KeyboardController(this);
            GameStateMachine.Instance.RegisterGame(this);
            GameStateMachine.Instance.MenuState(new StartMenuState(this));
        }

        protected override void UnloadContent()
        {
            // This method isn't needed.
        }

        protected override void Update(GameTime gameTime)
        {
            GameStateMachine.Instance.Update(gameTime);
            Keyboard.Update(gameTime);
            SoundManager.Instance.Update(gameTime);
            Camera.Update(gameTime);

            if (GameStateMachine.Instance.IsPlaying() && Camera.isHorizontalCamera) {
                graphics.GraphicsDevice.Viewport = new Viewport((int)(-Camera.CameraPosition.X - StartingCameraPos.X), (int)Camera.CameraPosition.Y, 1600, 2000);  // Offset 208
            } else if ((GameStateMachine.Instance.IsPlaying() && !Camera.isHorizontalCamera)) {
                graphics.GraphicsDevice.Viewport = new Viewport(-(int)Camera.CameraPosition.X, (int)(-Camera.CameraPosition.Y - StartingCameraPos.Y - 32), 1600, 2000); ; // Offset 32
            } else {
                graphics.GraphicsDevice.Viewport = new Viewport(0, 0, 800, 480);
            }

            if (endlessMode)
            {
                endlessLevel.AddEnemy();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            GameStateMachine.Instance.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Restart()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            gameTime = new GameTime();
            SoundManager.Instance.Songs.PlayBrinstarTheme();
            GameObjectContainer.Instance.Clear();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ProjectilesSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            Vector2 playerSpawnLocation = new Vector2(368, 352);
            GameObjectContainer.Instance.RegisterPlayer(PlayerSpriteFactory.Instance.CreatePlayerSprite(playerSpawnLocation, this, gameTime));
            SetCamera(true);
            Keyboard = new KeyboardController(this);
            GameStateMachine.Instance.RegisterGame(this);
            GameStateMachine.Instance.MenuState(new StartMenuState(this));
        }

        public void Fullscreen()
        {
            graphics.ToggleFullScreen();
        }
        public void ChangeResolution(int width, int height)
        {
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();
        }
        public Camera GetCamera()
        {
            return Camera;
        }
        public void SetCamera(bool isHorizontal)
        {
            if (isHorizontal)
            {
                Camera = HorizontalCamera;
                //Camera = new HorizontalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
                //StartingCameraPos = new Vector2((int)(GameObjectContainer.Instance.Player.GetPlayerLocation().X), 0);
            }
            else
            {
                Camera = new VerticalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
                StartingCameraPos = new Vector2(0, (int)(GameObjectContainer.Instance.Player.GetPlayerLocation().Y)+200);
            }
            Camera.Focus = GameObjectContainer.Instance.Player;
            Camera.isHorizontalCamera = isHorizontal;

        }
        public void EnterSecretRoom()
        {
            if (!SongManager.Instance.LoopMode)
                SongManager.Instance.PlaySecretAreaTheme();           
        }
        public void EnterBrinstarRoom()
        {
            if (!SongManager.Instance.LoopMode)
                SongManager.Instance.PlayBrinstarTheme();
        }
        public void EnterBossRoom()
        {
            if (!SongManager.Instance.LoopMode)
                SongManager.Instance.PlayRidleysHidoutTheme();
        }
    }
}
