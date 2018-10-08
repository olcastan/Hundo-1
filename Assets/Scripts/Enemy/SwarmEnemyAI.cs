using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Movement))]
[RequireComponent (typeof(Collider2D))]
public class SwarmEnemyAI : MonoBehaviour {

	public float DamageValue;
	public float AttackRate;
	
	private GameObject target;
	private Movement movement;
	private Vector2 direction;
	public bool isTargetInRange;

	private void Awake() {
		target = GameObject.Find("Player");
		movement = GetComponent<Movement>();
	}

	private void FixedUpdate() {
		direction = target.transform.position - transform.position;
		direction.x = Mathf.Clamp(direction.x, -1.0f, 1.0f);
		direction.y = Mathf.Clamp(direction.y, -1.0f, 1.0f);
		movement.Move(direction);
	}

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject == target) {
			isTargetInRange = true;
			StartCoroutine(attackTarget());
		}
	}

	private void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject == target) {
			isTargetInRange = false;
		}
	}

	private IEnumerator attackTarget() {
		Debug.Log("asde");
		if (!isTargetInRange) {
			yield break;
		} else {
			Damageable damageable = target.GetComponent<Damageable>();
			if (damageable != null) {
				damageable.Damage(DamageValue);
			}
			yield return new WaitForSeconds(AttackRate);
			attackTarget();
		}
	}
}
