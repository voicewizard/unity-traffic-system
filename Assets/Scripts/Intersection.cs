using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Intersection : MonoBehaviour
{
    public Queue<int> queueOfCarIDs;

    void Start()
    {
        queueOfCarIDs = new Queue<int>();
        queueOfCarIDs.Enqueue(1);
        queueOfCarIDs.Dequeue();
    }
}
