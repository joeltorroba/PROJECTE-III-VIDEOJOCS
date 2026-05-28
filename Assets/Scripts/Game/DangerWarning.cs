using UnityEngine;
using UnityEngine.UI;

public class DangerWarning : MonoBehaviour
{
    public Image warningImage;

    [Header("Warning Settings")]
    public float maxDistance = 12f;
    public float flashSpeed = 2f;

    private Transform player;

    void Update()
    {
        // Buscar player si aún no existe
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");

            if (p != null)
            {
                player = p.transform;
            }
            else
            {
                return;
            }
        }

        // Seguridad
        if (warningImage == null)
            return;

        BadObject[] badObjects =
            FindObjectsByType<BadObject>(FindObjectsSortMode.None);

        float closestDistance = Mathf.Infinity;

        foreach (BadObject bad in badObjects)
        {
            if (bad == null)
                continue;

            // Ignorar objetos ya pegados
            if (bad.transform.parent == player)
                continue;

            // 🔥 IGNORAR si ya pasó al player
            if (bad.transform.position.y < player.position.y)
                continue;

            float dist =
                Vector3.Distance(player.position, bad.transform.position);

            if (dist < closestDistance)
            {
                closestDistance = dist;
            }
        }

        // Si hay peligro cerca
        if (closestDistance < maxDistance)
        {
            float intensity =
                1f - (closestDistance / maxDistance);

            // Parpadeo suave
            float alpha =
                (Mathf.Sin(Time.time * flashSpeed) + 1f) / 2f;

            alpha *= intensity * 0.75f;

            Color c = warningImage.color;
            c.a = alpha;
            warningImage.color = c;
        }
        else
        {
            // Fade suave al desaparecer
            Color c = warningImage.color;

            c.a = Mathf.Lerp(c.a, 0f, Time.deltaTime * 5f);

            warningImage.color = c;
        }
    }
}