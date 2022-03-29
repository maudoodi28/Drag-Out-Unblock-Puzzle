using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExitBar : MonoBehaviour
{
    public GameObject level_complete;

    public int unlock;
    public GameObject LevelCompletepanel;
    public GameObject menuPanel;
    public GameObject LevelNamePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        /*if(LevelComplete==null)
        {
            LevelComplete = this;
        }*/
        AdmobAds.instance.requestInterstital();
        AdmobAds.instance.loadRewardVideo();
        Time.timeScale = 1;

        unlock = SceneManager.GetActiveScene().buildIndex + 1;

        level_complete.SetActive(false);
        AdmobAds.instance.requestInterstital();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "MainPillar")
        {
            
            print("complete");
            PlayerPrefs.SetInt("levelReached", unlock);
            level_complete.SetActive(true);
            AdmobAds.instance.ShowInterstitialAd();
            LevelCompletepanel.SetActive(true);
            menuPanel.SetActive(false);
            LevelNamePanel.SetActive(false);
            
        }
    }
}
