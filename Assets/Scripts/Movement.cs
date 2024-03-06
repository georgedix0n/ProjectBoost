using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource m_audio;

    bool m_ToggleChange;
    [SerializeField] float mainThrust = 1000.0f;
    [SerializeField] float rotationThrust = 10.0f;

    [SerializeField] AudioClip rocketEngineSound;

    [SerializeField] ParticleSystem leftParticles;
    [SerializeField] ParticleSystem rightParticles;

    [SerializeField] ParticleSystem upParticles;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (!m_audio.isPlaying)
            {
                m_audio.PlayOneShot(rocketEngineSound);
            }
            if (!upParticles.isPlaying){
                upParticles.Play();
            }
            
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            m_audio.Stop();
            upParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(!leftParticles.isPlaying)
            {
                leftParticles.Play();
            }
            
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if(!rightParticles.isPlaying)
            {
                rightParticles.Play();
            }
        }
        else
        {
            rightParticles.Stop();
            leftParticles.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
