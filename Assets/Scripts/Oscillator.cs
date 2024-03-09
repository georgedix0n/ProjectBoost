using System;
using System.Numerics;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    UnityEngine.Vector3 startingPosition;
    UnityEngine.Vector3 movementVec = new UnityEngine.Vector3(0, 1, 0);
    void Start()
    {
        startingPosition = transform.position;

    }

    
    void Update()
    {

        float scale = -29.0f * MathF.Sin(2.0f * Mathf.PI * Time.time * 0.25f);
        scale = (scale +29f)/2;
        UnityEngine.Vector3 offset = scale * movementVec;
        transform.position = startingPosition + offset;
        Debug.Log(scale);
    }

}
    

    
