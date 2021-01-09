using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ExtendingVector3
{
    public static bool IsGreaterOrEqual(this Vector3 local, Vector3 other)
    {
        if (local.x >= other.x && local.y >= other.y && local.z >= other.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsLesserOrEqual(this Vector3 local, Vector3 other)
    {
        if (local.x <= other.x && local.y <= other.y && local.z <= other.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

[RequireComponent(typeof(Slider))]
public class InfectionFill : MonoBehaviour
{

    [Tooltip("Infection Coefficient is the parameter that defines how much of the infection bar is filling on problems")]
    public float InfectionCoefficient = 0.2f;
    public Slider slider;
    public GameObject alienCharacter, Mesh, insect, player;   
    // Start is called before the first frame update
    void Start()
    {
        
        Reset();
    }  
    public void Reset()
    {
        slider.value = 0;
        slider.minValue = 0;
        slider.maxValue = 1;
    }

    public void FillInfectionSlider()
    {
        if(slider.value + InfectionCoefficient < slider.maxValue) slider.value += InfectionCoefficient;
    }

    public void DrainInfectionSlider()
    {
        if (slider.value - InfectionCoefficient > slider.minValue) slider.value += InfectionCoefficient;
    }

}
