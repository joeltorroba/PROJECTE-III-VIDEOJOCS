using UnityEngine;

public class ShieldBubble : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BadObject>())
        {
            Destroy(other.gameObject);
        }
    }
}