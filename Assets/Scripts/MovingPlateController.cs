using Unity.VisualScripting;
using UnityEngine;

public class MovingPlateController : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        GameObject player = other.gameObject;
        if (player.CompareTag("Player"))
        {
            player.transform.SetParent(transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag("Player"))
        {
            player.transform.SetParent(null);
        }
    }
}
