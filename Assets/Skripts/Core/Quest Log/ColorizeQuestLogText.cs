using UnityEngine;
using UnityEngine.UI;

public class ColorizeQuestLogText : MonoBehaviour
{
    [SerializeField] private Text text;
    [Space]
    [SerializeField] private Color textColor = Color.white;
    [SerializeField] private char frontChar = '*';

    public void SetValue(string value)
    {
        text.text = $"{frontChar} <color=#{ColorUtility.ToHtmlStringRGBA(textColor)}>{value}</color>";
    }
}
