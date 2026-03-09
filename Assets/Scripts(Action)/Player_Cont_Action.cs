using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Player_Cont_Action : MonoBehaviour
{
    [Header("プレイヤースピード"), SerializeField]
    private float P_sp = 5f;

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
        Move();  
    }
    private void Move()
    {
        Rb2d.linearVelocity = new Vector2(Inp_Dire.x * P_sp, Rb2d.linearVelocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Inp_Dire=context.ReadValue<Vector2>();
    }
}
