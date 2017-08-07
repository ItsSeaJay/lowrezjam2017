// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Crosshair crosshair;
    [SerializeField]
    private Lantern lantern;
    [SerializeField]
    private Subtitles subs; // A little in-joke for me. Should be called 'subtitles'
    [SerializeField]
    private float reach = 4.0f;

    private Dictionary<string, Inscription> inscriptions   = new Dictionary<string, Inscription>();
    private Dictionary<string, Interactable> interactables = new Dictionary<string, Interactable>();
    private Player instance = null;

    void Start ()
	{
        // Iterate over every object in the scene
        object[] obj = FindObjectsOfType(typeof(GameObject));

        foreach (object o in obj)
        {
            // Get all the inscription & interactable components at the start
            GameObject gameObject = (GameObject) o;
            inscriptions.Add(gameObject.name, gameObject.GetComponent<Inscription>());
            interactables.Add(gameObject.name, gameObject.GetComponent<Interactable>());
        } // End foreach (object o in obj)
	} // End void Start ()

	void Update ()
	{
        HandleInput();
	} // End void Update ()

    private void ReadInscription(RaycastHit raycastHit)
    {
        Inscription displayInscription = inscriptions[raycastHit.transform.name];
        displayInscription.AdvanceMessage();
        subs.SetTargetMessage(displayInscription.CurrentlyDisplayedMessage);
    } // End private void ReadInscription();

    private void Interact(RaycastHit raycastHit)
    {
        Interactable interactable = interactables[crosshair.ForwardLookHit.transform.name];
        interactable.HandleInteraction();
    } // End void Interact(RaycastHit raycastHit)

    private void HandleInput()
    {
        // Use key
        if (Input.GetButtonDown("Use"))
        {
            switch (crosshair.CurrentCrosshairMode)
            {
                case Crosshair.CrosshairMode.Default:
                    //Debug.Log("Clicked on a default object.");
                    break;
                case Crosshair.CrosshairMode.Look:
                    //Debug.Log("Clicked on a lookable object.");

                    ReadInscription(crosshair.ForwardLookHit);
                    break;
                case Crosshair.CrosshairMode.Interact:
                    Interact(crosshair.ForwardLookHit);

                    //Debug.Log("Clicked on a interactable object.");
                    break;
                default:
                    //Debug.Log("Clicked on something that broke!");
                    break;
            } // End switch (crosshair.CurrentCrosshairMode)
        } // End if (Input.GetButtonDown)

        // Lantern Toggle
        if (lantern.gameObject.activeInHierarchy)
        {
            if (Input.GetButtonDown("Lantern"))
            {
                if (lantern.IsLit)
                {
                    // The lantern is lit
                    // Turn it off
                    lantern.IsLit = false;
                } // End if (lantern.IsLit)
                else
                {
                    // The lantern is not lit
                    // Turn it on
                    lantern.IsLit = true;
                } // End if (lantern.IsLit)
            } // End if (Input.GetButtonDown("Lantern"))
        } // End if (lantern.gameObject.activeInHierarchy)
    } // End private void HandleLantern()

    // Accessors / Mutators
    public Lantern Lantern
    {
        get
        {
            return lantern;
        }
    }

    public float Reach
    {
        get
        {
            return reach;
        }
        set
        {
            reach = value;
        }
    }
} // End public class Player
