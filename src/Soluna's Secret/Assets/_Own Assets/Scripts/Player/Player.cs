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

    private Dictionary<string, Inscription> inscriptions = new Dictionary<string, Inscription>();

    void Start ()
	{
        // Iterate over every object in the scene
        object[] obj = FindObjectsOfType(typeof(GameObject));

        foreach (object o in obj)
        {
            // Get all the inscription components at the start
            GameObject gameObject = (GameObject) o;
            inscriptions.Add(gameObject.name, gameObject.GetComponent<Inscription>());
        } // End foreach (object o in obj)
	} // End void Start ()

	void Update ()
	{
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
                    // React based on the object type
                    if (crosshair.ForwardLookHit.transform.name.Contains("Lantern Pickup"))
                    {
                        PickUpLantern(crosshair.ForwardLookHit.transform.gameObject);
                    } // End if (crosshair.ForwardLookHit.transform.name.Contains("Lantern Pickup"))

                    //Debug.Log("Clicked on a interactable object.");
                    break;
                default:
                    //Debug.Log("Clicked on something that broke!");
                    break;
            } // End switch (crosshair.CurrentCrosshairMode)
        } // End if (Input.GetButtonDown)
	} // End void Update ()

    private void ReadInscription(RaycastHit forwardLookHit)
    {
        Inscription displayInscription = inscriptions[forwardLookHit.transform.name];
        displayInscription.AdvanceMessage();
        subs.SetTargetMessage(displayInscription.CurrentlyDisplayedMessage);
    } // End private void ReadInscription();

    private void PickUpLantern(GameObject lanternPickup)
    {
        lanternPickup.SetActive(false);
        lantern.gameObject.SetActive(true);
    } // End private void PickUpLantern()

    // Accessors / Mutators
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
