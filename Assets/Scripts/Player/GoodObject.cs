using UnityEngine;

public class GoodObject : MonoBehaviour
{
    public float slowFallSpeed = 6f;
    public float effectDuration = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FallSystem fall = other.GetComponent<FallSystem>();

            if (fall != null)
            {
                fall.ModifyFallSpeed(slowFallSpeed, effectDuration);
            }

            Destroy(gameObject);
        }
    }
}