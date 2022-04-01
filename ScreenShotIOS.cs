using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenShotIOS : MonoBehaviour
{
    Texture2D mTexture;
    RenderTexture mRender;

    public Camera myCamera;

    [DllImport("__Internal")]
    private static extern void _TakeAPictureBtn(string path);

    public static void SentPicturePathToiOS(string path)
    {
        if (Application.platform != RuntimePlatform.OSXEditor)
        {
            _TakeAPictureBtn(path);
        }
    }

    public void TakeAPictureBtnClick()
    {
        string timeStamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string path = Application.persistentDataPath;
        string fileName = "ScreenShot" + timeStamp;

        StartCoroutine(CaptureByCamera(myCamera, new Rect(0, 0, Screen.width, Screen.height), fileName));
        ScreenShotIOS.SentPicturePathToiOS(fileName);
    }


    private IEnumerator CaptureByCamera(Camera mCamera, Rect mRect, string mFileName)
    {
        //wait render
        yield return new WaitForEndOfFrame();
        mRender = new RenderTexture(Screen.width, Screen.height, 16);
        mCamera.targetTexture = mRender;
        mCamera.Render();
        RenderTexture.active = mRender;
        mTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        mTexture.ReadPixels(mRect, 0, 0);
        mTexture.Apply();        
        mCamera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(mRender);
        //saving
        byte[] bytes = mTexture.EncodeToPNG();
        ScreenshotManager.SaveImage(mTexture, mFileName, "jpg");
        System.IO.File.WriteAllBytes(mFileName, bytes);
        yield return new WaitForSeconds(2);
    }
}
