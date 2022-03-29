using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SquareX : MonoBehaviour
{

    public GameObject Marrow;
    public GameObject Xarrow;
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
        if (collider.gameObject.tag == "PillarX")
        {
            TpillarMoveX.Xx = 2;
            TextraPillar.Mm = 1;
            Marrow.SetActive(true);
            Xarrow.SetActive(false);
        }
    }
}
