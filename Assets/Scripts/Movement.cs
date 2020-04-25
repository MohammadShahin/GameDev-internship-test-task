using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float stX;
    [SerializeField] float stY;
    public static Vector2 stPos;
    private Rigidbody2D rb2;
    private Animator animator;
    float move_Speed = 100f;
    bool is_Right = true;
    static float jump_Force = 5f;
    Vector2 jump_Vec = new Vector2(0, jump_Force);
    public static bool is_Grounded = false;
    public static int num_Of_Jumps = 0;
    int allowed_Num_Of_Jumps = 2;
    private float Xt = 0;
    private bool Yt = false;
    public static bool can = true;
    void Start()
    {
        stPos = new Vector2(-8.855f, -2.91f);
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (gameObject.transform.position.y < -50f)
        {
            can = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            if (!is_Right) flip();
            gameObject.transform.position = stPos;
        }
        animator.SetFloat("SpeedX", System.Math.Abs(rb2.velocity.x));
        animator.SetFloat("SpeedY", rb2.velocity.y);
        animator.SetBool("In_The_Air", !is_Grounded);
        if ((rb2.velocity.x > 0 && !is_Right) || (rb2.velocity.x < 0 && is_Right))
        {
            flip();
        }
        Xt = Input.GetAxisRaw("Horizontal");
        if (Xt != 0)
        {
            Xt = Xt / System.Math.Abs(Xt);
        }
        Yt = Input.GetButtonDown("Jump");
        if (Yt && can)
        {
            if (num_Of_Jumps < allowed_Num_Of_Jumps)
            {
                num_Of_Jumps++;
                rb2.AddForce(jump_Vec, ForceMode2D.Impulse);
            }
        }
    }
    private void FixedUpdate()
    {
        float sp = Xt * move_Speed * Time.deltaTime;
        Vector2 v2 = new Vector2(sp, rb2.velocity.y);
        if (can && (Xt != 0)) rb2.velocity = v2;
    }

    private void flip()
    {
        is_Right = !is_Right;
        Vector3 v = transform.localScale;
        v.x *= -1;
        transform.localScale = v;
    }
}
