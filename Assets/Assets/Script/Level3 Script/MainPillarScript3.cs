using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPillarScript3 : MonoBehaviour
{
    // public GameObject GameOverpanel;
    float deltaX, deltaY;


    // reference to Rigidbody2D component
    Rigidbody2D rb;
    Vector2 touchPos;
    Vector2 offset;

    int x;
    int xxx;
    // ball movement not allowed if you touches not the ball at the first time
    bool moveAllowed = false;


    // Use this for initialization
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        // Add bouncy material tha ball
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        mat.bounciness = 0.0f;
        mat.friction = 0.0f;
        GetComponent<BoxCollider2D>().sharedMaterial = mat;


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {


            // get touch position
            Touch touch = Input.GetTouch(0);


            // obtain touch position
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);


            // get touch to take a deal with
            switch (touch.phase)
            {


                // if you touches the screen
                case TouchPhase.Began:


                    // if you touch the ball
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {


                        // get the offset between position you touches
                        // and the center of the game object
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;


                        // if touch begins within the ball collider
                        // then it is allowed to move
                        moveAllowed = true;
                        rb.bodyType = RigidbodyType2D.Dynamic;

                        // restrict some rigidbody properties so it moves
                        // more  smoothly and correctly
                        rb.freezeRotation = true;
                        rb.velocity = new Vector2(0, 0);
                        rb.gravityScale = 0;
                        GetComponent<BoxCollider2D>().sharedMaterial = null;
                    }
                    break;
            }
        }
    }
    void OnMouseDrag()
    {
        // print("mouse drag");
        //if (GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
        if (moveAllowed)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x, touchPos.y - deltaY));
        }
    }

    void OnMouseUp()
    {
        // print("mouse up");
        rb.bodyType = RigidbodyType2D.Kinematic;
        moveAllowed = false;
        rb.freezeRotation = true;
        rb.gravityScale = 0.0f;
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        mat.bounciness = 0.0f;
        mat.friction = 0.0f;
        GetComponent<BoxCollider2D>().sharedMaterial = mat;
    }
    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ExitBar")
        {
            //GameOverpanel.SetActive(true);
            print("Work It");
        }
    }*/
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ExitBar")
        {

            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                x = PlayerPrefs.GetInt("c");
                if (x == 0)
                {
                    xxx = PlayerPrefs.GetInt("RewardCollect");
                    PlayerPrefs.SetInt("RewardCollect", xxx + 1);

                    PlayerPrefs.SetInt("Level3_value", 1);
                    x = 2;
                    PlayerPrefs.SetInt("c", x);
                }
            }
            else
            {
                //print("Network not Available");
            }

        }
    }
}
