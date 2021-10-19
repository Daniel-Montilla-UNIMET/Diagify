using EasyJoystick;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 32f;
    public Joystick joystick;
    public Rigidbody2D body;

    float dx = 0, dy = 0;

    void Update()
    {
        dx = joystick.Horizontal() * speed;
        dy = joystick.Vertical() * speed;
        body.velocity = new Vector2(dx, dy);
    }
}
