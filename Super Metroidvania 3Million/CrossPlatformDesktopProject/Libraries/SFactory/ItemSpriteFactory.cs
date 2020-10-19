using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class ItemSpriteFactory : IFactory
    {
		//Items
		private Texture2D bombItem;
		private Texture2D energyDropItem;
		private Texture2D energyTankItem;
		private Texture2D highJumpItem;
		private Texture2D iceBeamItem;
		private Texture2D longBeamItem;
		private Texture2D missleRocketItem;
		private Texture2D morphBallItem;
		private Texture2D rocketDropItem;
		private Texture2D screwAttackItem;
		private Texture2D variaItem;
		private Texture2D waveBeamItem;

		private static ItemSpriteFactory instance = new ItemSpriteFactory();
		public static ItemSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ItemSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//Items
			bombItem = content.Load<Texture2D>("Items/Bomb");
			energyDropItem = content.Load<Texture2D>("Items/EnergyDropItem");
			energyTankItem = content.Load<Texture2D>("Items/EnergyTank");
			highJumpItem = content.Load<Texture2D>("Items/HighJump");
			iceBeamItem = content.Load<Texture2D>("Items/IceBeam");
			longBeamItem = content.Load<Texture2D>("Items/LongBeam");
			missleRocketItem = content.Load<Texture2D>("Items/MissleRocket");
			morphBallItem = content.Load<Texture2D>("Items/MorphBall");
			rocketDropItem = content.Load<Texture2D>("Items/RocketDropItem");
			screwAttackItem = content.Load<Texture2D>("Items/ScrewAttack");
			variaItem = content.Load<Texture2D>("Items/Varia");
			waveBeamItem = content.Load<Texture2D>("Items/WaveBeam");
		}

		public List<ISprite> CreateItemSpriteList(Vector2 location)
		{
			List<ISprite> itemList = new List<ISprite>();
			itemList.Add(new BombItem(bombItem, location));
			itemList.Add(new EnergyDropItem(energyDropItem, location));
			itemList.Add(new EnergyTankItem(energyTankItem, location));
			itemList.Add(new HighJumpItem(highJumpItem, location));
			itemList.Add(new IceBeamItem(iceBeamItem, location));
			itemList.Add(new LongBeamItem(longBeamItem, location));
			itemList.Add(new MissleRocketItem(missleRocketItem, location));
			itemList.Add(new MorphBallItem(morphBallItem, location));
			itemList.Add(new RocketDropItem(rocketDropItem, location));
			itemList.Add(new ScrewAttackItem(screwAttackItem, location));
			itemList.Add(new VariaItem(variaItem, location));
			itemList.Add(new WaveBeamItem(waveBeamItem, location));

			return itemList;
		}
	}
}
