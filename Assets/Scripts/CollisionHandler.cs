using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject DestroyedVFXPrefabVarient;
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"Hit - {other.gameObject.name}");
        Instantiate(DestroyedVFXPrefabVarient,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }

}
