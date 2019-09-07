using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
	private int timesMoved = 0;
	private int score = 0;
	private int lives = 3;
	private int deaths;
	private float time = 0;
	private bool doTimer = true;

	public int Lives { get => lives; }
	public int Score { get => score; }
	public float Timer { get => time; }
	public int TimesMoved { get => timesMoved; }
	public int Deaths { get => deaths; }

	private void Update()
	{
		if (doTimer)
		{
			time += 1 * Time.deltaTime;
			score += 10;
		}
	}

	private void OnEnable()
	{
		Player.OnMove += AddMove;
		Player.OnDie += RemoveLife;
		GameManager.OnGameOver += StopStats;
		GameManager.OnStartGame += UpdateStats;
	}

	private void OnDisable()
	{
		Player.OnMove -= AddMove;
		Player.OnDie -= RemoveLife;
		GameManager.OnGameOver -= StopStats;
		GameManager.OnStartGame -= UpdateStats;
	}

	private void AddMove()
	{
		timesMoved += 1;
	}

	private void RemoveLife()
	{
		lives -= 1;
		deaths += 1;
	}

	private void StopStats()
	{
		doTimer = false;
	}

	private void UpdateStats()
	{
		doTimer = true;
	}
}
