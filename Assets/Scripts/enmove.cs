using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmove : MonoBehaviour
{
    private Rigidbody2D rb2;
    float move_Speed = 100f;
    [SerializeField] float Xt = 1;
    float time_el = 0;
    [SerializeField]
    float time_all = 2;
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
    }
    private void FixedUpdate()
    {
        float dl = Time.deltaTime;
        time_el += dl;
        if (time_el >= time_all)
        {
            time_el = 0;
            flip();
        }
        float sp = Xt * move_Speed * dl;
        Vector2 v2 = new Vector2(sp, rb2.velocity.y);
        rb2.velocity = v2;
    }

    private void flip()
    {
        Vector3 v = transform.localScale;
        v.x *= -1;
        Xt *= -1;
        transform.localScale = v;
    }
}
