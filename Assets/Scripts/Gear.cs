using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] float stX = 0;
    [SerializeField] float stY = 0;
    Vector2 stPos;
    [SerializeField] float time_all = 2;
    [SerializeField] float forceX = 0;
    [SerializeField] float forceY = 0;
    [SerializeField] float resTime = 0;
    Vector2 force;
    float time_el = 0;
    float time_el2 = 0;
    bool no = false;
    void Start()
    {
        stPos = new Vector2(stX, stY);
        force = new Vector2(forceX, forceY);
        mystart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (no)
        {
            time_el2 += Time.deltaTime;
            if(time_el2 >= resTime)
            {
                no = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                time_el2 = 0;
                mystart();
            }
        }
        else
        {
            time_el += Time.deltaTime;
            if (time_el >= time_all)
            {
                time_el = 0;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.transform.position = stPos;
                no = true;
            }
        }
        
    }
    private void mystart()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
