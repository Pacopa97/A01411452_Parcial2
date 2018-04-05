using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator animator;

    public bool movingLeft = true;
    private Vector3 walk;
    public float speed = 2;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (movingLeft) MoveLeft(); else MoveRight();
    }

    void MoveRight()
    {
        movingLeft = false;
        walk.x = 1;
        Flip();
        transform.position += walk * speed * Time.deltaTime;

    }

    void MoveLeft()
    {
        {
            movingLeft = true;
            walk.x = -1;
            Flip();
            transform.position += walk * speed * Time.deltaTime;

        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -walk.x;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            if (movingLeft == false)
                movingLeft = true;
            else movingLeft = false;
        }

    }
}
