// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    enum Item
    {
        Lantern,
        Torch,
        Switch,
        Door,
        Pedastal
    }; // End enum InteractionType

    [SerializeField]
    private Item kind;

    private Player player;

	void Start ()
	{
        // Fix transform tag if it hasn't already
        tag = "Interactable";

        player = GameObject.Find("Player").GetComponent<Player>();
    } // End void Start ()

    public void HandleInteraction()
    {
        switch (kind)
        {
            case Item.Lantern:
                player.Lantern.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                break;
            case Item.Torch:
                break;
            case Item.Switch:
                break;
            case Item.Door:
                break;
            case Item.Pedastal:
                break;
            default:
                Debug.LogError(name + 
                               "'s Interact() switch statement broke!");
                break;
        } // End switch (kind)
    } // End public void Interact()
} // End public class Interactable
