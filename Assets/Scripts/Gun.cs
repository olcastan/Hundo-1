using System.Collections;
using UnityEngine;

public class Gun : Item {

	public float FireRate;
	public Transform SpawnPoint;
	public Projectile ProjectilePrefab; // Has events for on collide
	public FiringPattern FiringPattern;
	public ProjectileUpdate ProjectileUpdate;

	private bool isReady;

	public Gun() {
		isReady = true;
	}

	public override void Use() {
		if (isReady) {
			StartCoroutine(fire());
		}
	}

	private IEnumerator fire() {
		isReady = false;
		FiringPattern.Fire(ProjectilePrefab, SpawnPoint, ProjectileUpdate);
		yield return new WaitForSeconds(FireRate);
		isReady = true;
	}
}
