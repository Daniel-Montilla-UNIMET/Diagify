using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void toggle()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        box.enabled = !box.enabled;

        Debug.Log("HIT");
        // TODO: cambiar animacion
    }
}
