// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inscription : MonoBehaviour
{
    [SerializeField]
    private string[] displayableMessages;

    private string currentlyDisplayedMessage = "";
    private int currentlyDisplayedIndex = 0;

    void Update ()
    {
        currentlyDisplayedMessage = displayableMessages[currentlyDisplayedIndex];

        // Debug.Log("Current Display Index: " + currentlyDisplayedIndex);
    } // End void Update ()

    public void ResetMessage ()
    {
        currentlyDisplayedIndex = 0;
    }

    public void AdvanceMessage ()
    {
        if (currentlyDisplayedIndex + 1 >= displayableMessages.Length)
        {
            ResetMessage();
        }
        else
        {
            currentlyDisplayedIndex += 1;
        }
    }

    // Accessors / Mutators
    public string CurrentlyDisplayedMessage
    {
        get
        {
            return currentlyDisplayedMessage;
        }
    }

    public int CurrentlyDisplayedIndex
    {
        get
        {
            return currentlyDisplayedIndex;
        }
    }
} // End public class Inscription
