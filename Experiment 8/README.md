🟢 nParticle Swarm & Bubble Masses in Unity

This project demonstrates particle systems in Unity to create swarming particles (nParticle swarms) and floating bubbles whose behavior is controlled using expressions and scripts.

Project Overview

nParticle Swarm: Particles move collectively toward a target, simulating flocking or swarm behavior.

Bubble Masses: Particles float upward, expand and contract over time, simulating buoyancy.

Setup Steps
1. Unity Project

Open Unity → New Project → 3D.

Name the project (e.g., nParticleSwarm).

2. Create Particle Systems

nParticleSwarm

Hierarchy → Right-click → Effects → Particle System.

Set Duration, Looping, Start Lifetime, Speed, Size, Color.

BubbleMasses

Duplicate particle system → rename BubbleMasses.

Adjust Velocity over Lifetime and Size over Lifetime to simulate bubble movement.

3. Configure Emission & Shape

Emission: Set rate over time or bursts.

Shape: Sphere, Box, or custom shape depending on desired distribution.

4. Add Swarm Behavior Script

Create C# script nParticleSwarmController:

using UnityEngine;

public class nParticleSwarmController : MonoBehaviour
{
    public ParticleSystem ps;
    private ParticleSystem.Particle[] particles;
    public Transform target;
    public float speed = 2f;

    void Start()
    {
        if (!ps) ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    void Update()
    {
        int count = ps.GetParticles(particles);
        for (int i = 0; i < count; i++)
        {
            Vector3 dir = (target.position - particles[i].position).normalized;
            particles[i].velocity += dir * speed * Time.deltaTime;
        }
        ps.SetParticles(particles, count);
    }
}


Attach script to nParticleSwarm and assign a target GameObject.

5. Fine-Tune Particle Behavior

Enable Collision for realistic interaction.

Add Noise for turbulence.

Adjust Size, Speed, and Lifetime for desired visual effect.

6. Play & Observe

Press Play in Unity:

Swarm particles move toward the target.

Bubble particles float upward, expand, and contract.

Adjust parameters in real time to refine behavior.

Outcome

nParticles behave like a cohesive swarm moving toward a target.

Bubble particles show buoyant motion with size variation.

Fully interactive particle system controlled with expressions and scripts.
