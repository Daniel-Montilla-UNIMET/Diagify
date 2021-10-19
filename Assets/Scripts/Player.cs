using EasyJoystick;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// TODO: crear clase unificadora de UI para organizar
public class Player : MonoBehaviour
{
    //public GameObject UIControls;
    public float speed;
    public Rigidbody2D body;
    public Animator animator;

    public Joystick joystick;
    public Button recogerButton;

    private Item pickableItem;

    private bool looking = true;    // true -> right, false -> left

    public UnityEvent onItemEnter;
    public UnityEvent onItemExit;

    float dx = 0, dy = 0;

    private void Start()
    {
        recogerButton.onClick.AddListener(recogerItem);
    }

    private void Flip()
    {
        looking = !looking;
        bool flip = GetComponent<SpriteRenderer>().flipX;
        GetComponent<SpriteRenderer>().flipX = !flip;
    }

    void Update()
    {
        // Movimiento
        dx = joystick.Horizontal() * speed;
        dy = joystick.Vertical() * speed;
        body.velocity = new Vector2(dx, dy);

        if (dx < 0 && looking)
        {
            Flip();
        } else if (dx > 0 && !looking)
        {
            Flip();
        }




        // Animaciones
        if (dx == 0 && dy == 0) {
            animator.SetFloat("Speed",0);
        } else {
            animator.SetFloat("Speed",1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Check si es una puerta, area
        GameObject obj = other.gameObject;

        if (obj.tag == "Item")
        {
            Item item = obj.GetComponent<Item>();
            onItemEnter.Invoke();
            pickableItem = item;
        };
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onItemExit.Invoke();

        pickableItem = null;
    }

    private void recogerItem()
    {
        if (pickableItem != null)
        {
            pickableItem.Recoger();
            recogerButton.gameObject.SetActive(false);
        }
    }
}
