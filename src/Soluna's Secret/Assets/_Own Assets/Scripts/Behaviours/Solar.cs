// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]

public class Solar : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private List<GameObject> lightsList = new List<GameObject>();

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    } // End void Start ()

    void Update()
    {
        if (lightsList.Count > 0)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }

        foreach (GameObject go in lightsList)
        {
            Debug.Log(go.name);
        }
    } // End void Update ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            lightsList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            lightsList.Remove(other.gameObject);
        }
    } // End void OnTriggerExit
} // End public class Solar
