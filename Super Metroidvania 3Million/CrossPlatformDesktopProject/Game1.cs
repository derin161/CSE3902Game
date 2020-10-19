using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;

namespace CrossPlatformDesktopProject
{
    ///Authors: Alex Nguyen, Tristan Roman, Shyamal Shah, Nyigel Spann, Will Floyd, Danny Attia
    public class Game1 : Game
    {

        public List<ISprite> SpriteList = new List<ISprite>(); //public for now. Maybe a class to hold sprites.
        public List<ISprite> DeadSprites = new List<ISprite>();
        public List<ISprite> enemySprites = new List<ISprite>();
        public int enemyIndex = 0;
        public List<ISprite> itemSprites = new List<ISprite>();
        public int itemIndex = 0;

        //Map that allows for multiple block sprite lists with mappings to their types so can have multiple different block sprites on screen at once
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

        protected override void Initialize()
        {
            base.Initialize();
        }
        
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
            int blockY = 256;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 0);
            blockX += 32;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 1);
            blockX += 32;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 1);
            blockX += 32;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 0);

            
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

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
            foreach (List<ISprite> entry in blockSpriteListIndexes.Keys.ToList())
            {
                blockSpriteListIndexes.TryGetValue(entry, out result);
                entry[result].Update(gameTime);
            }

            enemySprites[enemyIndex].Update(gameTime);
            itemSprites[itemIndex].Update(gameTime);

            foreach (ISprite dead in DeadSprites){
                SpriteList.Remove(dead);
            }
            DeadSprites.Clear();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (ISprite entry in SpriteList) {
                entry.Draw(spriteBatch);
            }

            int result;
            foreach (List<ISprite> entry in blockSpriteListIndexes.Keys.ToList())
            {
                blockSpriteListIndexes.TryGetValue(entry, out result);
                entry[result].Draw(spriteBatch);
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

            // Assign itemSprites list to new sprite list 
            itemSprites = Factory.CreateItemSpriteList(new Vector2(700, 325));

            // Clear block map and re-add blocks
            blockSpriteListIndexes.Clear();
            int blockX = 672;
            int blockY = 256;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 0);
            blockX += 32;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 1);
            blockX += 32;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 1);
            blockX += 32;
            blockSpriteListIndexes.Add(Factory.CreateBlockSpriteList(new Vector2(blockX, blockY)), 0);
        }
    }
}
