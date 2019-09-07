using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 1f;
	public float initialVelocity = 2f;
	public float decay = 0.1f;

	private int score = 0;
	private float velocity = 0;
	private int moveCount = 0;
	private CharacterController cc;

	enum State
	{
		Idle,
		Moving,
		Won
	}

	private State currentState = State.Idle;

	// Events
	public delegate void OnMoveAction();
	public static event OnMoveAction OnMove; // Event gets raised everytime the player moves.

	public delegate void OnDieAction();
	public static event OnDieAction OnDie;

	public delegate void OnPlayerWonAction();
	public static event OnPlayerWonAction OnPlayerWon;

	// Use this for initialization
	void Start()
	{
		cc = this.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 direction = Physics.gravity;
		direction += this.transform.forward * velocity;

		cc.Move(direction * Time.deltaTime);

		switch (this.currentState)
		{
			case State.Idle:
				this.Idle();
				break;
			case State.Moving:
				this.Moving();
				break;
			case State.Won:
				this.Won();
				break;
		}
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
			case State.Idle:
				currentState = newState;
				InitIdleState();
				break;
			case State.Moving:
				currentState = newState;
				InitMovingState();
				break;
			case State.Won:
				currentState = newState;
				InitWonState();
				break;
		}
	}

	private void Die()
	{
		if (OnDie != null)
		{
			OnDie();
		}
	}

	private void InitIdleState()
	{

	}

	private void InitMovingState()
	{
		if (OnMove != null)
		{
			OnMove();
		}
	}

	private void InitWonState()
	{

	}

	void Idle()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.rotation *= Quaternion.Euler(0, -this.speed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.rotation *= Quaternion.Euler(0, this.speed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			// let's gooo
			SetState(State.Moving);
			this.velocity = this.initialVelocity;
			this.moveCount++;
		}
	}

	void Moving()
	{
		if (velocity > 0f)
		{
			this.velocity -= this.decay;
			this.velocity = Mathf.Clamp(this.velocity, 0, float.MaxValue);
		}
		else
		{
			this.velocity = 0;
			SetState(State.Idle);
		}
	}

	void Won()
	{
		//print("I Win");
		this.velocity = 0;

		if (OnPlayerWon != null)
		{
			OnPlayerWon();
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (this.currentState != State.Won)
		{
			//hit.gameObject.GetComponent<PlayerInteractable>()?.OnHit(hit, this);
			PlayerInteractable pi = hit.gameObject.GetComponent<PlayerInteractable>();
			if (pi)
			{
				if (pi.GetComponent<Killing>())
				{
					Die();
					return;
				}

				pi.OnHit(hit, this);
			}
		}
	}

	public float GetVelocity()
	{
		return this.velocity;
	}

	public void SetVelocity(float vel)
	{
		this.velocity = vel;
	}

	public void HasWon()
	{
		SetState(State.Won);
	}


	public int AccumulateScore(int scoreAdd)
	{
		this.score += scoreAdd;
		return this.score;
	}
}
