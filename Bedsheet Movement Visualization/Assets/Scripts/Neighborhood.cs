using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighborhood : MonoBehaviour
{
    public List<Particles> neighbors;
    public SphereCollider sCollier;

    // Start is called before the first frame update
    void Start()
    {
        neighbors = new List<Particles>();
        sCollier = GetComponent<SphereCollider>();
        sCollier.radius = Bedsheet.bS.radius;
    }

    void OnTriggerEnter(Collider other)
    {
        Particles gO = other.GetComponent<Particles>();
        if (gO != null)
        {
            if (neighbors.IndexOf(gO) == -1)
            {
                neighbors.Add(gO);
            }
        }
        
    }

    public float avgY
    {
        get
        {
            float avg = 0;
            if (neighbors.Count == 0)
            {
                return avg;
            }

            for (int i = 0; i < neighbors.Count; i++)
            {
                avg += neighbors[i].transform.position.y;
            }

            avg /= neighbors.Count;
            return avg;
        }
    }
}