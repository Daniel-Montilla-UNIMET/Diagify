using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Transform detectPoint;
    public CircleCollider2D hitbox;
    public LayerMask layer;

    private GameObject detected;

    void Update()
    {
        if (DetectObject())
        {
            detected.GetComponent<Item>().Recoger();
        }
    }

    private bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectPoint.position, hitbox.radius, layer);

        if (obj != null)
        {
            detected = obj.gameObject;
            return true;
        } else
        {
            return false;
        }
    }
}
