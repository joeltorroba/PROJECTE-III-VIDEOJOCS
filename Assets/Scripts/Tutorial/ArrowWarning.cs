using UnityEngine;
using System.Collections;

public class ArrowBlink : MonoBehaviour
{
    public GameObject leftWhite;
    public GameObject rightWhite;

    public GameObject leftRed;
    public GameObject rightRed;

    public float blinkSpeed = 0.4f;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            leftWhite.SetActive(true);
            rightWhite.SetActive(true);

            leftRed.SetActive(false);
            rightRed.SetActive(false);

            yield return new WaitForSeconds(blinkSpeed);

            leftWhite.SetActive(false);
            rightWhite.SetActive(false);

            leftRed.SetActive(true);
            rightRed.SetActive(true);

            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}