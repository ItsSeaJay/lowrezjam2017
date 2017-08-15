
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedastal : MonoBehaviour
{
    [SerializeField]
    private Transform recepticle;
    [SerializeField]
    private GameObject lanternPickup;

    private bool full = false;
    private Player player;

	void Start ()
	{
        Debug.Assert(recepticle    != null);
        Debug.Assert(lanternPickup != null);

        player = GameObject.Find("Player").GetComponent<Player>();

        tag = "Interactable";
	} // End void Start ()

	void Update ()
	{
        full = lanternPickup.activeInHierarchy;
	} // End void Update ()

    public void ReceiveLantern()
    {
        player.Lantern.gameObject.SetActive(false);
        lanternPickup.SetActive(true);
        lanternPickup.transform.position = recepticle.position;
        player.Lantern.HaloCollider.enabled = false;
        player.Lantern.LanternLight.enabled = false;
    } // End public void ReceiveLantern

    // Accessors/Mutators()
    public bool Full
    {
        get
        {
            return full;
        }
    }
} // End public class Pedastal
