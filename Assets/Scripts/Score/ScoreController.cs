using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int currentScore = 0;
    private int bestScore = 0;

    [SerializeField] private UIController uiController;

    private void Start()
    {
        LoadBestScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            AudioController.Instance.PlaySFX("Score");
            currentScore += 10;
            Destroy(collision.gameObject);
            UpdateScoreText(currentScore);
            UpdateBestScore(currentScore);
        }
    }

    private void UpdateScoreText(int score)
    {
        uiController.UpdateScoreText(score);
    }

    private void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt(GlobalConstant.BEST_SCORE, 0);
        uiController.LoadBestScore(bestScore);
    }

    private void UpdateBestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            uiController.UpdateBestScore(bestScore);
            PlayerPrefs.SetInt(GlobalConstant.BEST_SCORE, bestScore);
        }
    }
}
