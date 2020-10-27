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

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public class LoadCSV
    {
        public void Load()
        {
            using (TextFieldParser parser = new TextFieldParser(@"~\Levels\StartingLevel.csv"))
            {
                int column = 0;
                int row;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    row = 0;
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        Vector2 location;
                        IBlock block;

                        //TODO: Process field
                        switch (field)
                        {
                            case "BlueBrickBlock":
                                location = new Vector2(row*32, column*32);
                                block = new BlueBrickBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BushBlockBlue":
                                location = new Vector2(row * 32, column * 32);
                                block = new BushBlockBlue(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "TubeBlockBlue":
                                location = new Vector2(row * 32, column * 32);
                                block = new TubeBlockBlue(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueDoorTopLeft":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueDoorTopLeft(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueDoorMiddleLeft":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueDoorMiddleLeft(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueDoorBottomLeft":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueDoorBottomLeft(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "OrangeDoorBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new OrangeDoorBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "StockBlockBlue":
                                location = new Vector2(row * 32, column * 32);
                                block = new StockBlockBlue(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueCircleBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueCircleBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueFenceBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueFenceBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedDoorTopRightBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedDoorTopRightBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedDoorMiddleRightBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedDoorMiddleRightBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedDoorBottomRightBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedDoorBottomRightBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedDoorTopLeftBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedDoorTopLeftBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedDoorMiddleLeftBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedDoorMiddleLeftBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedDoorBottomLeftBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedDoorBottomLeftBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "LavaBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new LavaBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "LavaBlockTop":
                                location = new Vector2(row * 32, column * 32);
                                block = new LavaBlockTop(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "LightBlueBrickBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new LightBlueBrickBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueSquareBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueSquareBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "LeftStartingPlatformBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new LeftStartingPlatformBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RightStartingPlatformBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RightStartingPlatformBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "StockBlockStone":
                                location = new Vector2(row * 32, column * 32);
                                block = new StockBlockStone(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "SwirlBlockBlue":
                                location = new Vector2(row * 32, column * 32);
                                block = new SwirlBlockBlue(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "DualHorizontalBlockStone":
                                location = new Vector2(row * 32, column * 32);
                                block = new DualHorizontalBlockStone(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BushBlockSilver":
                                location = new Vector2(row * 32, column * 32);
                                block = new BushBlockSilver(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BluePipesBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new BluePipesBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueMetalBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueMetalBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;


                            default:
                                break;
                        }
                        row++;
                    }
                    column++;
                }
            }
        }
    }
}
