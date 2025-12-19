using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HorrorUI : MonoBehaviour
{
    public static HorrorUI Instance;

    [Header("UI")]
    public Image faceImage;
    public Image fadeImage;

    [Header("Audio")]
    public AudioSource jumpScareSE;

    [Header("Shake")]
    public float shakePower = 20f;

    void Awake()
    {
        Instance = this;

        faceImage.gameObject.SetActive(false);
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void Show()
    {
        Time.timeScale = 0f;

        faceImage.gameObject.SetActive(true);
        jumpScareSE.Play();

        faceImage.rectTransform.localScale = Vector3.one * 0.1f;

        StartCoroutine(ZoomIn());
        StartCoroutine(ShakeFace());
        StartCoroutine(FadeOutAfterDelay());
    }

    IEnumerator ZoomIn()
    {
        float t = 0f;
        while (t < 0.2f)
        {
            t += Time.unscaledDeltaTime;
            faceImage.rectTransform.localScale =
                Vector3.Lerp(Vector3.one * 0.1f, Vector3.one * 2.5f, t / 0.2f);
            yield return null;
        }
    }

    IEnumerator ShakeFace()
    {
        Vector3 basePos = faceImage.rectTransform.localPosition;

        while (true)
        {
            float x = Random.Range(-shakePower, shakePower);
            float y = Random.Range(-shakePower, shakePower);

            faceImage.rectTransform.localPosition = basePos + new Vector3(x, y, 0);
            yield return new WaitForSecondsRealtime(0.03f);
        }
    }

    IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3f);

        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.unscaledDeltaTime;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
