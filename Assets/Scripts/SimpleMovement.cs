using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class SimpleMovement : Movement {
	
	public float Speed;

	private Rigidbody2D rb2d;

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	public override void Move(Vector2 direction) {
		rb2d.velocity = direction * Speed;
	}
}
