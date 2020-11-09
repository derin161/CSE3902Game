using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Items.Sprites;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class ItemSpriteFactory
    {
		//Items
		private Texture2D bombItem;
		private Texture2D energyDropItem;
		private Texture2D energyTankItem;
		private Texture2D highJumpItem;
		private Texture2D iceBeamItem;
		private Texture2D longBeamItem;
		private Texture2D missileRocketItem;
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
			missileRocketItem = content.Load<Texture2D>("Items/MissleRocket");
			morphBallItem = content.Load<Texture2D>("Items/MorphBall");
			rocketDropItem = content.Load<Texture2D>("Items/RocketDropItem");
			screwAttackItem = content.Load<Texture2D>("Items/ScrewAttack");
			variaItem = content.Load<Texture2D>("Items/Varia");
			waveBeamItem = content.Load<Texture2D>("Items/WaveBeam");
		}

		public ISprite BombItemSprite(IItem b)
		{
			return new UpgradeItemSprite(bombItem, b);
		}

		public ISprite EnergyDropItemSprite(IItem ed)
		{
			return new UpgradeItemSprite(energyDropItem, ed);
		}

		public ISprite EnergyTankItemSprite(IItem et)
		{
			return new UpgradeItemSprite(energyTankItem, et);
		}
		public ISprite HighJumpItemSprite(IItem h)
		{
			return new UpgradeItemSprite(highJumpItem, h);
		}
		public ISprite IceBeamItemSprite(IItem i)
		{
			return new UpgradeItemSprite(iceBeamItem, i);
		}
		public ISprite LongBeamItemSprite(IItem l)
		{
			return new UpgradeItemSprite(longBeamItem, l);
		}
		public ISprite MissleRocketItemSprite(IItem mr)
		{
			return new UpgradeItemSprite(missileRocketItem, mr);
		}
		public ISprite MorphBallItemSprite(IItem mb)
		{
			return new UpgradeItemSprite(morphBallItem, mb);
		}
		public ISprite RocketDropItemSprite(IItem r)
		{
			return new UpgradeItemSprite(rocketDropItem, r);
		}
		public ISprite ScrewAttackItemSprite(IItem s)
		{
			return new UpgradeItemSprite(screwAttackItem, s);
		}
		public ISprite VariaItemSprite(IItem v)
		{
			return new UpgradeItemSprite(variaItem, v);
		}
		public ISprite WaveBeamItemSprite(IItem w)
		{
			return new UpgradeItemSprite(waveBeamItem, w);
		}
	}
}
