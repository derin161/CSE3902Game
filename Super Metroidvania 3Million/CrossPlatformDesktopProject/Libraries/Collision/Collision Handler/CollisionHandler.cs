using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Command;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    class CollisionHandler
    {
        public CollisionHandler()
        {

        }

        public void PlayerEnemyCollision(IPlayer player, IEnemy enemy)
        {
            new EnemyDamagePlayerCommand(player, enemy).Execute();
        }

        public void PlayerBlockCollision(IPlayer player, IBlock block, Rectangle collisionZone)
        {
            Samus sam = ((Samus)player);
            
            //Determine the direction that the player came from and push the player back out of the block
            //Use collisionZone to determine LEFT/RIGHT or TOP/BOTTOM collision.
            if (collisionZone.Height > collisionZone.Width)
            { //LEFT/RIGHT collision
                sam.Physics.HortizontalBreak();
                if (player.SpaceRectangle().X < block.SpaceRectangle().X)
                { //LEFT Collision
                    //sam.position = new Vector2(sam.position.X - collisionZone.Width, sam.position.Y);
                    sam.space  = new Rectangle(sam.space.X - collisionZone.Width, sam.space.Y, sam.space.Width, sam.space.Height);
                    System.Console.WriteLine("Player block left collision");
                }
                else
                { //RIGHT Collision 
                    //sam.position = new Vector2(sam.position.X + collisionZone.Width, sam.position.Y);
                    sam.space = new Rectangle(sam.space.X + collisionZone.Width , sam.space.Y, sam.space.Width, sam.space.Height);
                    System.Console.WriteLine("Player block right collision");
                }
            }
            else { //TOP/BOTTOM collision
                sam.Physics.VerticalBreak();
                if (player.SpaceRectangle().Y < block.SpaceRectangle().Y)
                { //TOP Collision
                    //sam.position = new Vector2(sam.position.X, sam.position.Y - collisionZone.Height);
                    sam.Idle();
                    sam.space = new Rectangle(sam.space.X, sam.space.Y - collisionZone.Height, sam.space.Width, sam.space.Height);
                }
                else { //BOTTOM Collision 
                    //sam.position = new Vector2(sam.position.X, sam.position.Y + collisionZone.Height);
                    sam.space = new Rectangle(sam.space.X, sam.space.Y + collisionZone.Height, sam.space.Width, sam.space.Height);
                }
            }
        }

        public void PlayerProjectileCollision(IPlayer player, IProjectile projectile)
        {
            if (projectile is KraidHorn || projectile is KraidMissile) { //Only kraid projectiles deal damage to the player.
                new ProjectileDamagePlayerCommand(player, projectile).Execute();
            }
        }

        public void EnemyBlockCollision(IEnemy enemy, IBlock block, Rectangle collisionZone)
        {
            //Same as player block collisions
            //Player should become temporarily invulnerable and blink. Logic likely in Player class accessed through TakeDamage command.
            //Use collisionZone to determine LEFT/RIGHT or TOP/BOTTOM collision.
            if (collisionZone.Height > collisionZone.Width)
            { //LEFT/RIGHT collision
                if (enemy.SpaceRectangle().X < block.SpaceRectangle().X)
                { //LEFT Collision
                    enemy.MoveRight();
                }
                else
                { //RIGHT Collision 
                    enemy.MoveRight();
                }
            }
            else
            { //TOP/BOTTOM collision 
                if (enemy.SpaceRectangle().Y < block.SpaceRectangle().Y)
                { //TOP Collision
                    enemy.MoveDown();
                }
                else
                { //BOTTOM Collision 
                    enemy.MoveUp();
                }
            }
        }

        public void ProjectileBlockCollision(IProjectile projectile, IBlock block)
        {
            //Kill the projectile
            projectile.Kill();
        }

        public void ProjectileEnemyCollision(IProjectile projectile, IEnemy enemy)
        {
            //Cast so we can then determine is it's an ice beam or not, casting will succeed if the first statement is true.
            if (projectile is PowerBeam && ((PowerBeam)projectile).IsIceBeam) { 
                    new EnemyFreezeCommand(enemy).Execute();
            }
            new ProjectileDamageEnemyCommand(projectile, enemy).Execute();
            projectile.Kill();
        }

        public void PlayerItemCollision(IPlayer player, IItem item)
        {
            new PlayerGiveItemCommand(item, player).Execute();
            item.Kill();
        }
    }
}
