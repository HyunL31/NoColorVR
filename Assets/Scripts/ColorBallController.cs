using UnityEngine;

public class ColorBallController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (!collisionObject.CompareTag("Player") && !collisionObject.CompareTag("Mimic") && !collisionObject.CompareTag("Lamp"))
        {
            Destroy(gameObject);
        }
    }
}
