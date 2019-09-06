using UnityEngine;

public class Bouncing : PlayerInteractable {

    public float bounceFactor = 2;
	public float bounceDecay = 0.3333f;

	public override void OnHit(ControllerColliderHit hit, Player player) {
		player.transform.forward = Vector3.Reflect(player.transform.forward, hit.normal);
		float velocity = player.GetVelocity();
		velocity *= this.bounceFactor;
		player.SetVelocity(velocity);
		this.bounceFactor -= this.bounceDecay;
	}
}
