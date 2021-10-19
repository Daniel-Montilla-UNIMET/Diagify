using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public void Recoger()
    {
        Debug.Log("HELLO!");
    }

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
