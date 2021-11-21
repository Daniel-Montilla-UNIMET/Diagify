using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spike : MonoBehaviour
{
    public Animator animator;

    private bool activo = true;
    public void toggle()
    {
        
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        box.enabled = !box.enabled;

        animator.SetBool("trampa", activo);
        Debug.Log("HIT");
        // TODO: cambiar animacion
    }

    
}
