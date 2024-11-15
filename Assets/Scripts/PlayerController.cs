using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables to control player movement and score
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    public TextMeshProUGUI countText;  // Reference to the UI text that displays the score
    private int count = 0;             // The score (coins collected)

    public GameOverScreen gameOverScreen; // Reference to the GameOverScreen script

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        // Player input for movement
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward and turn it
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

    // Detect when the player collides with a coin
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Increase score and update UI
            Destroy(other.gameObject);
            count++;
            SetCountText();
        }
    }

    // Set the count text on the UI
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    // Reset the player's position to the starting point
    public void ResetPlayerPosition()
    {
        // Assuming the start point is a GameObject in the scene
        Transform startPoint = GameObject.Find("StartPoint").transform;
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }

    // Call this method when the game is over (hit an obstacle or fall off)
    public void GameOver()
    {
        // Show the game over screen
        gameOverScreen.ShowGameOverScreen(count);
    }

    // Reset the score for a new game
    public void ResetScore()
    {
        count = 0;
        SetCountText();
    }
}

