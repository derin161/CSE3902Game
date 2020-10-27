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
                                
                            case "VerticalTubeStoneBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new VerticalTubeStoneBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "StoneBlockWithEyes":
                                location = new Vector2(row * 32, column * 32);
                                block = new StoneBlockWithEyes(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueDoorTopRight":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueDoorTopRight(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueDoorMiddleRight":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueDoorMiddleRight(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "BlueDoorBottomRight":
                                location = new Vector2(row * 32, column * 32);
                                block = new BlueDoorBottomRight(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedPipeLeft":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedPipeLeft(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedPipeRight":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedPipeRight(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedCircleBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedCircleBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RedCrackedBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RedCrackedBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "RoofSpikeBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new RoofSpikeBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "GreenBrickBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new GreenBrickBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "GreenFenceBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new GreenFenceBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "GreenPipeBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new GreenPipeBlock(location);
                                GameObjectContainer.Instance.Add(block);
                                break;

                            case "GreenSquareBlock":
                                location = new Vector2(row * 32, column * 32);
                                block = new GreenSquareBlock(location);
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
