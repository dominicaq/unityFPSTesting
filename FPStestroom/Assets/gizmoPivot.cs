using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoPivot : MonoBehaviour {

    public float gizmoSize = .75f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
