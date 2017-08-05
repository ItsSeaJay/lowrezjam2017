// Libraries
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Requirement(s)
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Text))]

public class Subtitles : MonoBehaviour
{
    [SerializeField]
    private float scrollRate = 1.0f;
    [SerializeField]
    private Crosshair crosshair;

    private Animator animator;
    private Text subtitleText;
    private float cursorPosition = 0;
    private string targetMessage  = "";
    private string currentMessage = "";

	void Start ()
	{
        // Get references to required components
        animator     = GetComponent<Animator>();
        subtitleText = GetComponent<Text>();
	} // End void Start ()

	void Update ()
	{
        // Advance the cursor position over time
        cursorPosition += Time.deltaTime * scrollRate;
        cursorPosition = Mathf.Clamp(cursorPosition, 0, targetMessage.Length);

        // Display the correct text
        currentMessage = targetMessage.Substring(0, Mathf.RoundToInt(cursorPosition));
        subtitleText.text = currentMessage;

        // Animate based on the current crosshair mode
        switch (crosshair.CurrentCrosshairMode)
        {
            case Crosshair.CrosshairMode.Default:
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fading Out") &&
                    !animator.GetCurrentAnimatorStateInfo(0).IsName("Hidden"))
                {
                    animator.Play("Fading Out");
                } // End if !animator.GetCurrentAnimatorStateInfo(0).IsName("Subtitles Fade") && ...
                break;
            case Crosshair.CrosshairMode.Look:
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fading In") &&
                    !animator.GetCurrentAnimatorStateInfo(0).IsName("Shown"))
                {
                    animator.Play("Fading In");
                }
                break;
        }
    } // End void Update ()
    
    // Accessors / Mutators
    public void SetTargetMessage(string newTargetMessage)
    {
        // Reset the cursor position
        cursorPosition = 0;
        targetMessage = newTargetMessage;
    } // End public void SetTargetMessage()
} // End public class Subtitles
