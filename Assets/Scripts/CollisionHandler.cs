
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                AddFuel(other);
                break;
            case "Friendly" or "Finish":
                break;
            default:
                BlowUpRocket();
                break;
        }
    }

    void AddFuel(Collision other)
    {
        MeshRenderer mr = other.gameObject.GetComponent<MeshRenderer>();
        mr.enabled = false;
        Debug.Log("you got fuel");
    }

    void BlowUpRocket()
    {
        Debug.Log("YOU DED");
    }
    
}
