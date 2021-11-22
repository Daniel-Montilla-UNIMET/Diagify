using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Palanca : MonoBehaviour
{
    public GameObject btn;
    public Spike[] spikes;
    public Animator animator;

    private bool activo = false; 

    private void Start()
    {
        btn.GetComponent<Button>().onClick.AddListener(toggleSpikes);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (obj.tag == "Player")
        {
            btn.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (obj.tag == "Player")
        {
            btn.SetActive(false);
            
            
        }
    }

    private void toggleSpikes()
    {
        activo = !activo;
        animator.SetBool("activo", activo);
        
        foreach (Spike s in spikes)
        {
            s.toggle();
            
            
            
        }
    }
}
