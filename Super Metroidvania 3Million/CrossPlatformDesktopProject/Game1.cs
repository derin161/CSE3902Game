using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.CSV;
using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.Camera;

namespace CrossPlatformDesktopProject
{
    ///Authors: Alex Nguyen, Tristan Roman, Shyamal Shah, Nyigel Spann, Will Floyd, Danny Attia
    public class Game1 : Game
    {
        public KeyboardController Keyboard { get; private set; }

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        private GameTime gameTime;
        private LevelStatePattern currentLevel;

        private Camera camera;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameTime = new GameTime();
            currentLevel = new LevelStatePattern();
            graphics.IsFullScreen = false;

            //Standard NES resolution:
            //graphics.PreferredBackBufferWidth = 256*2;        
            //graphics.PreferredBackBufferHeight = 240*2;
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

            Vector2 playerSpawnLocation = new Vector2(250, 352);
            GameObjectContainer.Instance.RegisterPlayer(PlayerSpriteFactory.Instance.CreatePlayerSprite(playerSpawnLocation, this, gameTime));
            camera = new HorizontalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
            camera.Focus = GameObjectContainer.Instance.Player;
            camera.CameraPosition = new Vector2(camera.Focus.SpaceRectangle().X - camera.Viewport.Width / camera.Zoom / 2, camera.CameraPosition.Y);
            SoundManager.Instance.LoadAllSounds(Content);
            Keyboard = new KeyboardController(this);
            GameStateMachine.Instance.RegisterGame(this);
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
            camera.Update();
            graphics.GraphicsDevice.Viewport = new Viewport(-(int)camera.CameraPosition.X, (int)camera.CameraPosition.Y, 800, 480);
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

        public void Restart(){
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

            Vector2 playerSpawnLocation = new Vector2(250, 352);
            GameObjectContainer.Instance.RegisterPlayer(PlayerSpriteFactory.Instance.CreatePlayerSprite(playerSpawnLocation, this, gameTime));
            camera = new HorizontalCamera(graphics.GraphicsDevice.Viewport) { Zoom = 2f };
            camera.Focus = GameObjectContainer.Instance.Player;
            camera.CameraPosition = new Vector2(camera.Focus.SpaceRectangle().X - camera.Viewport.Width / camera.Zoom / 2, camera.CameraPosition.Y);
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
            return camera;
        }
        public void SetCamera(Camera newCamera)
        {
            camera = newCamera;
        }
    }
}
