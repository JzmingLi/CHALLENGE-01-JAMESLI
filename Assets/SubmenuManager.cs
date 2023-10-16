using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmenuManager : MonoBehaviour
{
    [SerializeField] RectTransform[] rects;
    int currentIndex = 0;
    int nextIndex = 0;
    Vector3 moveOutToPos;
    Vector3 moveInFromPos;
    bool switching;
    private void Start()
    {
        switching = false;
        int i = 0;
        foreach (RectTransform rect in rects)
        {
            if (i != currentIndex || i != nextIndex)
            {
                rect.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void SetMenu(int index)
    {
        if(currentIndex != index)
        {
            switching = true;
            if (currentIndex < index)
            {
                moveOutToPos = Vector3.zero;
                moveOutToPos.x += -1080;
                moveInFromPos = Vector3.zero;
                moveInFromPos.x += 1080;
            }
            if(currentIndex>index)
            {
                moveOutToPos = Vector3.zero;
                moveOutToPos.x += 1080;
                moveInFromPos = Vector3.zero;
                moveInFromPos.x += -1080;
            }
            nextIndex = index;
        }
        
    }

    float SineEaseOut(float start, float end, float t)
    {
        // Ensure t is in the range [0, 1]
        t = Mathf.Clamp01(t);

        // Sine ease-out interpolation using the formula: P(t) = start + Mathf.Sin(t * Mathf.PI * 0.5f) * (end - start)
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
        return start + t * (end - start);
    }
}
