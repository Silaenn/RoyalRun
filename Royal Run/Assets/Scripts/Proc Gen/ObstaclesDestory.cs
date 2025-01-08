using UnityEngine;

public class ObstaclesDestory : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
