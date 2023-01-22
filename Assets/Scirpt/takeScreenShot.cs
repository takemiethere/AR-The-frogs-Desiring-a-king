using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class takeScreenShot : MonoBehaviour
{
    [SerializeField] GameObject objGroupImageButton;

	public void screenshotToDevice()
	{
		hideUI();
		StartCoroutine(TakeScreenshotAndSave());
	}

	public void screenshotToShare()
	{
		hideUI();
		StartCoroutine(TakeScreenshotAndShare());
	}

	private IEnumerator TakeScreenshotAndSave()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		// Save the screenshot to Gallery/Photos
		NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ss, "GalleryTest", "Image.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

		Debug.Log("Permission result: " + permission);

		// To avoid memory leaks
		Destroy(ss);

		foreach (Transform child in objGroupImageButton.transform)
		{
			child.gameObject.SetActive(true);
		}
		
		showUI();
	}
	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		foreach (Transform child in objGroupImageButton.transform)
		{
			child.gameObject.SetActive(false);
		}

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("subject").SetText("enjoy").SetUrl("https://google.com") //�͹�����
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

		showUI();

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
	}

	void hideUI()
    {
		foreach (Transform child in objGroupImageButton.transform)
		{
			child.gameObject.SetActive(false);
		}
	}

	void showUI()
    {
		foreach (Transform child in objGroupImageButton.transform)
		{
			child.gameObject.SetActive(true);
		}
	}
}