using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : PlayerInteractable {

	public override void OnHit(ControllerColliderHit hit, Player player) {
		Destroy(player.gameObject);
	}
}
