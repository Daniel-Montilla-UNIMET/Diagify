using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    private AIDestinationSetter destinationScript;
    private Transform originalSpot;

    void Start()
    {
        originalSpot = GetComponent<Transform>();
        destinationScript = GetComponent<AIDestinationSetter>();
    }

    public void changeTarget(Transform newTarget)
    {
        destinationScript.target = newTarget;
    }

    public void goToOriginal()
    {
        destinationScript.target = originalSpot;
    }
}
