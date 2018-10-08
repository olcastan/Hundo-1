using System.Collections;
using UnityEngine;

public abstract class Gun : Item {

	public float FireRate;
	public Transform SpawnPoint;
	public Projectile ProjectilePrefab; // Has events for on collide
	public FiringPattern FiringPattern;
	public ProjectileUpdate ProjectileUpdate;

	private bool isReady;

	public Gun() {
		isReady = true;
	}

	protected abstract void OnFire();

	public override void Use() {
		if (isReady) {
			StartCoroutine(fireAndWait());
		}
	}

	private IEnumerator fireAndWait() {
		isReady = false;
		OnFire();
		yield return new WaitForSeconds(FireRate);
		isReady = true;
	}
}
