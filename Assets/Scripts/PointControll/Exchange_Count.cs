using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExchangeCount : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private int incrementAmount = 1;

    public void IncreaseValue()
    {
        int currentValue = int.Parse(textMeshPro.text);
        int newValue = currentValue + incrementAmount;
        textMeshPro.text = newValue.ToString();
    }

    public void DecreaseValue()
    {
        int currentValue = int.Parse(textMeshPro.text);
        int newValue = currentValue - incrementAmount;

        if (newValue <= 0)
        {
            return;
        }

        textMeshPro.text = newValue.ToString();
    }
}
