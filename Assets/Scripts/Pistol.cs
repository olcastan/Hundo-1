using UnityEngine;

public class Pistol : Gun {

	protected override void OnFire() {
		// Just instantiate new projectile update
		// Let's try to get rid of this firing pattern
//		FiringPattern.Fire(ProjectilePrefab, SpawnPoint, ProjectileUpdate);
		ProjectilePrefab.Direction = SpawnPoint.transform.right;
		Instantiate(ProjectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
		Debug.Log("Fire!");
	}
}
