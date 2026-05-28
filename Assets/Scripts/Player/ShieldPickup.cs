using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShieldSystem shield = other.GetComponent<ShieldSystem>();

            if (shield != null)
            {
                shield.ActivateShield();
            }

            Destroy(gameObject);
        }
    }
}