using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMoveY : MonoBehaviour
{
    float deltaX, deltaY;


    // reference to Rigidbody2D component
    Rigidbody2D rb;
    Vector2 touchPos;
    Vector2 offset;

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
    //...........................................
    /*private Vector2 screenPoint;
    private Vector2 offset;
    public bool check;

    Vector2 touchPos;
    public Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //touchPos = Camera.main.WorldToScreenPoint(Input.mousePosition);
       // rb.position = touchPos;
    }
   
    void OnMouseDrag()
    {
        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPos.x = gameObject.transform.position.x;
        rb.position = touchPos;
    }

   /* void OnMouseUp()
    {
        check = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PillarX" || col.gameObject.tag == "Wall")
        {
            check = true;
        }
    }

    //....................................................................
    /* private Vector3 screenPoint;
     private Vector3 offset;

     void OnMouseDown()
     {

         // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
         offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y,0));
     }

     void OnMouseDrag()
     {
         Vector3 curScreenPoint = new Vector3(0, Input.mousePosition.y,0);
         //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
         Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
         transform.position = curPosition;
     }*/
    /*private Vector2 screenPoint;
    private Vector2 offset;

    void OnMouseDown()
    {

        // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(0, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        Vector2 curScreenPoint = new Vector2(0, Input.mousePosition.y);
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }*/
}
