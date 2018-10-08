using UnityEngine;

public class Pistol : Gun {
	protected override void OnFire() {
		FiringPattern.Fire(ProjectilePrefab, SpawnPoint, ProjectileUpdate);
	}
}
