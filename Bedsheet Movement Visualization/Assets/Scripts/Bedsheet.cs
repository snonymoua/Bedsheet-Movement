using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Bedsheet : MonoBehaviour
{
    static public Bedsheet bS;
    
    [Header("Set in Inspector")] public GameObject anchor;

    public GameObject particlePrefab;

    public int numOfParticles = 10;

    public float moveRange = 2;

    public float speed = 0.1f;

    public float velocity = 0.1f;

    public float centering = 0.55f;

    public float radius = 0.65f;

    [Header("Set Dynamically")] private List<GameObject> particles;

    public float birthTime;

    


    void Awake()
    {
        bS = this;
        birthTime = Time.time;
        particles = new List<GameObject>();
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < numOfParticles; i++)
        {
            for (int j = 0; j < numOfParticles; j++)
            {
                GameObject tP = Instantiate(particlePrefab) as GameObject;
                tP.transform.parent = anchor.transform;
                tP.transform.localPosition = new Vector3(i, Random.Range(-moveRange,moveRange), j);
                particles.Add(tP);
            }
        }
    }
}