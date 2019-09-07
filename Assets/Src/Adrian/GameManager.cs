using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private PlayerStatsManager playerStatsManager;

	// Events
	public delegate void OnGameOverAction();
	public static event OnGameOverAction OnGameOver;

	public delegate void OnStartGameAction();
	public static event OnStartGameAction OnStartGame;

	private void Awake()
	{
	}

	private void Start()
	{
		playerStatsManager = Toolbox.instance.GetPlayerStatsManager();
	}


	private void OnEnable()
	{
		Player.OnDie += OnPlayerDied;
		Player.OnPlayerWon += NextLevel;
	}

	private void OnDisable()
	{
		Player.OnDie -= OnPlayerDied;
		Player.OnPlayerWon -= NextLevel;
	}

	private void OnPlayerDied()
	{
		if (playerStatsManager.Lives - 1 > 0)
		{
			// We stil have lives, restart the level.
			int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(currentSceneIndex);
		}
		else
		{
			GameOver();
		}
	}

	private void NextLevel()
	{
		int sceneCount = SceneManager.sceneCountInBuildSettings;
		int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
		//Debug.Log(sceneCount);

		if (nextScene + 1 > sceneCount)
		{
			GameOver();
			return;
		}

		SceneManager.LoadScene(nextScene);
	}

	private void GameOver()
	{
		if (OnGameOver != null)
		{
			OnGameOver();
		}
	}

	public void StartGame()
	{
		NextLevel();
		if (OnStartGame != null)
		{
			OnStartGame();
		}
	}
}
