using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private int selectedWeapon = 0;

    private Transform m_Transform;

    private void Awake()
    {
        m_Transform = transform;
        SelectWeapon();
    }

    private void Update()
    {
        ScrollInputs();
        AlphaNumbersInputs();
    }

    private void AlphaNumbersInputs()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedWeapon = 0;

        else if (Input.GetKeyDown(KeyCode.Alpha2) && m_Transform.childCount >= 2)
            selectedWeapon = 1;
        
        else if (Input.GetKeyDown(KeyCode.Alpha3) && m_Transform.childCount >= 3)
            selectedWeapon = 2;

        else if (Input.GetKeyDown(KeyCode.Alpha4) && m_Transform.childCount >= 4)
            selectedWeapon = 3;

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void ScrollInputs()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= m_Transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = m_Transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }    

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform item in m_Transform)
        {
            if (i == selectedWeapon)
            {
                item.gameObject.SetActive(true);   
            }
            else
            {
                item.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
