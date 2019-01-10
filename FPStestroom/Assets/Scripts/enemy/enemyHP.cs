using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public int unitHP;
    public int unitMaxHP;
    public float lingerLength;
    public bool enemyDead;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unitHP > unitMaxHP)
            unitHP = unitMaxHP;

        if(enemyDead)
        {
            rigid.useGravity = true;
            rigid.AddForce(0,0,5);
            Destroy(this.gameObject, lingerLength);
        }
    }

    public void enemyDamage(int amount)
    {
        unitHP -= amount;
    }

    public void enemyHeal(int amount)
    {
        unitHP += amount;
    }
}
