using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public bool canGo = false;
    private Light light;

    void Start()
    {
        light = gameObject.GetComponent<Light>();
        StartCoroutine(ChangeLight());
    }

    void Update()
    {
        if (!canGo) light.color = Color.red;
        else light.color = Color.green;
    }

    IEnumerator ChangeLight()
    {
        while (true)
        {
            canGo = !canGo;
            yield return new WaitForSeconds(5f);
        }
    }
}
