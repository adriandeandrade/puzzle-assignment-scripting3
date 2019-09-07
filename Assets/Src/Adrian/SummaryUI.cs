using UnityEngine;
using TMPro;

public class SummaryUI : MonoBehaviour
{
	[SerializeField] private GameObject summaryPanel;

	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI timeText;
	[SerializeField] private TextMeshProUGUI deathsText;
	[SerializeField] private TextMeshProUGUI movesText;

	private PlayerStatsManager playerStatsManager;

	private void OnEnable()
	{
		GameManager.OnGameOver += UpdateSummary;
	}

	private void OnDisable()
	{
		GameManager.OnGameOver -= UpdateSummary;
	}

	private void Start()
	{
		playerStatsManager = Toolbox.instance.GetPlayerStatsManager();
	}

	private void UpdateSummary()
	{
		summaryPanel.SetActive(true);

		int score = playerStatsManager.Score;
		float time = playerStatsManager.Timer;
		int deaths = playerStatsManager.Deaths;
		int moves = playerStatsManager.TimesMoved;

		scoreText.SetText($"Score: {score}");
		timeText.SetText($"Time: {time}");
		deathsText.SetText($"# of Deaths: {deaths}");
		movesText.SetText($"# of Moves: {moves}");

	}
}
