using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputNNscript : MonoBehaviour
{
    public Text Name_Text;
    public InputField Name_Display;

    public Text Number_Text;
    public InputField Number_Display;
    // Start is called before the first frame update
    void Start()
    {
        Name_Text.text = PlayerPrefs.GetString("Input_Name1");
        Number_Text.text = PlayerPrefs.GetString("Input_Number1");
    }

    public void NameCreate()
    {
        Name_Text.text = Name_Display.text;
        PlayerPrefs.SetString("Input_Name1", Name_Display.text);
    }
    public void NumberCreate()
    {
        Number_Text.text = Number_Display.text;
        PlayerPrefs.SetString("Input_Number1", Number_Display.text);
    }
}
