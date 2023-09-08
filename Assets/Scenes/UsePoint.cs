using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextMeshProController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int incrementAmount = 100;
    private int minValue = 100;

    public void IncreaseValue()
    {
        int currentValue = int.Parse(textMeshPro.text);
        int newValue = currentValue + incrementAmount;

        if (newValue < minValue)
        {
            newValue = minValue;
        }

        textMeshPro.text = newValue.ToString();
    }

    public void DecreaseValue()
    {
        int currentValue = int.Parse(textMeshPro.text);
        int newValue = currentValue - incrementAmount;

        if (newValue < minValue)
        {
            newValue = minValue;
        }

        textMeshPro.text = newValue.ToString();
    }
}
