using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerCollisionVFX;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(playerCollisionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
