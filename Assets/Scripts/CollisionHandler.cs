
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float nextLevelDelay = 1f;
    [SerializeField] float respawnDelay = 1f;

    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failureSound;
    AudioSource m_audio;
    bool isTransitioning = false;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;

            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
        
        
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        m_audio.Stop();
        m_audio.PlayOneShot(successSound);
            
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", nextLevelDelay);
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        m_audio.Stop();
        m_audio.PlayOneShot(failureSound);
        
        GetComponent<Movement>().enabled = false;
        Invoke("Respawn", respawnDelay);
    }

    void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % totalScenes;
        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
