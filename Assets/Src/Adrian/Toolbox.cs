using UnityEngine;

public class Toolbox : MonoBehaviour
{
	#region Singleton
	public static Toolbox instance;

	private void InitSingleton()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	#endregion

	[SerializeField] private GameManager gameManager;
	[SerializeField] private PlayerStatsManager playerStatsManager;

	private void Awake()
	{
		InitSingleton();

		AddDefaultManagers();
	}

	private void AddDefaultManagers()
	{
		if (gameManager == null)
		{
			gameManager = gameObject.AddComponent<GameManager>();
		}

		if (playerStatsManager == null)
		{
			playerStatsManager = gameObject.AddComponent<PlayerStatsManager>();
		}
	}

	public PlayerStatsManager GetPlayerStatsManager()
	{
		return playerStatsManager;
	}

	public GameManager GetGameManager()
	{
		return gameManager;
	}

}
