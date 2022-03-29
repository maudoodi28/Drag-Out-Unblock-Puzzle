using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ShareButtonScript : MonoBehaviour
{
    public Button shareButton;
    private bool isFocus = false;
    private bool isProcessing = false;

    // Start is called before the first frame update
    void Start()
    {
        shareButton.onClick.AddListener(ShareText);
    }
    public void Share()
    {
        ShareText();
    }
    void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }
    // Update is called once per frame

    private void ShareText()
    {
        print("share");
#if UNITY_ANDROID
        if(!isProcessing)  
        {
            StartCoroutine(ShareTextInAndroid());
        }
#else
        Debug.Log("No sharing set up for this platform.");
#endif
    }
#if UNITY_ANDROID
    public IEnumerator ShareTextInAndroid()
    {
    var shareSubject = "The Best Game I seen\n"; 
    var shareMessage = "JUST PLAY IT\n\n" + 
                       "https://play.google.com/store/apps/details?id=com.CIS.DragOut.CTRLIntelligenceStudio";
                       
     isProcessing = true;
     if(!Application.isEditor)
     {
     print("share_1");
     AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
     AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
     intentObject.Call<AndroidJavaObject>
           ("setAction",intentClass.GetStatic<string>("ACTION_SEND"));
     intentObject.Call<AndroidJavaObject>("setType","text/plain");
     intentObject.Call<AndroidJavaObject>
           ("putExtra",intentClass.GetStatic<string>("EXTRA_SUBJECT"),shareSubject);
     intentObject.Call<AndroidJavaObject>
           ("putExtra",intentClass.GetStatic<string>("EXTRA_TEXT"),shareMessage);
     AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
     AndroidJavaObject currentActivity = 
           unity.GetStatic<AndroidJavaObject>("currentActivity");
     AndroidJavaObject chooser = 
         intentClass.CallStatic<AndroidJavaObject>
         ("createChooser",intentObject,"Share your high score");
     currentActivity.Call("startActivity",chooser);
     }
     yield return new WaitUntil(()=> isFocus);
     isProcessing = false;
   }
#endif
}
