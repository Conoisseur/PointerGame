using System.Collections;
using UnityEngine;

public class FadeOutBlackBackground : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 15f; // Duration of the fade
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer != null)
        {
            // Ensure the sprite starts fully opaque (alpha = 1)
            Color initialColor = _spriteRenderer.color;
            _spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);

            // Start the fade-out coroutine
            StartCoroutine(FadeOut());
        }
        else
        {
            Debug.LogError("No SpriteRenderer component found on the GameObject. Attach this script to a black background object.");
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        // Get the starting color
        Color startColor = _spriteRenderer.color;

        // Define the target color (same RGB, but alpha = 0)
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < fadeDuration)
        {
            // Gradually interpolate the alpha value over time
            _spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is fully transparent
        _spriteRenderer.color = targetColor;

        // Optional: Disable the GameObject after fading
        gameObject.SetActive(false);
    }
}
