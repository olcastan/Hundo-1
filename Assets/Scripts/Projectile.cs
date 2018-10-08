using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public abstract class Projectile : MonoBehaviour {

	public Vector2 Direction;
	public ProjectileUpdate ProjectileUpdate;
	public Rigidbody2D rb2d { get; private set; }

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	protected abstract void OnHit(Damageable damageable);

	protected abstract void OnCollide(Collision2D coll);

	private void FixedUpdate() {
		if (ProjectileUpdate != null) {
			ProjectileUpdate.OnFixedUpdate(this);
		}
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		Damageable damageable = coll.gameObject.GetComponent<Damageable>();
		if (damageable != null) {
			OnHit(damageable);
		}

		OnCollide(coll);
	}
}
