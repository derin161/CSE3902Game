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

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private GameTime gameTime;
        private LevelStatePattern currentLevel;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameTime = new GameTime();
            currentLevel = new LevelStatePattern();
            graphics.IsFullScreen = false;

            //graphics.PreferredBackBufferWidth = 1900;
            //graphics.PreferredBackBufferHeight = 1260;

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
            Camera = new HorizontalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
            Camera.Focus = GameObjectContainer.Instance.Player;
            //Camera.CameraPosition = new Vector2(Camera.Focus.SpaceRectangle().X - Camera.Viewport.Width / Camera.Zoom / 2, Camera.CameraPosition.Y);
            Camera.CameraPosition = new Vector2(0, 0);
            SoundManager.Instance.LoadAllSounds(Content);
            SoundManager.Instance.Songs.PlayBrinstarTheme();

            Keyboard = new KeyboardController(this);
            GameStateMachine.Instance.RegisterGame(this);
            GameStateMachine.Instance.MenuState(new StartMenuState(this));
            currentLevel.Initialize(playerSpawnLocation, this);
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

            if (GameStateMachine.Instance.IsPlaying()) {
                graphics.GraphicsDevice.Viewport = new Viewport(-(int)Camera.CameraPosition.X, (int)Camera.CameraPosition.Y, 1600, 480);
            } else {
                graphics.GraphicsDevice.Viewport = new Viewport(0, 0, 1200, 480);
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
            Camera = new HorizontalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
            Camera.Focus = GameObjectContainer.Instance.Player;
            Camera.CameraPosition = new Vector2(0, 0);
            //Camera.CameraPosition = new Vector2(Camera.Focus.SpaceRectangle().X - Camera.Viewport.Width / Camera.Zoom / 2, Camera.CameraPosition.Y);
            Keyboard = new KeyboardController(this);
            GameStateMachine.Instance.RegisterGame(this);
            GameStateMachine.Instance.Play();
            currentLevel.Initialize(playerSpawnLocation, this);
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
        public void EnterSecretRoom()
        {
            SoundManager.Instance.Songs.PlaySecretAreaTheme();
        }
        public void EnterBrinstarRoom()
        {
            SoundManager.Instance.Songs.PlayBrinstarTheme();
        }
        public void EnterBossRoom()
        {
            SoundManager.Instance.Songs.PlayRidleysHidoutTheme();
        }
    }
}
