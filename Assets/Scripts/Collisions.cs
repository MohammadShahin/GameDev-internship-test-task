using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    private float ep = 0.01f;
    private void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy1" || col.gameObject.tag == "enemy2")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            Movement.is_Grounded = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Movement.can = false;
        }
        if (col.gameObject.tag == "ground")
        {
            foreach (ContactPoint2D contact in col.contacts)
            {
                Vector2 v = contact.point;
                CircleCollider2D cc2 = gameObject.GetComponent<CircleCollider2D>();
                Vector2 close = cc2.ClosestPoint(v);
                float dis = Vector2.Distance(v, close);
                if (dis < ep) {
                    Movement.is_Grounded = true;
                    Movement.num_Of_Jumps = 0;
                }
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            Vector2 v = contact.point;
            CircleCollider2D cc2 = gameObject.GetComponent<CircleCollider2D>();
            Vector2 close = cc2.ClosestPoint(v);
            float dis = Vector2.Distance(v, close);
            if (dis < ep)
            {
                Movement.is_Grounded = true;
                Movement.num_Of_Jumps = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy2")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            Movement.is_Grounded = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Movement.can = false;
        }
        if (col.gameObject.tag == "openDoor")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (col.gameObject.tag == "key")
        {
            GameManager.Instance.IsOpen = true;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "coin")
        {
            GameManager.Instance.Score++;
            Destroy(col.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            Movement.is_Grounded = false;
        }
    }
}
