using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleExpression : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.Particle[] particles;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
        // Important: ensure Simulation Space is World in the Inspector
    }

    void Update()
    {
        int count = ps.GetParticles(particles);
        for (int i = 0; i < count; i++)
        {
            Vector3 p = particles[i].position;
            p.y += Mathf.Sin(Time.time * 2f + i) * 0.1f;          // bob up/down
            p.x += (Mathf.PerlinNoise(Time.time * 0.5f, i) - 0.5f) * 0.1f; // drift
            particles[i].position = p;
        }
        ps.SetParticles(particles, count);
    }
}
