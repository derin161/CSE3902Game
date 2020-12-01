using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    //we might wanna get rid of this
    public interface IFactory
    {
        //Constructor
        public void LoadAllTextures(ContentManager content);

        //Enemies
        public List<ISprite> CreateEnemySpriteList(Vector2 location, Game1 game);

        //Projectiles
        public ISprite CreateBomb(Vector2 location);
        public ISprite CreateMissileRocket(Vector2 location, Vector2 direction);
        public ISprite CreatePowerBeam(Vector2 location, Vector2 direction, bool isLongBeam);
        public ISprite CreateIceBeam(Vector2 location, Vector2 direction, bool isLongBeam);
        public ISprite CreateWaveBeam(Vector2 location, Vector2 direction, bool isLongBeam, bool isIceBeam);
        public ISprite CreateKraidHorn(Vector2 location, bool isMovingRight);
        public ISprite CreateKraidMissile(Vector2 location, Vector2 direction);
        public ISprite CreatePlayerSprite();

        //Items
        public List<ISprite> CreateItemSpriteList(Vector2 location);

        //Map
        public ISprite CreateMapSprite();

        //Blocks
        public List<ISprite> CreateBlockSpriteList(Vector2 location);

    }
}
