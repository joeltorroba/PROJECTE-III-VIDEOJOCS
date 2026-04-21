using UnityEngine;

public class VictoryObject : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ParachuteManager.instance.CollectParachutePiece();
            Destroy(gameObject);
        }
    }
}