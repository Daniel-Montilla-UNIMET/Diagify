using EasyJoystick;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 32f;
    public Joystick joystick;
    public Rigidbody2D body;
    public Animator animator;
    

    float dx = 0, dy = 0;

    void Update()
    {
        dx = joystick.Horizontal() * speed;
        dy = joystick.Vertical() * speed;
        body.velocity = new Vector2(dx, dy);

        if (dx == 0 && dy == 0){
            animator.SetFloat("Speed",0);
        }else{
            animator.SetFloat("Speed",1f);
        }


    }
}
