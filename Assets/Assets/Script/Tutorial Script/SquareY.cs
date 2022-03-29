using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareY : MonoBehaviour
{
    public GameObject Xarrow;
    public GameObject Yarrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "PillarY")
        {
            TpillarMoveX.Xx = 1;
            print(TpillarMoveX.Xx);
            TpillarMoveY.Yy = 2;
            print(TpillarMoveY.Yy);
            Xarrow.SetActive(true);
            Yarrow.SetActive(false);
        }
    }
}
