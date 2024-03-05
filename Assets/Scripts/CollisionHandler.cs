
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                AddFuel(other);
                break;
            case "Friendly":
                break;

            case "Finish":
                LoadNextLevel();
                break;
            default:
                Respawn();
                break;
        }
    }

    void AddFuel(Collision other)
    {
        MeshRenderer mr = other.gameObject.GetComponent<MeshRenderer>();
        mr.enabled = false;
        Debug.Log("you got fuel");
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
