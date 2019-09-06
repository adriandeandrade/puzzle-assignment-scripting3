using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : PlayerInteractable {

	public override void OnHit(ControllerColliderHit hit, Player player) {
		print("This should be a trigger!");
	}

	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if (player) {
			player.HasWon();
		}
	}
}
