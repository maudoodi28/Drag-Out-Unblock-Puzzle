using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManagerScript23 : MonoBehaviour
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
            x = PlayerPrefs.GetInt("w");
            if (x == 0)
            {
                xxx = PlayerPrefs.GetInt("RewardCollect");
                PlayerPrefs.SetInt("RewardCollect", xxx + 1);

                PlayerPrefs.SetInt("Level23_value", 1);
                x = 2;
                PlayerPrefs.SetInt("w", x);
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
        SceneManager.LoadScene("Level24");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level23");
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
