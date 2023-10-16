using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUIMorph : MonoBehaviour
{
    [SerializeField] GameObject[] tabs;

    private void Update()
    {
        MoveButtons();
    }

    void MoveButtons()
    {
        RectTransform[] rectTransforms = new RectTransform[tabs.Length];
        for(int i = 0; i < tabs.Length; i++)
        {
            rectTransforms[i] = tabs[i].GetComponent<RectTransform>();
        }

        RectTransform previous = rectTransforms[0];
        foreach (RectTransform element in rectTransforms)
        {
            if(element == rectTransforms[0])
            {
                Vector3 newPosition = element.localPosition;
                newPosition.x = element.rect.width / 2;
                element.localPosition = newPosition;
            }
            else
            {
                Vector3 newPosition = element.localPosition;
                newPosition.x = previous.rect.width/2 + previous.localPosition.x + 7 + element.rect.width / 2;
                element.localPosition = newPosition;
                previous = element;
            }
            
        }
    }
}
