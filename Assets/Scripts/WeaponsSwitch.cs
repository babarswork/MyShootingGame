using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    public GameObject[] weapons; // put prefabs

    public int currentWeapon;
    //private int nrWeapons;
    // Start is called before the first frame update
    void Start()
    {

        //nrWeapons = weapons.Length;

        SwitchWeapon(currentWeapon); // Set default gun
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(3);
        }
        //for (int i = 1; i <= nrWeapons; i++)
        //{
        //    if (Input.GetKeyDown("" + i))
        //    {
        //        currentWeapon = i - 1;

        //        SwitchWeapon(currentWeapon);
        //    }
        //}

    }
    void SwitchWeapon(int index)
    {
        //you press a number it disables all other weapons and enables the one you are selecting to.
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
