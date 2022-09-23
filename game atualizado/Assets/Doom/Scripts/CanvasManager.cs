using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public GameObject macaco1;
    public GameObject macaco2;
    public GameObject macaco3;
    public GameObject macaco4;

    public HealthSystem hh;

    public void UpdateHealthIndicator(int healthValue)
    {
        if (healthValue >= 66)
        {
            //healthIndicator.sprite = health1;
            macaco1.SetActive(true);
            macaco2.SetActive(false);
            macaco3.SetActive(false);
            macaco4.SetActive(false);
        }
        else if (healthValue < 66 && healthValue >= 33)
        {
            //healthIndicator.sprite = health2;
            macaco1.SetActive(false);
            macaco2.SetActive(true);
            macaco3.SetActive(false);
            macaco4.SetActive(false);
        }
        else if (healthValue < 33 && healthValue > 0)
        {
            //healthIndicator.sprite = health3;
            macaco1.SetActive(false);
            macaco2.SetActive(false);
            macaco3.SetActive(true);
            macaco4.SetActive(false);
        }
        else if (healthValue <= 0)
        {
            //healthIndicator.sprite = health4;
            macaco1.SetActive(false);
            macaco2.SetActive(false);
            macaco3.SetActive(false);
            macaco4.SetActive(true);
        }
}
}
