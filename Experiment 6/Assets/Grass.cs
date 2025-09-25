using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    public float swayStrength = 0.2f; // Amount of sway
    public float swaySpeed = 1.0f; // Speed of sway
    private Vector3 initialRotation;

    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed + transform.position.x) * swayStrength;
        transform.eulerAngles = initialRotation + new Vector3(0f, 0f, sway);
    }
}
