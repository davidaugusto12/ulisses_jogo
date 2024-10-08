using UnityEngine;
using System.Collections;
public class FadeOutAndDeactivate : MonoBehaviour
{
    public CanvasGroup canvasGroup;  // Referência ao CanvasGroup
    public float fadeDuration = 1f;  // Duração do fade out em segundos

    private void Start()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        if (canvasGroup != null)
        {
            StartCoroutine(FadeOutAndDisable());
        }
        else
        {
            Debug.LogError("CanvasGroup não encontrado no GameObject.");
        }
    }

    private IEnumerator FadeOutAndDisable()
    {
        float startAlpha = canvasGroup.alpha;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        gameObject.SetActive(false);  // Desativa o GameObject
    }
}

