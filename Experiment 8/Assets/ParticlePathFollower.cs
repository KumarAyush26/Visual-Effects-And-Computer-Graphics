using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePathFollower : MonoBehaviour
{
    public Transform[] waypoints;  // Assign waypoints in Inspector
    public float speed = 7f;       // Units per second
    public bool loop = true;       // Should it loop the path?

    private int currentIndex = 0;
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (waypoints.Length > 0)
            transform.position = waypoints[0].position;
    }

    void Update()
    {
        if (waypoints.Length < 2) return;

        // Move toward next waypoint
        Transform target = waypoints[currentIndex];
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // If close to target, advance to next
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                if (loop)
                    currentIndex = 0;
                else
                    ps.Stop(); // Stop emitting at the end
            }
        }
    }
}
