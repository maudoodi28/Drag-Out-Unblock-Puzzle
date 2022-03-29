using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutorialUI : MonoBehaviour
{
    int x;
    public GameObject menuPanel;
    public GameObject LevelNamePanel;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackToMenuButton()
    {
        //SceneManager.LoadScene("MainMenu");
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void RestartButton()
    {
        
    }

    public void HomeButton()
    {
        //homeButtonPanel.SetActive(true);
       // menuPanel.SetActive(false);
        //LevelNamePanel.SetActive(false);
    }
    public void YesButton()
    {
       // SceneManager.LoadScene("MainMenu");
    }
    public void NoButton()
    {
        //homeButtonPanel.SetActive(false);
        //menuPanel.SetActive(true);
        //LevelNamePanel.SetActive(true);
    }
    public void SkipButton()
    {
         SceneManager.LoadScene("Level1");
    }
}
