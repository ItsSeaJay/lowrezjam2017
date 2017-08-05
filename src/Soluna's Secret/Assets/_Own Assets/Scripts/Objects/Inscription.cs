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

    void Start ()
    {
        // Ensure the tag is correct when the game starts
        // Just in case I forget
        transform.tag = "Lookable";
    } // End void Start

    void Update ()
    {
        currentlyDisplayedMessage = displayableMessages[currentlyDisplayedIndex];

        // Debug.Log("Current Display Index: " + currentlyDisplayedIndex);
    } // End void Update ()

    public void ResetMessage ()
    {
        currentlyDisplayedIndex = 0;
    } // End public void ResetMessage();

    public void AdvanceMessage ()
    {
        if (currentlyDisplayedIndex + 1 >= displayableMessages.Length)
        {
            ResetMessage();
        } // End if (currentlyDisplayedIndex + 1 >= displayableMessages.Length)
        else
        {
            currentlyDisplayedIndex += 1;
        } // End else (currentlyDisplayedIndex + 1 >= displayableMessages.Length)
    } // End AdvanceMessage ()

    // Accessors / Mutators
    public string CurrentlyDisplayedMessage
    {
        get
        {
            return currentlyDisplayedMessage;
        } // End get
    } // End public string CurrentlyDisplayedMessage

    public int CurrentlyDisplayedIndex
    {
        get
        {
            return currentlyDisplayedIndex;
        } // End get
    } // End public int CurrentlyDisplayedIndex
} // End public class Inscription
