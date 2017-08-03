// Libraries
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Requirement(s)
[RequireComponent(typeof(Text))]

public class Subtitles : MonoBehaviour
{
    [SerializeField]
    private float scrollRate = 1.0f;

    private Text subtitleText;
    private float cursorPosition = 0;
    private string targetMessage  = "";
    private string currentMessage = "";

	void Start ()
	{
        subtitleText = GetComponent<Text>();
	} // End void Start ()

	void Update ()
	{
        cursorPosition += Time.deltaTime * scrollRate;
        cursorPosition = Mathf.Clamp(cursorPosition, 0, targetMessage.Length);

        currentMessage = targetMessage.Substring(0, Mathf.RoundToInt(cursorPosition));
        subtitleText.text = currentMessage;
	} // End void Update ()
    
    // Accessors / Mutators

    public void SetTargetMessage(string newTargetMessage)
    {
        cursorPosition = 0;
        targetMessage = newTargetMessage;
    } // End public void SetTargetMessage()
} // End public class Subtitles
