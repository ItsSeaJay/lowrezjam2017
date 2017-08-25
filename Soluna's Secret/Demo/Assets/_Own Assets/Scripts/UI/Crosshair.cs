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
    [SerializeField]
    private Player player;
    [SerializeField]
    private Transform firstPersonCharacter;

    private CrosshairMode currentCrosshairMode;
    private Image crosshairIcon;
    private RaycastHit forwardLookHit;
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

    void FixedUpdate ()
    {
        // Set up temporary variables for raycasting
        Vector3 forwardLookVector = firstPersonCharacter.TransformDirection(Vector3.forward);
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Default"); // Collide with default

        // look for objects ahead of the player character
        if (Physics.Raycast(firstPersonCharacter.position, 
                            forwardLookVector, 
                            out forwardLookHit,
                            player.Reach,
                            layerMask))
        {
            switch(forwardLookHit.transform.tag)
            {
                case "Lookable":
                    // We're looking at an inscription
                    currentCrosshairMode = CrosshairMode.Look;
                    break;
                case "Interactable":
                    // We're looking at an interactable object
                    currentCrosshairMode = CrosshairMode.Interact;
                    break;
                default:
                    // We're looking at an object that can't be used
                    currentCrosshairMode = CrosshairMode.Default;
                    break;
            } // End switch(forwardLookHit.transform.tag)
        } // End if Physics.raycast ...
        else
        {
            // We're looking at nothing or the sky.
            currentCrosshairMode = CrosshairMode.Default;
        } // End else Physics.raycast ...
    } // End void FixedUpdate()

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

    public RaycastHit ForwardLookHit
    {
        get
        {
            return forwardLookHit;
        } // End get
    } // End public RaycastHit ForwardLookHit
} // End public class Crosshair
