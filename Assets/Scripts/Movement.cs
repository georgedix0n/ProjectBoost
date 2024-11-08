using UnityEngine.SceneManagement;
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
        RespondToDebugKeys();

    }

    void RespondToDebugKeys()
    {
        SkipToNextLevel();
        DisableCollisions();
    }

    void DisableCollisions()
    {
        if(Input.GetKey(KeyCode.C))
        {
            rb.detectCollisions = !rb.detectCollisions;
        }
    }

    void SkipToNextLevel()
    {
        if(Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            KillRotation();
        }
    }

    void StartThrusting()
    {
        if (!m_audio.isPlaying)
        {
            m_audio.PlayOneShot(rocketEngineSound);
        }
        if (!upParticles.isPlaying)
        {
            upParticles.Play();
        }

        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    void StopThrusting()
    {
        m_audio.Stop();
        upParticles.Stop();
    }

    void RotateLeft()
    {
        if (!leftParticles.isPlaying)
        {
            leftParticles.Play();
        }

        ApplyRotation(rotationThrust);
    }
    

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!rightParticles.isPlaying)
        {
            rightParticles.Play();
        }
    }

    private void KillRotation()
    {
        rightParticles.Stop();
        leftParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void LoadNextLevel()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % totalScenes;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
