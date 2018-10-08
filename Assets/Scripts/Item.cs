using UnityEngine;

public abstract class Item : MonoBehaviour {

	public string ID { get; protected set; }

	public abstract void Use();
}
