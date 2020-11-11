using System.Linq;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public class LoadCsv
    {
        private static LoadCsv instance = new LoadCsv();

        public static LoadCsv Instance
        {
            get
            {
                return instance;
            }
        }

        public void Load(string levelName, Vector2 playerSpawn)
        {
            GameObjectContainer.Instance.Clear();

            GameObjectContainer.Instance.Player.UpdateLocation(playerSpawn);

            string levelPath = @"..\..\..\..\Libraries\Levels\" + levelName;

            string[] lines = File.ReadAllLines(levelPath);
            int rows = lines.Count();
            int columns = lines[0].Split(',').Length;

            //Game1.ChangeResolution(rows, columns);

            using (TextFieldParser parser = new TextFieldParser(levelPath))
            {
                int column = 0;
                int row;
                Vector2 location;
                IBlock block;

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    row = 0;
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        location = new Vector2(row * 32, column * 32);
                        //TODO: Process field
                        switch (field)
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


                            //Enemies
                            case "SideHopper":
                                GameObjectContainer.Instance.Add(new SideHopper(location));
                                break;
                            case "ReverseSideHopper":
                                GameObjectContainer.Instance.Add(new ReverseSideHopper(location));
                                break;
                            case "Skree":
                                GameObjectContainer.Instance.Add(new Skree(location));
                                break;
                            case "Geega":
                                GameObjectContainer.Instance.Add(new Geega(location));
                                break;
                            case "Kraid":
                                GameObjectContainer.Instance.Add(new Kraid(location));
                                break;
                            case "Zeela":
                                GameObjectContainer.Instance.Add(new Zeela(location));
                                break;

                            //Items
                            case "BombItem":
                                GameObjectContainer.Instance.Add(new BombItem(location));
                                break;
                            case "EnergyDropItem":
                                GameObjectContainer.Instance.Add(new EnergyDropItem(location));
                                break;
                            case "EnergyTankItem":
                                GameObjectContainer.Instance.Add(new EnergyTankItem(location));
                                break;
                            case "HighJumpItem":
                                GameObjectContainer.Instance.Add(new HighJumpItem(location));
                                break;
                            case "IceBeamItem":
                                GameObjectContainer.Instance.Add(new IceBeamItem(location));
                                break;
                            case "LongBeamItem":
                                GameObjectContainer.Instance.Add(new LongBeamItem(location));
                                break;
                            case "MissleRocketItem":
                                GameObjectContainer.Instance.Add(new MissileRocketItem(location));
                                break;

                            case "MorphBallItem":
                                GameObjectContainer.Instance.Add(new MorphBallItem(location));
                                break;
                            case "RocketDropItem":
                                GameObjectContainer.Instance.Add(new RocketDropItem(location));
                                break;
                            case "ScrewAttackItem":
                                GameObjectContainer.Instance.Add(new ScrewAttackItem(location));
                                break;
                            case "VariaItem":
                                GameObjectContainer.Instance.Add(new VariaItem(location));
                                break;
                            case "WaveBeamItem":
                                GameObjectContainer.Instance.Add(new WaveBeamItem(location));
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

        /*public static IGameObject CreateObject(string objType, Vector2 pos)
        {

        }*/

    }
}
