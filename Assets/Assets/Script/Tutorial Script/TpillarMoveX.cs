using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TpillarMoveX : MonoBehaviour
{
    float deltaX, deltaY;


    // reference to Rigidbody2D component
    Rigidbody2D rb;
    Vector2 touchPos;
    Vector2 offset;


    public GameObject Xarraw;
    public static int Xx;
    // ball movement not allowed if you touches not the ball at the first time
    bool moveAllowed = false;


    // Use this for initialization
    void Start()
    {
        Xx = 2;
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
                        if (Xx == 1)
                        {
                            Xarraw.SetActive(false);
                        }
                    }
                    break;
            }
        }
    }
    void OnMouseDrag()
    {
        
        if (moveAllowed)
        {
            if(Xx==1)
            {
                rb.MovePosition(new Vector2(touchPos.x - deltaX, gameObject.transform.position.y));
            }
            
        }
    }

    void OnMouseUp()
    {
        if(Xx==1)
        {
            Xarraw.SetActive(true);
        }
        rb.bodyType = RigidbodyType2D.Kinematic;
        moveAllowed = false;
        rb.freezeRotation = true;
        rb.gravityScale = 0.0f;
        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        mat.bounciness = 0.0f;
        mat.friction = 0.0f;
        GetComponent<BoxCollider2D>().sharedMaterial = mat;
    }
}
