using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Text numText;
    [SerializeField] private RectTransform rectTransform;

    private int number;
    
    public int GetNumber()
    {
        return number;
    }
    
    public float GetSize()
    {
        return rectTransform.sizeDelta.x;
    }
    
    public void Set(int num)
    {
        number = num;
        numText.text = num.ToString();
        rectTransform.sizeDelta = Vector2.one * num * 50;
    }
}
