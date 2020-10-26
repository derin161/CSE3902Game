using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;

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

		public ISprite BombItemSprite(BombItem b)
		{
			return new BombItemSprite(bombItem, b);
		}

		public ISprite EnergyDropItemSprite(EnergyDropItem ed)
		{
			return new EnergyDropItemSprite(energyDropItem, ed);
		}

		public ISprite EnergyTankItemSprite(EnergyTankItem et)
		{
			return new EnergyTankItemSprite(energyTankItem, et);
		}
		public ISprite HighJumpItemSprite(HighJumpItem h)
		{
			return new HighJumpItemSprite(highJumpItem, h);
		}
		public ISprite IceBeamItemSprite(IceBeamItem i)
		{
			return new IceBeamItemSprite(iceBeamItem, i);
		}
		public ISprite LongBeamItemSprite(LongBeamItem l)
		{
			return new LongBeamItemSprite(longBeamItem, l);
		}
		public ISprite MissleRocketItemSprite(MissileRocketItem mr)
		{
			return new MissleRocketItemSprite(missleRocketItem, mr);
		}
		public ISprite MorphBallItemSprite(MorphBallItem mb)
		{
			return new MorphBallItemSprite(morphBallItem, mb);
		}
		public ISprite RocketDropItemSprite(RocketDropItem r)
		{
			return new RocketDropItemSprite(rocketDropItem, r);
		}
		public ISprite ScrewAttackItemSprite(ScrewAttackItem s)
		{
			return new ScrewAttackItemSprite(screwAttackItem, s);
		}
		public ISprite VariaItemSprite(VariaItem v)
		{
			return new VariaItemSprite(variaItem, v);
		}
		public ISprite WaveBeamItemSprite(WaveBeamItem w)
		{
			return new WaveBeamItemSprite(waveBeamItem, w);
		}
	}
}
