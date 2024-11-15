using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over Panel (Canvas)
    public TextMeshProUGUI scoreText; // Reference to the score text
    public Button tryAgainButton; // Reference to the Try Again button

    private void Start()
    {
        // Initially hide the Game Over screen
        gameOverPanel.SetActive(false);
        tryAgainButton.onClick.AddListener(RestartGame); // Add listener for the try again button
    }

    // Call this method when the game is over
    public void ShowGameOverScreen(int score)
    {
        // Show the Game Over panel
        gameOverPanel.SetActive(true);

        // Set the score text
        scoreText.text = "Score: " + score.ToString();

        // Pause the game when the game over screen appears (optional)
        Time.timeScale = 0; // Pause the game
    }

    // Restart the game
    void RestartGame()
    {
        // Hide the Game Over panel
        gameOverPanel.SetActive(false);

        // Reset time scale to normal (unpause the game)
        Time.timeScale = 1;

        // Reset the player's position to the start point
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.ResetPlayerPosition();
        }

        // Reset the score
        PlayerController scoreController = FindObjectOfType<PlayerController>();
        if (scoreController != null)
        {
            scoreController.ResetScore();
        }
    }
}
