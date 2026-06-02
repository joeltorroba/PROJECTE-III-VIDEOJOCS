using UnityEngine;

public class TimeFreezePickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        TimeFreezeSystem.instance.StoreFreeze();

        Destroy(gameObject);
    }
}