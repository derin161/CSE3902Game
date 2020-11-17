using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public class GameOverState : IGameState
    {
        private Texture2D Texture { get; set; }
        private static GameOverState instance = new GameOverState();
        public static GameOverState Instance
        {
            get
            {
                return instance;
            }
        }

        public GameOverState()
        {
        }

        public void LoadTextures(ContentManager content)
        {
            Texture = content.Load<Texture2D>("NES_Metroid_Game_Over");
        }
        public void Update(GameTime gameTime)
        {
            //Do nothing since screen will transition to blank with words game over
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(20, 200, 250, 60);
            spriteBatch.Draw(Texture, sourceRectangle, Color.White);
        }
    }
}
