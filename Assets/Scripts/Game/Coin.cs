using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

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

            CoinManager.instance.AddCoin(value);

            Destroy(gameObject);
        }
    }
}