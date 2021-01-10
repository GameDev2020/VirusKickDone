using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Slider_Fill : MonoBehaviour
{
    [Tooltip("How long does it take for this slider to fill, in seconds")]
    private float FillTime;
    private Slider _slider;
    void Start()
    {
        FillTime = GameManager.Instance.nextLeveltime;
        _slider = GetComponent<Slider>();
        Reset();        
    }

    public void Reset()
    {
        
        _slider.minValue = Time.time;
        _slider.maxValue = Time.time + FillTime;
    }
    void Update()
    {
        if (GameManager.Instance.startGame == false)
        {
            Reset();
        }
        _slider.value = Time.time;        
    }
}
