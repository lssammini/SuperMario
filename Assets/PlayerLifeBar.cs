using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform rectTransform;

    public void UpdateHealth(float health)
    {
        // Get the current offset values
        Vector2 offsetMax = rectTransform.offsetMax;
        Vector2 offsetMin = rectTransform.offsetMin;

        // Update the right position
        offsetMax.x = health; // Set the new right position here

        // Apply the changes to the rectTransform
        rectTransform.offsetMax = offsetMax;
        rectTransform.offsetMin = offsetMin;
    }
}
