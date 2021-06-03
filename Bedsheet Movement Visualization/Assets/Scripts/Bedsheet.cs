using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Bedsheet : MonoBehaviour
{
    [Header("Set in Inspector")] public GameObject anchor;

    public GameObject particlePrefab;

    public int numOfParticles = 10;

    public float lifeTime = 5;

    public float moveRange = 2;

    public float sinEccentricity = 0.6f;

    [Header("Set Dynamically")] private List<GameObject> particles;

    public float birthTime;

    
    void Start()
    {
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
                tP.transform.localPosition = new Vector3(i, Random.Range(-moveRange, moveRange), j);
                particles.Add(tP);
            }
        }
    }

    void Move()
    {
        foreach (GameObject p in particles)
        {
            Vector3 pos = p.transform.position;
            float u = (Time.time - birthTime) / lifeTime;
            u = u + sinEccentricity * (Mathf.Sin(u * Mathf.PI * 2));
            pos.y = (1 - u) * -moveRange + u * moveRange;
            p.transform.position = pos;
        }
    }

    void Update()
    {
        Move();
    }
}