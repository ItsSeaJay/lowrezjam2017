﻿// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Solar : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    public List<GameObject> lightsList = new List<GameObject>();

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

        // Cleanup lights list
        for (int i = 0; i < lightsList.Count; ++i)
        {
            if (!lightsList[i].activeInHierarchy ||
                lightsList[i] == null)
            {
                lightsList.Remove(lightsList[i]);
            } // End if (!go.activeInHierarchy || ..
        } // End foreach(GameObject go in lightsList)
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
