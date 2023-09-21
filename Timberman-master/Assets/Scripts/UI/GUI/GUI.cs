using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GUI : MonoBehaviour
{
    [SerializeField] private Image _redBar;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    void Start()
    {
        SetBarProgress(0.5f);
    }
    

    public void SetScore(int value)
    {
        scoreText.text = value + "";
    }
    public void SetBarProgress(float percentage)
    {
        float total = 179.2f;
        float p = total - (percentage * total);
        var transform1 = _redBar.transform;
        var localPosition = transform1.localPosition;
    
        float newX = Mathf.Clamp(0.2f - p, -180f, 0f);
        localPosition.x = newX;
        transform1.localPosition = localPosition;
    }

}
