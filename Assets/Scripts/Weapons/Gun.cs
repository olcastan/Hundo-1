using System.Collections;
using UnityEngine;

public abstract class Gun : Item {

	public float FireRate;
	public Transform SpawnPoint;
	public Projectile ProjectilePrefab; // Has events for on collide
	public ProjectileUpdate ProjectileUpdate;

	private bool isReady;

	public Gun() {
		isReady = true;
	}
	
	private void Awake() {
		ProjectilePrefab.ProjectileUpdate = ProjectileUpdate;
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
