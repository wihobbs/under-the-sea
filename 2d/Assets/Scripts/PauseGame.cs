/*
Written by Myopic Games
10/07/22
PauseGame.cs

This script contains the necessary functions for pausing the game.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            // Show the menu options
            // Are you sure you want to quit?
            Application.Quit();
            Debug.Log("Quitting game...");
        }
    }
}
