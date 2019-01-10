using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthHUD : MonoBehaviour
{
    hpScript playerHP;
    public Text armor;
    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = transform.GetComponent<hpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Store int and convert to string for HUD
        int hp = playerHP.health_bar;
        int armorint = playerHP.armor;

        string armorString = armorint.ToString();
        string hpString = hp.ToString();
        //


        // Set HUD text
        armor.text = armorString;
        health.text = hpString;
    }
}
