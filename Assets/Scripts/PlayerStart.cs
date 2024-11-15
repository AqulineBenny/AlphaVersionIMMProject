using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public Transform startPoint; // Reference to the Start Point

    void Start()
    {
        // Set the player's position to the start point when the game starts
        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }
    }
}
