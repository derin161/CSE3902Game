namespace SuperMetroidvania5Million.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    public interface IEnemy : IGameObject
    {
        public void MoveLeft();
        public void MoveRight();
        public void MoveUp();
        public void MoveDown();
        public void StopMoving();
        public void ChangeDirection();
        public void Freeze();
        public void TakeDamage(int damage);
        public int GetDamage();
    }
}
