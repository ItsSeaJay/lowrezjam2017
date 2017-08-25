﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Helloo");
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
} // End public class LoadSceneOnTriggerEnter
