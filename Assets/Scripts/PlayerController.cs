using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;

    private Rigidbody2D rb;
    private InputController input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputController>();
    }


    private void Update()
    {
        // jump
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }


    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(
            input.Current.Movement.x * Time.fixedDeltaTime * moveSpeed, 0
        ));
    }
}
