using UnityEngine;

public class Coin : MonoBehaviour {
	int value = 1;

	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if (player) {
			player.AccumulateScore(this.value);
			Destroy(this.gameObject);
		}
	}
}
