using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class BlockSpriteFactory
    {
		//Blocks
		private Texture2D stockBlockBlue;
		private Texture2D bushBlockBlue;
		private Texture2D tubeBlockBlue;
		private Texture2D swirlBlockBlue;
		private Texture2D stockBlockOrange;
		private Texture2D bushBlockOrange;
		private Texture2D tubeBlockOrange;
		private Texture2D swirlBlockOrange;

		private Texture2D brickBlockBlue;
		private Texture2D circleBlockBlue;
		private Texture2D doorBottomLeftBlue;
		private Texture2D doorBottomRightBlue;
		private Texture2D doorMiddleLeftBlue;
		private Texture2D doorMiddleRightBlue;
		private Texture2D doorTopLeftBlue;
		private Texture2D doorTopRightBlue;
		private Texture2D fenceBlockBlue;
		private Texture2D metalBlockBlue;
		private Texture2D pipesBlockBlue;
		private Texture2D squareBlockBlue;
		private Texture2D brickBlockGreen;
		private Texture2D fenceBlockGreen;
		private Texture2D pipeBlockGreen;
		private Texture2D squareBlockGreen;
		private Texture2D lavaBlock;
		private Texture2D lavaBlockTop;
		private Texture2D brickBlockLightBlue;
		private Texture2D doorBlockOrange;
		private Texture2D circleBlockRed;
		private Texture2D crackedBlockRed;
		private Texture2D pipeLeftRed;
		private Texture2D pipeRightRed;
		private Texture2D roofSpikeBlock;

		private static BlockSpriteFactory instance = new BlockSpriteFactory();
		public static BlockSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private BlockSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//Blocks
			stockBlockBlue = content.Load<Texture2D>("BlockSprites/StockBlueBlock");
			bushBlockBlue = content.Load<Texture2D>("BlockSprites/BushBlueBlock");
			tubeBlockBlue = content.Load<Texture2D>("BlockSprites/TubeBlueBlock");
			swirlBlockBlue = content.Load<Texture2D>("BlockSprites/SwirlBlueBlock");
			stockBlockOrange = content.Load<Texture2D>("BlockSprites/StockOrangeBlock");
			bushBlockOrange = content.Load<Texture2D>("BlockSprites/BushOrangeBlock");
			tubeBlockOrange = content.Load<Texture2D>("BlockSprites/TubeOrangeBlock");
			swirlBlockOrange = content.Load<Texture2D>("BlockSprites/SwirlOrangeBlock");

			brickBlockBlue = content.Load<Texture2D>("BlockSprites/BlueBrickBlock");
			circleBlockBlue = content.Load<Texture2D>("BlockSprites/BlueCircleBlock");
			doorBottomLeftBlue = content.Load<Texture2D>("BlockSprites/BlueDoorBottomLeft");
			doorBottomRightBlue = content.Load<Texture2D>("BlockSprites/BlueDoorBottomRight");
			doorMiddleLeftBlue = content.Load<Texture2D>("BlockSprites/BlueDoorMiddleLeft");
			doorMiddleRightBlue = content.Load<Texture2D>("BlockSprites/BlueDoorMiddleRight");
			doorTopLeftBlue = content.Load<Texture2D>("BlockSprites/BlueDoorTopLeft");
			doorTopRightBlue = content.Load<Texture2D>("BlockSprites/BlueDoorTopRight");
			fenceBlockBlue = content.Load<Texture2D>("BlockSprites/BlueFenceBlock");
			metalBlockBlue = content.Load<Texture2D>("BlockSprites/BlueMetalBlock");
			pipesBlockBlue = content.Load<Texture2D>("BlockSprites/BluePipesBlock");
			squareBlockBlue = content.Load<Texture2D>("BlockSprites/BlueSquareBlock");
			brickBlockGreen = content.Load<Texture2D>("BlockSprites/GreenBrickBlock");
			fenceBlockGreen = content.Load<Texture2D>("BlockSprites/GreenFenceBlock");
			pipeBlockGreen = content.Load<Texture2D>("BlockSprites/GreenPipeBlock");
			squareBlockGreen = content.Load<Texture2D>("BlockSprites/GreenSquareBlock");
			lavaBlock = content.Load<Texture2D>("BlockSprites/LavaBlock");
			lavaBlockTop = content.Load<Texture2D>("BlockSprites/LavaBlockTop");
			brickBlockLightBlue = content.Load<Texture2D>("BlockSprites/LightBlueBrickBlock");
			doorBlockOrange = content.Load<Texture2D>("BlockSprites/OrangeDoorBlock");
			circleBlockRed = content.Load<Texture2D>("BlockSprites/RedCircleBlock");
			crackedBlockRed = content.Load<Texture2D>("BlockSprites/RedCrackedBlock");
			pipeLeftRed = content.Load<Texture2D>("BlockSprites/RedPipeLeft");
			pipeRightRed = content.Load<Texture2D>("BlockSprites/RedPipeRight");
			roofSpikeBlock = content.Load<Texture2D>("BlockSprites/RoofSpikeBlock");
	}
		
		//This method will probably be dropped and replaced by many more methods when the block sprites and game objects are separated.
		public List<ISprite> CreateBlockSpriteList(Vector2 location)
		{
			List<ISprite> blockList = new List<ISprite>();


			/*blockList.Add(new BlockSprite(stockBlockBlue, location));
			blockList.Add(new BlockSprite(bushBlockBlue, location));
			blockList.Add(new BlockSprite(swirlBlockBlue, location));
			blockList.Add(new BlockSprite(tubeBlockBlue, location));
			blockList.Add(new BlockSprite(stockBlockOrange, location));
			blockList.Add(new BlockSprite(bushBlockOrange, location));
			blockList.Add(new BlockSprite(swirlBlockOrange, location));
			blockList.Add(new BlockSprite(tubeBlockOrange, location));*/

			return blockList;
		}

		public ISprite CreateStockBlockBlueSprite(StockBlockBlue block)
        {
			return new StockBlockBlueSprite(stockBlockBlue, block);
        }
		public ISprite CreateBlueBrickBlockSprite(BlueBrickBlock block)
		{
			return new BlueBrickBlockSprite(brickBlockBlue, block);
		}
		public ISprite CreateBlueCircleBlockSprite(BlueCircleBlock block)
		{
			return new BlueCircleBlockSprite(circleBlockBlue, block);
		}
		public ISprite CreateBlueDoorBottomLeftSprite(BlueDoorBottomLeft block)
		{
			return new BlueDoorBottomLeftSprite(doorBottomLeftBlue, block);
		}
		public ISprite CreateBlueDoorBottomRightSprite(BlueDoorBottomRight block)
		{
			return new BlueDoorBottomRightSprite(doorBottomRightBlue, block);
		}
		public ISprite CreateBlueDoorMiddleLeftSprite(BlueDoorMiddleLeft block)
		{
			return new BlueDoorMiddleLeftSprite(doorMiddleLeftBlue, block);
		}
		public ISprite CreateBlueDoorMiddleRightSprite(BlueDoorMiddleRight block)
		{
			return new BlueDoorMiddleRightSprite(doorMiddleRightBlue, block);
		}
		public ISprite CreateBlueDoorTopLeftSprite(BlueDoorTopLeft block)
		{
			return new BlueDoorTopLeftSprite(doorTopLeftBlue, block);
		}
		public ISprite CreateBlueDoorTopRightSprite(BlueDoorTopRight block)
		{
			return new BlueDoorTopRightSprite(doorTopRightBlue, block);
		}
		public ISprite CreateBlueFenceBlockSprite(BlueFenceBlock block)
		{
			return new BlueFenceBlockSprite(fenceBlockBlue, block);
		}
		public ISprite CreateBlueMetalBlockSprite(BlueMetalBlock block)
		{
			return new BlueMetalBlockSprite(metalBlockBlue, block);
		}
		public ISprite CreateBluePipesBlockSprite(BluePipesBlock block)
		{
			return new BluePipesBlockSprite(pipesBlockBlue, block);
		}
		public ISprite CreateBlueSquareBlockSprite(BlueSquareBlock block)
		{
			return new BlueSquareBlockSprite(squareBlockBlue, block);
		}
		public ISprite CreateGreenBrickBlockSprite(GreenBrickBlock block)
		{
			return new GreenBrickBlockSprite(brickBlockGreen, block);
		}
		public ISprite CreateGreenFenceBlockSprite(GreenFenceBlock block)
		{
			return new GreenFenceBlockSprite(fenceBlockGreen, block);
		}
		public ISprite CreateGreenPipeBlockSprite(GreenPipeBlock block)
		{
			return new GreenPipeBlockSprite(pipeBlockGreen, block);
		}
		public ISprite CreateGreenSquareBlockSprite(GreenSquareBlock block)
		{
			return new GreenSquareBlockSprite(brickBlockGreen, block);
		}
		public ISprite CreateLavaBlockSprite(LavaBlock block)
		{
			return new LavaBlockSprite(lavaBlock, block);
		}
		public ISprite CreateLavaBlockTopSprite(LavaBlockTop block)
		{
			return new LavaBlockTopSprite(lavaBlockTop, block);
		}
		public ISprite CreateLightBlueBrickBlockSprite(LightBlueBrickBlock block)
		{
			return new LightBlueBrickBlockSprite(brickBlockLightBlue, block);
		}
		public ISprite CreateOrangeDoorBlockSprite(OrangeDoorBlock block)
		{
			return new OrangeDoorBlockSprite(doorBlockOrange, block);
		}
		public ISprite CreateRedCircleBlockSprite(RedCircleBlock block)
		{
			return new RedCircleBlockSprite(circleBlockRed, block);
		}
		public ISprite CreateRedCrackedBlockSprite(RedCrackedBlock block)
		{
			return new RedCrackedBlockSprite(crackedBlockRed, block);
		}
		public ISprite CreateRedPipeLeftSprite(RedPipeLeft block)
		{
			return new RedPipeLeftSprite(pipeLeftRed, block);
		}
		public ISprite CreateRedPipeRightSprite(RedPipeRight block)
		{
			return new RedPipeRightSprite(pipeRightRed, block);
		}
		public ISprite CreateRoofSpikeBlockSprite(RoofSpikeBlock block)
		{
			return new RoofSpikeBlockSprite(roofSpikeBlock, block);
		}
	}
}
