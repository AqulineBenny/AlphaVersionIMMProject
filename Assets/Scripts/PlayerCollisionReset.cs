using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionReset : MonoBehaviour
{
    public Transform startPoint;  // Reference to the Start Point
    public float fallThreshold = -5.0f;  // The Y-position threshold for falling off
    public PlayerController playerController; // Reference to the PlayerController

    void Update()
    {
        // Check if the player has fallen off the road
        if (transform.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    // Detect collision with obstacles (non-trigger colliders)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    // Detect trigger collisions with obstacles (if any)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    // Trigger the Game Over function
    void GameOver()
    {
        if (playerController != null)
        {
            playerController.GameOver();
        }
    }
}
