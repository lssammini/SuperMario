using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Life : MonoBehaviour
{
    public RectTransform rectTransform;

    public void UpdateHealth(float health)
    {

        Debug.Log(health + " vida atual");
        // Get the current offset values
        Vector2 offsetMax = rectTransform.offsetMax;
        Vector2 offsetMin = rectTransform.offsetMin;

        // Update the right position
        offsetMax.x = health; // Set the new right position here

        Debug.Log(rectTransform + " vida a ser mudada");

        // Apply the changes to the rectTransform
        rectTransform.offsetMax = offsetMax;
        rectTransform.offsetMin = offsetMin;
    }
}
