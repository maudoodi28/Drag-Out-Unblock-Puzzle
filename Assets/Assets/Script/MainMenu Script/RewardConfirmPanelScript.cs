using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardConfirmPanelScript : MonoBehaviour
{
    public GameObject GameNameText;
    public GameObject UpperText;
    public GameObject SharePanel;
    public GameObject RewardPanel;
    public GameObject CollectRewardPanel;
    public GameObject ConfirmationPanel;
    public GameObject MenuPanel;
    public GameObject BackConfirmationPanel;

    public GameObject collectRewardButton;
    bool ss = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UnderstandButton()
    {
        UpperText.SetActive(true);
        SharePanel.SetActive(true);
        ConfirmationPanel.SetActive(false);
    }
    public void DeclineButton()
    {
        CollectRewardPanel.SetActive(false);
    }
    public void NoButton()
    {
        BackConfirmationPanel.SetActive(false);
        UpperText.SetActive(true);
        SharePanel.SetActive(true);
    }
    public void BackToMenuButton()
    {
        BackConfirmationPanel.SetActive(true);
        UpperText.SetActive(false);
        SharePanel.SetActive(false);
    }
    public void YesButton()
    {
        collectRewardButton.GetComponent<Button>().interactable = ss;
        GameNameText.SetActive(true);
        MenuPanel.SetActive(true);
        RewardPanel.SetActive(false);
        CollectRewardPanel.SetActive(false);
        BackConfirmationPanel.SetActive(false);
    }
}
