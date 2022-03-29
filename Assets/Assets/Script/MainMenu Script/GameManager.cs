using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject RewardPanel;
    public GameObject CollectRewardPanel;
    int Tutorial;
    public GameObject collectRewardButton;
    public GameObject SharePanelcollectReward;
    public GameObject TextcollectReward;
    public GameObject ConfirmationCollectReward;
    public GameObject BackConfirmationCollectReward;
    int xx = 1;
    bool yy = true;
    int Reward;
    int RewardX;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial = PlayerPrefs.GetInt("TutorialScene");
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    public void PlayButton()
    {
        if (Tutorial == 0)
        {
            PlayerPrefs.SetInt("TutorialScene", 1);
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            SceneManager.LoadScene("LevelScene");
        }

    }
    public void LevelListButton()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void RewardButton()
    {
        Reward = PlayerPrefs.GetInt("RewardCollect");
        RewardX = PlayerPrefs.GetInt("RewardXXX");
        print("Reward = " + Reward);
        
        print("RewardXX = " + RewardX);
        if (Reward==50 && RewardX<2)
        {
            collectRewardButton.GetComponent<Button>().interactable = yy;
            PlayerPrefs.SetInt("RewardXXX",10);
        }
        
        RewardPanel.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void RewardToMenuBackButton()
    {
        RewardPanel.SetActive(false);
    }
    public void CollectRewardButton()
    {
        CollectRewardPanel.SetActive(true);
        SharePanelcollectReward.SetActive(false);
        TextcollectReward.SetActive(false);
        ConfirmationCollectReward.SetActive(true);
    }
}
