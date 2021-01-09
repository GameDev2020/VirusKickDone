using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyLocation : MonoBehaviour
{
    private GameObject objectName;
    private GameObject player;
    [Tooltip("Infection Coefficient is the parameter that defines how much of the infection bar is filling on problems")]
    public float InfectionCoefficient = 0.2f;
    private Slider slider;
    private bool passedEnemy = false;   
    // Start is called before the first frame update

    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    void Start()
    {
        slider = GameObject.FindGameObjectWithTag("Infection Slider").GetComponent<Slider>();        
        string objectName = gameObject.name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (ExtendingVector3.IsGreaterOrEqual(player.gameObject.transform.position, gameObject.transform.position) && !passedEnemy) {
            if (!gameObject.transform.parent.GetChild(0).gameObject.activeSelf)
            {
                FillInfectionSlider();
                passedEnemy = true;
            }            
        }
        
    }
    public void FillInfectionSlider()
    {
        if (slider.value + InfectionCoefficient < slider.maxValue) slider.value += InfectionCoefficient;
        if (slider.value + InfectionCoefficient >= slider.maxValue) slider.value = slider.maxValue;
    }

    public void DrainInfectionSlider()
    {
        if (slider.value - InfectionCoefficient > slider.minValue) slider.value += InfectionCoefficient;
    }
}
