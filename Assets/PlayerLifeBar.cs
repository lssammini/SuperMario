using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;

    public void UpdateHealth(float health)
    {
        healthBarImage.rectTransform.sizeDelta = new Vector2(health, healthBarImage.rectTransform.sizeDelta.y);
    }
}
