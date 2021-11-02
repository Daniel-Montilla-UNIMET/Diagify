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

    public AudioClip SonidoAbrir;
    private AudioSource SonidoPuerta;

    public bool hasAnimation = false;
    public UnityEvent onOpen;
    private Animator animator;

    private void Start()
    {
        triggerZone = triggerZoneObj.GetComponent<BoxCollider2D>();
        wallZone = wallZoneObj.GetComponent<BoxCollider2D>();
        SonidoPuerta = GetComponent<AudioSource>();
        if (hasAnimation) {
            animator = GetComponent<Animator>();
            
        }               
    }
    // se agrega el sprite de la puerta para sus futuras animaciones
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
               SonidoPuerta.PlayOneShot(SonidoAbrir,1.0f);
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
