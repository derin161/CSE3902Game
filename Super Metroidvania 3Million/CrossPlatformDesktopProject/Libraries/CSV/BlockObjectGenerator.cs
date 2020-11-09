using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.VisualBasic.CompilerServices;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public class BlockObjectGenerator //Unused as of now ***
    {
        public void LoadLevel(string objName, string objectType)
        {
            Vector2 location = new Vector2(/*row * */32, /*column **/ 32);
            IBlock block;

            switch (objName)
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

                case "StockBlueBlock":
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

                case "RedDoorTopRightBlock":
                    block = new RedDoorTopRightBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorMiddleRightBlock":
                    block = new RedDoorMiddleRightBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorBottomRightBlock":
                    block = new RedDoorBottomRightBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorTopLeftBlock":
                    block = new RedDoorTopLeftBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorMiddleLeftBlock":
                    block = new RedDoorMiddleLeftBlock(location);
                    GameObjectContainer.Instance.Add(block);
                    break;

                case "RedDoorBottomLeftBlock":
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
