using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidthAnimation : MonoBehaviour
{
    [SerializeField] float targetWidth;
    private float animationDuration = 0.3f;  // Set the animation duration in seconds

    private RectTransform rectTransform;
    private float originalWidth;
    private float currentWidth;
    private bool isHovered = false;
    private float progress = 0f; // Progress variable to control lerping

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalWidth = rectTransform.sizeDelta.x;
        targetWidth += originalWidth;
        currentWidth = originalWidth;
    }

    private void Update()
    {
        if (isHovered)
        {
            progress += Time.deltaTime;
            progress = Mathf.Clamp(progress, 0f, animationDuration);
            currentWidth = SineEaseOut(originalWidth, targetWidth, progress / animationDuration);
        }
        else
        {
            progress -= Time.deltaTime;
            progress = Mathf.Clamp(progress, 0f, animationDuration);
            currentWidth = SineEaseOut(targetWidth, originalWidth, (animationDuration - progress) / animationDuration);
        }
        rectTransform.sizeDelta = new Vector2(currentWidth, rectTransform.sizeDelta.y);
    }

    float SineEaseOut(float start, float end, float t)
    {
        // Ensure t is in the range [0, 1]
        t = Mathf.Clamp01(t);

        // Sine ease-out interpolation using the formula: P(t) = start + Mathf.Sin(t * Mathf.PI * 0.5f) * (end - start)
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
        return start + t * (end - start);
    }

    public void OnPointerEnter()
    {
        isHovered = true;
        
    }

    public void OnPointerExit()
    {
        isHovered= false;
    }
}
