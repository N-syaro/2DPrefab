using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Player_Cont_Action : MonoBehaviour
{
    [Header("プレイヤースピード"), SerializeField]
    private float P_sp = 5f;
    [Header("ジャンプパワー"), SerializeField]
    private float P_jp = 4;
    [SerializeField]
    private Transform Gro_Check;
    [SerializeField]
    private float Gro_CheckRad = 0.2f;
    [SerializeField]
    private LayerMask gro_layer;

    private bool isGrounded;
    private Vector2 Inp_Dire;
    private Rigidbody2D Rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(Gro_Check.position, Gro_CheckRad, gro_layer);
        Move();  
    }
    private void Move()
    {
        Rb2d.linearVelocity = new Vector2(Inp_Dire.x * P_sp, Rb2d.linearVelocity.y);
    }
    private void Jump()
    {
        if (isGrounded)
        {
            this.Rb2d.AddForce(transform.up * P_jp, ForceMode2D.Impulse);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Inp_Dire=context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }
}
