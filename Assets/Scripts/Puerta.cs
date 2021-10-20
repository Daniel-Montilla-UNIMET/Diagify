using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puerta : MonoBehaviour
{
    public KeyColor requiredColor;

    public GameObject triggerZoneObj;
    private BoxCollider2D triggerZone;
    public GameObject wallZoneObj;
    private BoxCollider2D wallZone;

    private void Start()
    {
        triggerZone = triggerZoneObj.GetComponent<BoxCollider2D>();
        wallZone = wallZoneObj.GetComponent<BoxCollider2D>();
    }
    public bool Abrir(List<KeyColor> inv)
    {
        if (inv.Contains(requiredColor))
        {
            wallZone.enabled = false;
            triggerZone.enabled = false;
            inv.Remove(requiredColor);
            return true;
        } else
        {
            return false;
        }
    }
}
