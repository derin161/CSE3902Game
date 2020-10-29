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
            
            //Left collision happens when samus is moving right and abs(player.y-block.y) < player.height
            if (sam.Physics.velocity.X > 0 && System.Math.Abs(sam.space.Y - block.SpaceRectangle().Y) < sam.space.Height)
            {
                sam.space = new Rectangle((int)sam.x - collisionZone.Width, (int)sam.y, sam.space.Width, sam.space.Height);
                sam.Physics.HortizontalBreak();
                System.Console.WriteLine("left collision");
            }
            //Right collision happens when samus is moving left and player.y-block.y < player.height
            if (sam.Physics.velocity.X < 0 && System.Math.Abs(sam.space.Y - block.SpaceRectangle().Y) < sam.space.Height)
            {
                sam.space = new Rectangle((int)sam.x + collisionZone.Width, (int)sam.y, sam.space.Width, sam.space.Height);
                sam.Physics.HortizontalBreak();
                System.Console.WriteLine("right collision");
            }
            //Top collision happens when samus is moving down and abs(player.x - block.x) < player.width
            if (sam.Physics.velocity.Y > 0 && System.Math.Abs(sam.space.X - block.SpaceRectangle().X) < sam.space.Width)
            {
                sam.space = new Rectangle((int)sam.x, (int)sam.y - collisionZone.Height, sam.space.Width, sam.space.Height);
                sam.Physics.VerticalBreak();
                System.Console.WriteLine("top collision");
            }
            //Bottom collision happens when samus is moving up and abs(player.x - block.x) < player.width
            if (sam.Physics.velocity.Y < 0 && System.Math.Abs(sam.space.X - block.SpaceRectangle().X) < sam.space.Width)
            {
                sam.space = new Rectangle((int)sam.x, (int)sam.y + collisionZone.Height, sam.space.Width, sam.space.Height);
                sam.Physics.VerticalBreak();
                System.Console.WriteLine("bottom collision");
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
