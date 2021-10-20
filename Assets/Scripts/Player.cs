using EasyJoystick;
using System.Collections.Generic;
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
    public Button abrirButton;

    private Item pickableItem;
    private Puerta openablePuerta;

    private bool looking = true;    // true -> right, false -> left

    // TODO: implementar systema de inventario mas robusto
    private List<KeyColor> inventario = new List<KeyColor>();

    float dx = 0, dy = 0;

    private void Start()
    {
        recogerButton.onClick.AddListener(RecogerItem);
        abrirButton.onClick.AddListener(AbrirPuerta);
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
        GameObject obj = other.gameObject;

        if (obj.tag == "Item")
        {
            Item item = obj.GetComponent<Item>();
            recogerButton.gameObject.SetActive(true);
            pickableItem = item;
        };

        if (obj.tag == "Puerta")
        {
            Puerta puerta = obj.GetComponentInParent<Puerta>();
            abrirButton.gameObject.SetActive(true);
            openablePuerta = puerta;
        }

        if (obj.tag == "Win")
        {
            ChangeScene change = obj.GetComponent<ChangeScene>();
            change.loadScene("WinScene");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (obj.tag == "Item")
        {
            recogerButton.gameObject.SetActive(false);
            pickableItem = null;
        };

        if (obj.tag == "Puerta")
        {
            abrirButton.gameObject.SetActive(false);
            openablePuerta = null;
        }
    }

    private void RecogerItem()
    {
        if (pickableItem != null)
        {
            inventario.Add(pickableItem.Recoger());
            recogerButton.gameObject.SetActive(false);
        }
    }

    private void AbrirPuerta()
    {
        if (openablePuerta != null)
        {
            if (openablePuerta.Abrir(inventario))
            {
                abrirButton.gameObject.SetActive(false);
            } else
            {
                // TODO: CUANDO NO TIENE LLAVE NECESARIA PARA ABRIR PUERTA
            }
        }
    }

    private void Flip()
    {
        looking = !looking;
        bool flip = GetComponent<SpriteRenderer>().flipX;
        GetComponent<SpriteRenderer>().flipX = !flip;
    }
}
