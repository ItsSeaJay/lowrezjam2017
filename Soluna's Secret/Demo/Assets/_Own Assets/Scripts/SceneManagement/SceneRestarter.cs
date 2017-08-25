
// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    [Tooltip("Whether the player is allowed to restart the scene using a button.")]
    public bool restartUsingKey = false;
    [Tooltip("The button that will be used to restart the scene.")]
    public string buttonToPush = "F5";

    void Update ()
    {
        if (Input.GetKeyDown(buttonToPush) &&
            restartUsingKey)
        {
            RestartScene();
        } // End if Input.GetButtonDown(buttonToPush)
    } // End void Update ()

    public void RestartScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } // End void RestartScene ()
} // End public class SceneRestarter : MonoBehaviour
