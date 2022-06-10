using UnityEngine;
using SDev;             // 引用螢幕截圖命名空間

public class ScreenShootControl : MonoBehaviour
{
    [Header("攝影機")]
    public Camera cam;
    [Header("平面物件")]
    public MeshRenderer mrQuad;
    [Header("拍照後的資料夾名稱")]
    public string nameFolder;
    [Header("照片名稱")]
    public string namePicture;
    [Header("儲存位置")]
    public FileSaveUtil.AppPath appPath = FileSaveUtil.AppPath.PersistentDataPath;

    public void ScreenShot()
    {
        // 清除舊的拍照資料
        ScreenshotHelper.iClear();
        // 拍照
        ScreenshotHelper.iCaptureScreen((texture2D) => 
        {
            // 平面物件貼圖 指定為 拍照圖片
            mrQuad.material.mainTexture = texture2D;
            // 儲存拍照的圖片為 JPG(拍照圖片，儲存位置，資料夾，照片名稱)
            FileSaveUtil.Instance.SaveTextureAsJPG(texture2D, appPath, nameFolder, namePicture);
        });
    }
}
