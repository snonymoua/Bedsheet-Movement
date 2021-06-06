using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Particles : MonoBehaviour
{
    [Header("Set Dynamically")] private Rigidbody rb;
    Vector3 pos1 = Vector3.zero;
    Vector3 pos0 = Vector3.zero;
    Vector3 vel = Vector3.zero;
    public Neighborhood _neighborhood;
    Vector3 initialVel = Vector3.zero;
    private float a = 1f;
    private float radians = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos0 = transform.position;
        pos1 = transform.position;
        _neighborhood = GetComponent<Neighborhood>();
        initialVel = Vector3.up;
        if (Random.value > 0.5)
        {
            a *= -1f;
        }
        initialVel*=a;
        initialVel *= Bedsheet.bS.velocity;
        rb.velocity = initialVel;
    }

    void Move()
    {
        // if (Time.time <=1f)
        // {
        //     radians = Time.time * Mathf.PI;
        // }
        // else
        // {
        //     radians = Time.time * Mathf.PI * 0.2f* -1f;
        // }

        // radians = Time.time * Mathf.PI;
        // float u = Mathf.Sin(radians);
        
        Vector3 vel = rb.velocity;
        Vector3 velCenter = new Vector3(0,10,0) - transform.position;
        if (velCenter == Vector3.zero)
        {
            vel = Vector3.zero;
        }
        else
        {
            vel = Vector3.Lerp(vel, velCenter, Bedsheet.bS.centering);
        }

        rb.velocity = vel - rb.velocity;
        // pos0.y = u * pos1.y;
        // transform.position = pos0;                          
    }

    void FixedUpdate()
    {
        Move();

        
        

        // print(rb.velocity);

        // float centerY = _neighborhood.avgY;
        //
        // Vector3 velCenter = transform.position;
        // velCenter.y = centerY;
        //
        // // Vector3 velCenter = _neighborhood.avgY;
        // if (_neighborhood.avgY != 0)
        // {
        //     velCenter -= transform.position;
        //     velCenter.Normalize();
        //     velCenter *= Bedsheet.bS.velocity;
        // }
        //
        // float fdt = Time.fixedDeltaTime;
        //
        // if (velCenter!=Vector3.zero)
        // {
        //     vel = Vector3.Lerp(vel, velCenter, Bedsheet.bS.centering * fdt);
        // }
        //
        // vel = vel.normalized * Bedsheet.bS.velocity;
        // rb.velocity = vel;
        // print(vel);

    }
}