using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmo : MonoBehaviour
{
    private float distance;
    void Start()
    {
        distance = gameObject.GetComponentInParent<CarNavigation>().distance;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 dir = transform.TransformDirection(Vector3.forward) * distance;
        Gizmos.DrawRay(transform.position, dir);
    }
}
