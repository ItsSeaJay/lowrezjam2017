// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Crosshair crosshair;
    [SerializeField]
    private GameObject noLanternSign;
    [SerializeField]
    private Lantern lantern;
    [SerializeField]
    private Subtitles subs; // A little in-joke for me. Should be called 'subtitles'
    [SerializeField]
    private float reach = 4.0f;
    [SerializeField]
    private float disableDistance = 1.0f;

    private List<GameObject> solarList = new List<GameObject>();
    private List<GameObject> lunarList = new List<GameObject>();
    private bool collidingWithSolarObject = false;
    private bool collidingWithLunarObject = false;

    void Start ()
	{ } // End void Start ()

	void Update ()
	{
        noLanternSign.SetActive(collidingWithSolarObject || collidingWithLunarObject);

        HandleInput();
        CleanupSolarList();
        CheckSolarDistance();
        CleanupLunarList();
        CheckLunarDistance();
	} // End void Update ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Solar" &&
            !solarList.Contains(other.gameObject))
        {
            solarList.Add(other.gameObject);
        }

        if (other.tag == "Lunar" &&
            !lunarList.Contains(other.gameObject))
        {
            lunarList.Add(other.gameObject);
        }
    } // End OnTriggerEnter(Collider other)

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Solar" &&
            !solarList.Contains(other.gameObject))
        {
            solarList.Remove(other.gameObject);
        }

        if (other.tag == "Lunar" &&
            !lunarList.Contains(other.gameObject))
        {
            lunarList.Remove(other.gameObject);
        }
    } // End OnTriggerEnter(Collider other)

    private void ReadInscription(RaycastHit raycastHit)
    {
        Inscription displayInscription = raycastHit.transform.gameObject.GetComponent<Inscription>();
        displayInscription.AdvanceMessage();
        subs.SetTargetMessage(displayInscription.CurrentlyDisplayedMessage);
    } // End private void ReadInscription();

    private void Interact(RaycastHit raycastHit)
    {
        Interactable interactable = raycastHit.transform.gameObject.GetComponent<Interactable>();
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
            if (Input.GetButtonDown("Lantern") &&
                !collidingWithSolarObject &&
                !collidingWithLunarObject)
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

    private void CleanupSolarList()
    {
        // Check for solar objects
        for (int i = 0; i < solarList.Count; ++i)
        {
            // If a light in the list is no longer available
            if (!solarList[i].activeInHierarchy ||
                 solarList[i] == null)
            {
                // Remove that item from the list
                solarList.Remove(solarList[i]);
            } // End if (!go.activeInHierarchy || ..
        } // End foreach(GameObject go in lightsList)
    } // End private void CleanupSolarList()

    private void CheckSolarDistance()
    {
        // Iterate through the solar list
        for (int i = 0; i < solarList.Count; ++i)
        {
            // If the player gets too close to that object
            if (Vector3.Distance(transform.position, solarList[i].transform.position) < disableDistance)
            {
                collidingWithSolarObject = true;
            }
            else
            {
                collidingWithSolarObject = false;
            }
        }
    }

    private void CleanupLunarList()
    {
        // Check for solar objects
        for (int i = 0; i < lunarList.Count; ++i)
        {
            // If a light in the list is no longer available
            if (!lunarList[i].activeInHierarchy ||
                 lunarList[i] == null)
            {
                // Remove that item from the list
                solarList.Remove(solarList[i]);
            } // End if (!go.activeInHierarchy || ..
        } // End foreach(GameObject go in lightsList)
    } // End private void CleanupLunarList()

    private void CheckLunarDistance()
    {
        // Iterate through the solar list
        for (int i = 0; i < lunarList.Count; ++i)
        {
            // If the player gets too close to that object
            if (Vector3.Distance(transform.position, lunarList[i].transform.position) < disableDistance)
            {
                collidingWithLunarObject = true;
            }
            else
            {
                collidingWithLunarObject = false;
            }
        }
    }

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
