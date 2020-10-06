using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CrossPlatformDesktopProject.Libraries.Sprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using System.Net;
using System.Diagnostics;

namespace CrossPlatformDesktopProject
{
    ///Authors: Alex Nguyen, Tristan Roman, Shyamal Shah, Nyigel Spann, Will Floyd, Danny Attia
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        public List<ISprite> SpriteList = new List<ISprite>(); //public for now. Maybe a class to hold sprites.
        public List<ISprite> DeadSprites = new List<ISprite>();
        public List<ISprite> enemySprites = new List<ISprite>();
        public int enemyIndex = 0;
        public List<ISprite> itemSprites = new List<ISprite>();
        public int itemIndex = 0;

        //Four different block sprite lists so can have for different block sprites on the screen at once
        public List<ISprite> leftBlockSprites = new List<ISprite>();
        public List<ISprite> midLeftBlockSprites = new List<ISprite>();
        public List<ISprite> midRightBlockSprites = new List<ISprite>();
        public List<ISprite> rightBlockSprites = new List<ISprite>();

        //Map that maps sprite list to block types
        public Dictionary<List<ISprite>, int> blockSpriteListIndexes = new Dictionary<List<ISprite>, int>();

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public IFactory Factory { get; set;}
        private KeyboardController keyboard;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Add block sprite lists to map with mappings to initial block types
            blockSpriteListIndexes.Add(leftBlockSprites, 0);
            blockSpriteListIndexes.Add(midLeftBlockSprites, 1);
            blockSpriteListIndexes.Add(midRightBlockSprites, 1);
            blockSpriteListIndexes.Add(rightBlockSprites, 0);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteList = new List<ISprite>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Factory = SpriteFactory.Instance;
            Factory.LoadAllTextures(Content);
            AddSprite(Factory.CreateMapSprite());
            AddSprite(Factory.CreatePlayerSprite());
            keyboard = new KeyboardController(this);
            enemySprites = Factory.CreateEnemySpriteList(new Vector2(400, 250), this);
            itemSprites = Factory.CreateItemSpriteList(new Vector2(700, 325));

            // Create block sprite list for four different blocks in different locations
            int blockX = 672;
            int blockY = 288;
            foreach (List<ISprite> entry in blockSpriteListIndexes)
            {
                entry = Factory.CreateBlockSpriteList(new Vector2(blockX, blockY));
                blockX+=32;
            }

            
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard.Update(gameTime);
            foreach (ISprite entry in SpriteList)
            {
                entry.Update(gameTime);

                if(entry == SpriteList[0] && entry.IsDead()) {
                    //game over sequence
                } else if (entry.IsDead()) {
                    DeadSprites.Add(entry);
                }

            }

            int result;
            foreach (List<ISprite> entry in blockSpriteListIndexes)
            {
                result = blockSpriteListIndexes.TryGetValue(entry, out result);
                entry[result].Update(SpriteBatch);
            }

            enemySprites[enemyIndex].Update(gameTime);
            itemSprites[itemIndex].Update(gameTime);

            foreach (ISprite dead in DeadSprites){
                SpriteList.Remove(dead);
            }
            DeadSprites.Clear();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (ISprite entry in SpriteList) {
                entry.Draw(spriteBatch);
            }

            int result;
            foreach (List<ISprite> entry in blockSpriteListIndexes)
            {
                result = blockSpriteListIndexes.TryGetValue(entry, out result);
                entry[result].Draw(SpriteBatch);
            }

            enemySprites[enemyIndex].Draw(spriteBatch);
            itemSprites[itemIndex].Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void AddSprite(ISprite s) {
            SpriteList.Add(s);
        }

        public void Restart(){
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteList = new List<ISprite>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Factory = SpriteFactory.Instance;
            Factory.LoadAllTextures(Content);
            AddSprite(Factory.CreateMapSprite());
            AddSprite(Factory.CreatePlayerSprite());
            keyboard = new KeyboardController(this);
            enemyIndex = 0;
            itemIndex = 0;
        }
    }
}
