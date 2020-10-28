using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.CSV;
using CrossPlatformDesktopProject.Libraries.Collision;

namespace CrossPlatformDesktopProject
{
    ///Authors: Alex Nguyen, Tristan Roman, Shyamal Shah, Nyigel Spann, Will Floyd, Danny Attia
    public class Game1 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardController keyboard;
        private GameTime gameTime;
        private string levelName;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameTime = new GameTime();
            levelName = "StartingLevel.csv";
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
            LoadCsv.Instance.Load(levelName);
            GameObjectContainer.Instance.RegisterPlayer(PlayerSpriteFactory.Instance.CreatePlayerSprite(new Vector2(0, 200), this, gameTime));
            keyboard = new KeyboardController(this);
        }

        protected override void UnloadContent()
        {
            // This method isn't needed.
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update(gameTime);
            GameObjectContainer.Instance.Update(gameTime);
            CollisionDetector.Instance.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            GameObjectContainer.Instance.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Restart(){
            // Create a new SpriteBatch, which can be used to draw textures.
            gameTime = new GameTime();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            ProjectilesSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            LoadCsv.Instance.Load(levelName);
            GameObjectContainer.Instance.RegisterPlayer(PlayerSpriteFactory.Instance.CreatePlayerSprite(new Vector2(0, 352), this, gameTime));
            keyboard = new KeyboardController(this);

        }
    }
}
