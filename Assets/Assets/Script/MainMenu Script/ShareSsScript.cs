using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ShareSsScript : MonoBehaviour
{
	public void ClickShareButton()
    {
		//TakeScreenshotAndShare();
		StartCoroutine(TakeScreenshotAndShare());
	}


	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("Drag Out").SetText("Congratulations! Within 24 hours you will get your reward.Please do visit our page for more information.").SetUrl("https://www.facebook.com/CTRL-Intelligence-Studio-107017208301607")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();
	}
}