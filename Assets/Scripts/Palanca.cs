using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GameObject))]
public class Palanca : MonoBehaviour
{
    public GameObject btn;
    public GameObject spikesObj;
    private Spike[] spikes;
    public Animator animator;

    private bool activo = true; 

    private void Start()
    {
        spikes = spikesObj.GetComponentsInChildren<Spike>();
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
            animator.SetBool("activo", activo);
            
        }
    }

    private void toggleSpikes()
    {
        foreach (Spike s in spikes)
        {
            s.toggle();
            animator.SetBool("activo", activo);
            
        }
    }
}
