using UnityEngine;

public class VictoryObject : MonoBehaviour
{
    public AudioClip collectSound;
    public float volume = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    collectSound,
                    transform.position,
                    volume
                );
            }

            ParachuteManager.instance.CollectParachutePiece();
            Destroy(gameObject);
        }
    }
}