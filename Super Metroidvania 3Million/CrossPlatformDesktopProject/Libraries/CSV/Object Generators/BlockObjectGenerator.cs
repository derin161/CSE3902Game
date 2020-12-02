using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using System;

namespace SuperMetroidvania5Million.Libraries.CSV.Object_Generators
{
    public class BlockObjectGenerator
    {
        private static BlockObjectGenerator instance = new BlockObjectGenerator();
        public static BlockObjectGenerator Instance
        {
            get
            {
                return instance;
            }
        }

        public void createBlock(Vector2 location, String blockType)
        {
            IBlock block;
            switch (blockType)
            {
                case "BlueBrickBlock":
                    block = new BlueBrickBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BushBlockBlue":
                    block = new BushBlockBlue(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "TubeBlockBlue":
                    block = new TubeBlockBlue(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "VerticalTubeStoneBlock":
                    block = new VerticalTubeStoneBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "StoneBlockWithEyes":
                    block = new StoneBlockWithEyes(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueDoorTopRight":
                    block = new BlueDoorTopRight(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueDoorMiddleRight":
                    block = new BlueDoorMiddleRight(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueDoorBottomRight":
                    block = new BlueDoorBottomRight(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedPipeLeft":
                    block = new RedPipeLeft(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedPipeRight":
                    block = new RedPipeRight(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedCircleBlock":
                    block = new RedCircleBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedCrackedBlock":
                    block = new RedCrackedBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RoofSpikeBlock":
                    block = new RoofSpikeBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "GreenBrickBlock":
                    block = new GreenBrickBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "GreenFenceBlock":
                    block = new GreenFenceBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "GreenPipeBlock":
                    block = new GreenPipeBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "GreenSquareBlock":
                    block = new GreenSquareBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueDoorTopLeft":
                    block = new BlueDoorTopLeft(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueDoorMiddleLeft":
                    block = new BlueDoorMiddleLeft(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueDoorBottomLeft":
                    block = new BlueDoorBottomLeft(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "OrangeDoorBlock":
                    block = new OrangeDoorBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "StockBlockBlue":
                    block = new StockBlockBlue(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueCircleBlock":
                    block = new BlueCircleBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueFenceBlock":
                    block = new BlueFenceBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorTopRight":
                    block = new RedDoorTopRightBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorMiddleRight":
                    block = new RedDoorMiddleRightBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorBottomRight":
                    block = new RedDoorBottomRightBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorTopLeft":
                    block = new RedDoorTopLeftBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorMiddleLeft":
                    block = new RedDoorMiddleLeftBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorBottomLeft":
                    block = new RedDoorBottomLeftBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "LavaBlock":
                    block = new LavaBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "LavaBlockTop":
                    block = new LavaBlockTop(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "LightBlueBrickBlock":
                    block = new LightBlueBrickBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueSquareBlock":
                    block = new BlueSquareBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "LeftStartingPlatformBlock":
                    block = new LeftStartingPlatformBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RightStartingPlatformBlock":
                    block = new RightStartingPlatformBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "StockBlockStone":
                    block = new StockBlockStone(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "SwirlBlockBlue":
                    block = new SwirlBlockBlue(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "DualHorizontalBlockStone":
                    block = new DualHorizontalBlockStone(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BushBlockSilver":
                    block = new BushBlockSilver(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BluePipesBlock":
                    block = new BluePipesBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "BlueMetalBlock":
                    block = new BlueMetalBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;
            }

        }
    }
}
