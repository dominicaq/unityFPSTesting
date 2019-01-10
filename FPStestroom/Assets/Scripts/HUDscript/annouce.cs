using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class annouce : MonoBehaviour
{
    public Text destination;

    // Private feilds
    private string content;
    private float duration;
    private bool remove;
    private bool useTimer;
    public void shout(string cnt, float drt)
    {
        content = cnt;
        duration = drt;
        useTimer = true;
    }

    void Update()
    {
        destination.text = content;
        if(useTimer)
            StartCoroutine(Wait());

        if (remove)
        {
            destination.text = null;
            content = null;
        }
    }

    public IEnumerator Wait()
    {
        remove = false;
        yield return new WaitForSeconds(duration);
        remove = true;
        useTimer = false;
    }
}
