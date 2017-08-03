// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private CrosshairMode currentCrosshairMode;
    private Image crosshairIcon;
    private RectTransform rectTransform;

    void Start ()
	{
        rectTransform = GetComponent<RectTransform>();
        crosshairIcon = GetComponent<Image>();

        currentCrosshairMode = CrosshairMode.Use;
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
        
    } // End void Fixed

    void FixSizeDeltaToSpriteRect(Sprite sprite)
    {
        crosshairIcon.sprite = sprite;
        rectTransform.sizeDelta = new Vector2(sprite.rect.width, sprite.rect.height);
    } // End void FixSizeDeltaToSpriteRect(Sprite sprite)
} // End public class Crosshair
