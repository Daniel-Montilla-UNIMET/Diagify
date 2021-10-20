using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

// TODO: cambiar nombre a Key/Llave
public class Item : MonoBehaviour
{
    public KeyColor color = KeyColor.none;
    public UnityEvent onPickup;

    public KeyColor Recoger()
    {
        gameObject.SetActive(false);
        onPickup.Invoke();
        return color;
    }

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
