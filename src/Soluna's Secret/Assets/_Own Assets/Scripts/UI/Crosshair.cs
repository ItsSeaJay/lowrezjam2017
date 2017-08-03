// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Requirement(s)
[RequireComponent(typeof(Image))]

public class Crosshair : MonoBehaviour
{
    public enum CrosshairMode
    {
        Default,
        Look,
        Interact
    }; // End enum CrosshairMode

    [SerializeField]
    private Sprite defaultSprite, lookSprite, useSprite;

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
        // Change sprite based on the cursor mode
        switch (currentCrosshairMode)
        {
            case CrosshairMode.Default:
                FixSizeDeltaToSpriteRect(defaultSprite);
                break;
            case CrosshairMode.Look:
                FixSizeDeltaToSpriteRect(lookSprite);
                break;
            case CrosshairMode.Interact:
                FixSizeDeltaToSpriteRect(useSprite);
                break;
            default:
                Debug.LogError(name + "'s currentCrosshairMode switch statement broke!");
                break;
        } // End switch(currentCrosshairMode)
    } // End void Update ()

    public void FixSizeDeltaToSpriteRect(Sprite sprite)
    {
        crosshairIcon.sprite = sprite;
        rectTransform.sizeDelta = new Vector2(sprite.rect.width, sprite.rect.height);
    } // End void FixSizeDeltaToSpriteRect(Sprite sprite)

    // Accessors / Mutators
    public CrosshairMode CurrentCrosshairMode
    {
        get
        {
            return currentCrosshairMode;
        } // End get
        set
        {
            currentCrosshairMode = value;
        } // End set
    } // End public CrosshairMode CurrentCrosshairMode
} // End public class Crosshair
