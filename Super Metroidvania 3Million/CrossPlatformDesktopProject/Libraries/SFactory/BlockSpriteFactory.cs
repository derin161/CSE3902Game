﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks.BlockSprites;

namespace SuperMetroidvania5Million.Libraries.SFactory
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
        private Texture2D bushBlockSilver;
        private Texture2D dualHorizontalBlockStone;
        private Texture2D leftStartingPlatformBlock;
        private Texture2D redDoorBottomLeftBlock;
        private Texture2D redDoorBottomRightBlock;
        private Texture2D redDoorMiddleLeftBlock;
        private Texture2D redDoorMiddleRightBlock;
        private Texture2D redDoorTopLeftBlock;
        private Texture2D redDoorTopRightBlock;
        private Texture2D rightStartingPlatformBlock;
        private Texture2D stockBlockStone;
        private Texture2D stoneBlockWithEyes;
        private Texture2D verticalTubeStoneBlock;

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

            bushBlockSilver = content.Load<Texture2D>("BlockSprites/BushSilverBlock");
            dualHorizontalBlockStone = content.Load<Texture2D>("BlockSprites/DualHorizontalStoneBlock");
            leftStartingPlatformBlock = content.Load<Texture2D>("BlockSprites/LeftStartingPlatform");
            redDoorBottomLeftBlock = content.Load<Texture2D>("BlockSprites/RedDoorBottomLeft");
            redDoorBottomRightBlock = content.Load<Texture2D>("BlockSprites/RedDoorBottomRight");
            redDoorMiddleLeftBlock = content.Load<Texture2D>("BlockSprites/RedDoorMiddleLeft");
            redDoorMiddleRightBlock = content.Load<Texture2D>("BlockSprites/RedDoorMiddleRight");
            redDoorTopLeftBlock = content.Load<Texture2D>("BlockSprites/RedDoorTopLeft");
            redDoorTopRightBlock = content.Load<Texture2D>("BlockSprites/RedDoorTopRight");
            rightStartingPlatformBlock = content.Load<Texture2D>("BlockSprites/RightStartingPlatform");
            stockBlockStone = content.Load<Texture2D>("BlockSprites/StockStoneBlock");
            stoneBlockWithEyes = content.Load<Texture2D>("BlockSprites/StoneBlockWithEyes");
            verticalTubeStoneBlock = content.Load<Texture2D>("BlockSprites/VerticalTubeStoneBlock");


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
            lavaBlockTop = content.Load<Texture2D>("BlockSprites/LavaTop");
            brickBlockLightBlue = content.Load<Texture2D>("BlockSprites/LightBlueBrickBlock");
            doorBlockOrange = content.Load<Texture2D>("BlockSprites/OrangeDoorBlock");
            circleBlockRed = content.Load<Texture2D>("BlockSprites/RedCircleBlock");
            crackedBlockRed = content.Load<Texture2D>("BlockSprites/RedCrackedBlock");
            pipeLeftRed = content.Load<Texture2D>("BlockSprites/RedPipeLeft");
            pipeRightRed = content.Load<Texture2D>("BlockSprites/RedPipeRight");
            roofSpikeBlock = content.Load<Texture2D>("BlockSprites/RoofSpikeBlock");
        }

        public ISprite CreateStockBlockBlueSprite(StockBlockBlue block)
        {
            return new DrawBlockSprites(stockBlockBlue, block);
        }
        public ISprite CreateBlueBrickBlockSprite(BlueBrickBlock block)
        {
            return new DrawBlockSprites(brickBlockBlue, block);
        }
        public ISprite CreateBlueCircleBlockSprite(BlueCircleBlock block)
        {
            return new DrawBlockSprites(circleBlockBlue, block);
        }
        public ISprite CreateBlueDoorBottomLeftSprite(BlueDoorBottomLeft block)
        {
            return new DrawBlockSprites(doorBottomLeftBlue, block);
        }
        public ISprite CreateBlueDoorBottomRightSprite(BlueDoorBottomRight block)
        {
            return new DrawBlockSprites(doorBottomRightBlue, block);
        }
        public ISprite CreateBlueDoorMiddleLeftSprite(BlueDoorMiddleLeft block)
        {
            return new DrawBlockSprites(doorMiddleLeftBlue, block);
        }
        public ISprite CreateBlueDoorMiddleRightSprite(BlueDoorMiddleRight block)
        {
            return new DrawBlockSprites(doorMiddleRightBlue, block);
        }
        public ISprite CreateBlueDoorTopLeftSprite(BlueDoorTopLeft block)
        {
            return new DrawBlockSprites(doorTopLeftBlue, block);
        }
        public ISprite CreateBlueDoorTopRightSprite(BlueDoorTopRight block)
        {
            return new DrawBlockSprites(doorTopRightBlue, block);
        }
        public ISprite CreateBlueFenceBlockSprite(BlueFenceBlock block)
        {
            return new DrawBlockSprites(fenceBlockBlue, block);
        }
        public ISprite CreateBlueMetalBlockSprite(BlueMetalBlock block)
        {
            return new DrawBlockSprites(metalBlockBlue, block);
        }
        public ISprite CreateBluePipesBlockSprite(BluePipesBlock block)
        {
            return new DrawBlockSprites(pipesBlockBlue, block);
        }
        public ISprite CreateBlueSquareBlockSprite(BlueSquareBlock block)
        {
            return new DrawBlockSprites(squareBlockBlue, block);
        }
        public ISprite CreateGreenBrickBlockSprite(GreenBrickBlock block)
        {
            return new DrawBlockSprites(brickBlockGreen, block);
        }
        public ISprite CreateGreenFenceBlockSprite(GreenFenceBlock block)
        {
            return new DrawBlockSprites(fenceBlockGreen, block);
        }
        public ISprite CreateGreenPipeBlockSprite(GreenPipeBlock block)
        {
            return new DrawBlockSprites(pipeBlockGreen, block);
        }
        public ISprite CreateGreenSquareBlockSprite(GreenSquareBlock block)
        {
            return new DrawBlockSprites(brickBlockGreen, block);
        }
        public ISprite CreateLavaBlockSprite(LavaBlock block)
        {
            return new DrawBlockSprites(lavaBlock, block);
        }
        public ISprite CreateLavaBlockTopSprite(LavaBlockTop block)
        {
            return new DrawBlockSprites(lavaBlockTop, block);
        }
        public ISprite CreateLightBlueBrickBlockSprite(LightBlueBrickBlock block)
        {
            return new DrawBlockSprites(brickBlockLightBlue, block);
        }
        public ISprite CreateOrangeDoorBlockSprite(OrangeDoorBlock block)
        {
            return new DrawBlockSprites(doorBlockOrange, block);
        }
        public ISprite CreateRedCircleBlockSprite(RedCircleBlock block)
        {
            return new DrawBlockSprites(circleBlockRed, block);
        }
        public ISprite CreateRedCrackedBlockSprite(RedCrackedBlock block)
        {
            return new DrawBlockSprites(crackedBlockRed, block);
        }
        public ISprite CreateRedPipeLeftSprite(RedPipeLeft block)
        {
            return new DrawBlockSprites(pipeLeftRed, block);
        }
        public ISprite CreateRedPipeRightSprite(RedPipeRight block)
        {
            return new DrawBlockSprites(pipeRightRed, block);
        }
        public ISprite CreateRoofSpikeBlockSprite(RoofSpikeBlock block)
        {
            return new DrawBlockSprites(roofSpikeBlock, block);
        }

        public ISprite CreateSwirlBlockBlueSprite(SwirlBlockBlue block)
        {
            return new DrawBlockSprites(swirlBlockBlue, block);
        }

        public ISprite CreateBushBlockBlueSprite(BushBlockBlue block)
        {
            return new DrawBlockSprites(bushBlockBlue, block);
        }

        public ISprite CreateBushBlockSilverSprite(BushBlockSilver block)
        {
            return new DrawBlockSprites(bushBlockSilver, block);
        }

        public ISprite CreateDualHorizontalBlockStoneSprite(DualHorizontalBlockStone block)
        {
            return new DrawBlockSprites(dualHorizontalBlockStone, block);
        }

        public ISprite CreateLeftStartingPlatformBlockSprite(LeftStartingPlatformBlock block)
        {
            return new DrawBlockSprites(leftStartingPlatformBlock, block);
        }

        public ISprite CreateRightStartingPlatformBlockSprite(RightStartingPlatformBlock block)
        {
            return new DrawBlockSprites(rightStartingPlatformBlock, block);
        }

        public ISprite CreateRedDoorBottomLeftBlockSprite(RedDoorBottomLeftBlock block)
        {
            return new DrawBlockSprites(redDoorBottomLeftBlock, block);
        }

        public ISprite CreateRedDoorBottomRightBlockSprite(RedDoorBottomRightBlock block)
        {
            return new DrawBlockSprites(redDoorBottomRightBlock, block);
        }

        public ISprite CreateRedDoorMiddleLeftBlockSprite(RedDoorMiddleLeftBlock block)
        {
            return new DrawBlockSprites(redDoorMiddleLeftBlock, block);
        }

        public ISprite CreateRedDoorMiddleRightBlockSprite(RedDoorMiddleRightBlock block)
        {
            return new DrawBlockSprites(redDoorMiddleRightBlock, block);
        }

        public ISprite CreateRedDoorTopLeftBlockSprite(RedDoorTopLeftBlock block)
        {
            return new DrawBlockSprites(redDoorTopLeftBlock, block);
        }

        public ISprite CreateRedDoorTopRightBlockSprite(RedDoorTopRightBlock block)
        {
            return new DrawBlockSprites(redDoorTopRightBlock, block);
        }

        public ISprite CreateStockBlockStoneSprite(StockBlockStone block)
        {
            return new DrawBlockSprites(stockBlockStone, block);
        }

        public ISprite CreateTubeBlockBlueSprite(TubeBlockBlue block)
        {
            return new DrawBlockSprites(tubeBlockBlue, block);
        }

        public ISprite CreateStoneBlockWithEyesSprite(StoneBlockWithEyes block)
        {
            return new DrawBlockSprites(stoneBlockWithEyes, block);
        }

        public ISprite CreateVerticalTubeStoneBlockSprite(VerticalTubeStoneBlock block)
        {
            return new DrawBlockSprites(verticalTubeStoneBlock, block);
        }


    }
}
