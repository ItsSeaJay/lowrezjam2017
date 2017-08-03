// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Requirement(s)
[RequireComponent(typeof(Image))]

public class Crosshair : MonoBehaviour
{
    enum CrosshairMode
    {
        Default,
        Look,
        Use
    }; // End enum CrosshairMode

    [SerializeField]
    private Transform firstPersonCharacter;
    [SerializeField]
    private Sprite defaultSprite, lookSprite, useSprite;
    [SerializeField]
    private float reach = 4.0f;

    private CrosshairMode currentCrosshairMode;
    private Image crosshairIcon;
    private RectTransform rectTransform;

    void Start ()
	{
        // Get references to the necessary components
        rectTransform = GetComponent<RectTransform>();
        crosshairIcon = GetComponent<Image>();

        // Reset the crosshair mode to the default
        currentCrosshairMode = CrosshairMode.Default;
	} // End void Start ()

	void Update ()
	{
        switch (currentCrosshairMode)
        {
            case CrosshairMode.Default:
                FixSizeDeltaToSpriteRect(defaultSprite);
                break;
            case CrosshairMode.Look:
                FixSizeDeltaToSpriteRect(lookSprite);
                break;
            case CrosshairMode.Use:
                FixSizeDeltaToSpriteRect(useSprite);
                break;
            default:
                Debug.LogError(name + "'s currentCrosshairMode switch statement broke!");
                break;
        } // End switch(currentCrosshairMode)
    } // End void Update ()

    void FixedUpdate()
    {
        // Set up temporary variables for raycasting
        Vector3 forwardLookVector = firstPersonCharacter.TransformDirection(Vector3.forward);
        RaycastHit crosshairHit;
        Debug.DrawRay(firstPersonCharacter.position, forwardLookVector, Color.red);

        // Look for objects ahead of you
        if (Physics.Raycast(firstPersonCharacter.position, forwardLookVector, out crosshairHit, reach) &&
            crosshairHit.transform.tag == "Lookable")
        {
            currentCrosshairMode = CrosshairMode.Look;
        } // End if (Physics.Raycast(firstPersonCharacter.position, forwardLookVector, out crosshairHit, reach) && ...
        else if (Physics.Raycast(firstPersonCharacter.position, forwardLookVector, out crosshairHit, reach) &&
                 crosshairHit.transform.tag == "Usable")
        {
            currentCrosshairMode = CrosshairMode.Use;
        } // End else if (Physics.raycast)
        else
        {
            currentCrosshairMode = CrosshairMode.Default;
        } // End else (Physics.raycast)
    } // End void Fixed

    private void FixSizeDeltaToSpriteRect(Sprite sprite)
    {
        crosshairIcon.sprite = sprite;
        rectTransform.sizeDelta = new Vector2(sprite.rect.width, sprite.rect.height);
    } // End void FixSizeDeltaToSpriteRect(Sprite sprite)
} // End public class Crosshair
