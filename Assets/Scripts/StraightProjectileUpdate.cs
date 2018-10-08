using UnityEngine;

[CreateAssetMenu(fileName = "StraightProjectileUpdate", menuName = "ProjectileUpdate/Straight")]
public class StraightProjectileUpdate : ProjectileUpdate {

	public float Speed;

	public override void OnFixedUpdate(Projectile projectile) {
		projectile.rb2d.velocity = projectile.transform.right * Speed;
	}
}
