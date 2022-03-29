//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
public class PlayStoreButtonScript : MonoBehaviour
{
    public string url;

    public void Open()
    {
        Application.OpenURL(url);
    }
    /*public Button shareButton;
    private bool isFocus = false;
    private bool isProcessing = false;

    // Start is called before the first frame update
    void Start()
    {
        shareButton.onClick.AddListener(ShareText);
    }
    void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }
    // Update is called once per frame

    private void ShareText()
    {
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
    var shareSubject = "Our Game List\n"; 
    var shareMessage = "You Can Find Our All Game\n\n" + 
                       "https://play.google.com/store/apps/dev?id=7333603167610011478";
     isProcessing = true;
     if(!Application.isEditor)
     {
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
#endif*/
}
