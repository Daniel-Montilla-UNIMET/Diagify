using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Puerta : MonoBehaviour
{
    public KeyColor requiredColor;

    public GameObject triggerZoneObj;
    private BoxCollider2D triggerZone;
    public GameObject wallZoneObj;
    private BoxCollider2D wallZone;

    public bool hasAnimation = false;
    public UnityEvent onOpen;
    private Animator animator;

    private void Start()
    {
        triggerZone = triggerZoneObj.GetComponent<BoxCollider2D>();
        wallZone = wallZoneObj.GetComponent<BoxCollider2D>();
        if (hasAnimation) {
            animator = GetComponent<Animator>();
        }               
    }
    public bool Abrir(List<KeyColor> inv)
    {
        if (inv.Contains(requiredColor))
        {
            wallZone.enabled = false;
            triggerZone.enabled = false;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            onOpen.Invoke();
            if (hasAnimation)
            {
               animator.SetBool("Abierto", true);
            } else
            {
                sprite.enabled = false;
            }
            inv.Remove(requiredColor);
            return true;
        } else
        {
            return false;
        }
    }
}
