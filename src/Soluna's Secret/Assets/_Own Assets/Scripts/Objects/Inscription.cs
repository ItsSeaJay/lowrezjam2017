// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inscription : MonoBehaviour
{
    [SerializeField]
    private string[] displayableMessages;
    private string currentDisplayedMessage = "";
    private int currentDisplayedIndex = 0;

    void Update ()
    {
        currentDisplayedMessage = displayableMessages[currentDisplayedIndex];
    } // End void Update ()

    public void ResetMessage ()
    {
        currentDisplayedIndex = 0;
    }

    public void AdvanceMessage ()
    {
        if (currentDisplayedIndex + 1 >= displayableMessages.Length)
        {
            ResetMessage();
        }
        else
        {
            currentDisplayedIndex += 1;
        }
    }

    // Accessors / Mutators
    public string CurrentDisplayedMessage
    {
        get
        {
            return currentDisplayedMessage;
        }
    }

    public int CurrentDisplayedIndex
    {
        get
        {
            return currentDisplayedIndex;
        }
    }
} // End public class Inscription
