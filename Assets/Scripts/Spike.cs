using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spike : MonoBehaviour
{

    public Animator animator;
    private bool activo = true;

    public void toggle()
    {
        animator.SetBool("trampa", activo);
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        box.enabled = !box.enabled;


        Debug.Log("HIT");
        // TODO: cambiar animacion
    }
}
