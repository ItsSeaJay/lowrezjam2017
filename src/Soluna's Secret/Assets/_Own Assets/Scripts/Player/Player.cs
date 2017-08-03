// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Crosshair crosshair;
    [SerializeField]
    private Subtitles subs; // A little in-joke for me. Should be called 'subtitles'
    [SerializeField]
    private Transform firstPersonCharacter;
    [SerializeField]
    private float reach = 4.0f;

    private Dictionary<string, Inscription> inscriptions = new Dictionary<string, Inscription>();

    void Start ()
	{
        object[] obj = FindObjectsOfType(typeof(GameObject));

        foreach (object o in obj)
        {
            GameObject gameObject = (GameObject) o;
            inscriptions.Add(gameObject.name, gameObject.GetComponent<Inscription>());
        }
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    void FixedUpdate()
    {
        // Set up temporary variables for raycasting
        Vector3 forwardLookVector = firstPersonCharacter.TransformDirection(Vector3.forward);
        RaycastHit forwardLookHit;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Default"); // Collide ray only with default objects

        // Look for objects ahead of the player character
        if (Physics.Raycast(firstPersonCharacter.position, forwardLookVector, out forwardLookHit, reach, layerMask))
        {
            // If one is found, react based on the collision tag
            switch (forwardLookHit.transform.tag)
            {
                case "Lookable":
                    crosshair.CurrentCrosshairMode = Crosshair.CrosshairMode.Look;

                    if (Input.GetButtonDown("Use"))
                    {
                       Inscription displayInscription = inscriptions[forwardLookHit.transform.name];
                       subs.SetTargetMessage(displayInscription.CurrentDisplayedMessage);
                       displayInscription.AdvanceMessage();
                    } // End if input.GetButtonDown
                    break;
                case "Interactable":
                    crosshair.CurrentCrosshairMode = Crosshair.CrosshairMode.Interact;
                    break;
                default:
                    // We are not looking at anything important
                    ResetCursorAndSubtitles();
                    break;
            } // End switch (forwardLookHit.transform.tag)
        } // End if (Physics.Raycast(FirstPersonCharacter.position, forwardLookVector, out crosshairHit, reach)
        else
        {
            // We are still not looking at anything important
            ResetCursorAndSubtitles();
        } // End else (Physics.raycast)
    } // End void FixedUpdate ()

    // private void 

    private void ResetCursorAndSubtitles()
    {
        crosshair.CurrentCrosshairMode = Crosshair.CrosshairMode.Default;
        subs.SetTargetMessage("");
    } // End private void ResetCursorAndSubtitles()
} // End public class Player
