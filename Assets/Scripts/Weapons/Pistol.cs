public class Pistol : Gun {
	protected override void OnFire() {
		ProjectilePrefab.Direction = SpawnPoint.transform.right;
		Instantiate(ProjectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
	}
}
