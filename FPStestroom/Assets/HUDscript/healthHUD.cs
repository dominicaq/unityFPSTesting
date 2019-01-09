using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthHUD : MonoBehaviour
{
    hpScript playerData;
    public Text armor;
    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        playerData = transform.GetComponent<hpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        int hp = playerData.health_bar;
        int armorint = playerData.armor;
        
        string armorString = armorint.ToString();
        string hpString = hp.ToString();

        armor.text = armorString;
        health.text = hpString;
    }
}
