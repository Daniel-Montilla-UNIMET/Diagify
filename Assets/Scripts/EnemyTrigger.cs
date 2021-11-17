using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Enemigo enemigo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Player")
        {
            enemigo.changeTarget(obj.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("SALIENDO");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            enemigo.goToOriginal();
        }
    }
}
