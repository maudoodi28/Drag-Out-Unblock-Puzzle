using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TexitBar : MonoBehaviour
{
    public GameObject LevelCompletepanel;
    public GameObject menuPanel;
    public GameObject LevelNamePanel;

    public GameObject Marraw;
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
        if (collider.gameObject.tag == "MainPillar")
        {
            LevelCompletepanel.SetActive(true);
            menuPanel.SetActive(false);
            LevelNamePanel.SetActive(false);
            Marraw.SetActive(false);
            TextraPillar.Mm = 2;
        }
    }
}
