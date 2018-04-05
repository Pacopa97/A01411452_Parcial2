using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected Animator anim;
    protected Rigidbody2D rigid;

    
    public float speed;
    public int direction=1;

    private bool dead = false;
    private bool standing;
    private bool crouched=false;
    private int hit = 1;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true && Input.GetKeyDown(KeyCode.DownArrow) == true))
        {
           
            anim.SetBool("isCrouching", true);
        }

       
        if (dead == false)
        {
            if (standing == true && crouched == false)
            {
                


                if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    direction = -1;
                    Flip();
                    anim.SetBool("isRunning", true);
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        //soundManager.PlaySong(0);
                        
                        //anim.SetBool("isRunning", false);
                        rigid.AddForce(new Vector2(-3, 10f), ForceMode2D.Impulse); 
                    }
                }
                
                else
                if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    direction = 1;
                    Flip();
                    anim.SetBool("isRunning", true);
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        //soundManager.PlaySong(0);

                        //anim.SetBool("isRunning", false);
                        rigid.AddForce(new Vector2(3, 10f), ForceMode2D.Impulse);
                    }
                }
               


                if ((Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    
                    anim.SetBool("isRunning", false);
                    if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                    {
                        //soundManager.PlaySong(0);
                        rigid.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
                    }
                }

                if ((Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true && Input.GetKeyDown(KeyCode.DownArrow) == true))
                {
                   
                    anim.SetBool("isCrouching", true);
                }



                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    
                    anim.SetBool("isCrouching", false);
                   
                    anim.SetBool("isRunning", false);
                    
                    anim.SetBool("isRunning", false);
                    

                }


            }
            if (Input.GetKey(KeyCode.DownArrow) && standing == true)
            {
                
                anim.SetBool("isCrouching", true);
                crouched = true;
            }
            else
            {
                
                anim.SetBool("isCrouching", false);
                crouched = false;

            }



        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Floor")
        {
            standing = true;
            anim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            standing = false;
            anim.SetBool("isJumping",true);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            hit = 1;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (hit == 1)
            {
                hit--;

                rigid.AddForce(new Vector2(2 * direction, 2f), ForceMode2D.Impulse);
                GameObject.Find("Stats").GetComponent<Stats>().lives--;

                if (GameObject.Find("Stats").GetComponent<Stats>().lives <= 0)
                {
                    GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Defeat");
                }

            }
        }

    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = direction;
        transform.localScale = theScale;
    }
}
