using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFXPrefab;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFXPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
        // Quaternion.identity = no rotation
    }
}
