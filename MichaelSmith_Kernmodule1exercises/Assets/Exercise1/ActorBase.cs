public abstract class ActorBase : IDamageable
{
	public int Health { get; set; }
	public abstract void Move();
	public abstract void Attack();
	public abstract void TakeDamage();
}