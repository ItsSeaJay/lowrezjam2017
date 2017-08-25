// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    enum Item
    {
        None,
        Lantern,
        Torch,
        Switch,
        Door,
        Pedastal
    }; // End enum InteractionType

    [SerializeField]
    private Item kind = Item.None;

    private Player player;

	void Start ()
	{
        // Fix transform tag if it hasn't already
        tag = "Interactable";

        // TODO: Find a way to make this not terrible
        player = GameObject.Find("Player").GetComponent<Player>();
    } // End void Start ()

    public void HandleInteraction()
    {
        switch (kind)
        {
            case Item.None:
                // Do nothing
                break;
            case Item.Lantern:
                player.Lantern.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                break;
            case Item.Torch:
                break;
            case Item.Switch:
                break;
            case Item.Door:
                Door door = GetComponent<Door>();
                // Attempt to move the door
                door.Pry();
                break;
            case Item.Pedastal:
                Pedastal pedastal = GetComponent<Pedastal>();
                
                if (!pedastal.Full &&
                    player.Lantern.gameObject.activeInHierarchy)
                {
                    pedastal.ReceiveLantern();
                }
                break;
            default:
                Debug.LogError(name + 
                               "'s Interact() switch statement broke!");
                break;
        } // End switch (kind)
    } // End public void Interact()
} // End public class Interactable
