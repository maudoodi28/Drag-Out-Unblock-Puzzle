using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManagerScript12 : MonoBehaviour
{
    public GameObject homeButtonPanel;
    public GameObject menuPanel;
    public GameObject LevelNamePanel;
    int xxx;
    // Start is called before the first frame update
    void Start()
    {
        int x;
        AdmobAds.instance.reqBannerAd();
        AdmobAds.instance.requestInterstital();
        AdmobAds.instance.loadRewardVideo();
        /*if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            x = PlayerPrefs.GetInt("l");
            if (x == 0)
            {
                xxx = PlayerPrefs.GetInt("RewardCollect");
                PlayerPrefs.SetInt("RewardCollect", xxx + 1);

                PlayerPrefs.SetInt("Level12_value", 1);
                x = 2;
                PlayerPrefs.SetInt("l", x);
            }
        }
        else
        {
            //print("Network not Available");
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackToMenuButton()
    {
        CompanyLogoScript.OffLogo = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level13");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level12");
        AdmobAds.instance.ShowInterstitialAd();
    }


    public void HomeButton()
    {
        homeButtonPanel.SetActive(true);
        menuPanel.SetActive(false);
        LevelNamePanel.SetActive(false);
    }
    public void YesButton()
    {
        CompanyLogoScript.OffLogo = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void NoButton()
    {
        homeButtonPanel.SetActive(false);
        menuPanel.SetActive(true);
        LevelNamePanel.SetActive(true);
    }
}
