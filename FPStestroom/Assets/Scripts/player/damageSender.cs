using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageSender : MonoBehaviour
{
    public int damage;
    public float lingerDuration;
    public float radius;
    public bool peircing = false;
    public bool damageFalloff;
    SphereCollider myCollider;
    float distance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = radius;
        
        //Play animation and sound here
    }

    private void OnTriggerEnter(Collider other) 
    {
        hpScript player = other.gameObject.GetComponent<hpScript>(); // Theres no errors, works fine
        enemyHP enemy = other.gameObject.GetComponent<enemyHP>();
        if (damageFalloff)
        {
            distance = Vector3.Distance(this.transform.position, other.gameObject.transform.position); // Distance between objects
            if (distance > radius/2)
                damage = damage/2;
        }
        
        try
        {
            player.actionDamage(damage, peircing);
        }
        catch
        {
            enemy.enemyDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lingerDuration);
    }
}
