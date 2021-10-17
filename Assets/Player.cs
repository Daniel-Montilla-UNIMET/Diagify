using EasyJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 32f;
    [SerializeField] private Joystick joystick;

    float dx = 0, dy = 0;
    void Update()
    {
        dx = joystick.Horizontal();
        dy = joystick.Vertical();
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * new Vector3(dx, dy, 0);
    }
}
