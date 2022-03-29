using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarMoveX : MonoBehaviour
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
            rb.MovePosition(new Vector2(touchPos.x - deltaX, gameObject.transform.position.y));
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
    //........................................................
    /*private Vector2 screenPoint;
    private Vector2 offset;
    bool check;
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        print(check);
        if (check!=true)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.y = gameObject.transform.position.y;
            gameObject.transform.position = point;
        }
    }

    void OnMouseUp()
    {
        check = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PillarY" || col.gameObject.tag == "Wall")
        {
            check = true;
            print("collide");
        }
    }*/



    //............................................................
    /*private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {

        // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,0, screenPoint.z);
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }*/
    /*void OnMouseDrag()
    {
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        if (MoveP != false)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, 0, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
        else
        {
            print("Don't Move");
        }

    }*/





    /*void OnMouseDown()
    {

        // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));
    }

    void OnMouseDrag()
    {
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        if(MoveP!=false)
       {
           Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, 0, 0);
           Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
           transform.position = curPosition;
       }
       else
       {
           print("Don't Move");
       }

    }

   void OnCollisionEnter2D(Collision2D col)
   {
       if (col.gameObject.tag == "PillarY")
       {
           MoveP = false;
           print(MoveP);
       }
       else
       {
           MoveP = true;
           print(MoveP);
       }
   }*/
    /* private float startPosX;
     private float startPosY;
     private bool isBeingHeld = false;

     void Update()
     {
         if(isBeingHeld==true)
         {
             Vector3 mousePos;
             mousePos = Input.mousePosition;
             mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            // this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
             this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, 0, 0);
         }


     }

     private void OnMouseDown()
     {
         if(Input.GetMouseButtonDown(0))
         {
             Vector3 mousePos;
             mousePos = Input.mousePosition;
             mousePos = Camera.main.ScreenToWorldPoint(mousePos);

             startPosX = mousePos.x - this.transform.localPosition.x;
             startPosY = mousePos.y - this.transform.localPosition.y;
             isBeingHeld = true;
         }
     }

     private void OnMouseUp()
     {
         isBeingHeld = false;
     }*/
}
