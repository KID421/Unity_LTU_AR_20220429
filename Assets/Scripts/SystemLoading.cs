using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      // 引用 場景管理
using System.Collections;               // 引用 系統集合 (資料結構與協同程序)

/// <summary>
/// 載入系統
/// 1. 指定按鈕按下後開始載入場景
/// 2. 顯示載入畫面，包含文字與圖片
/// </summary>
public class SystemLoading : MonoBehaviour
{
    #region 資料
    [Header("要載入的場景名稱")]
    public string nameScene;
    [Header("載入場景按鈕")]
    public Button btnLoading;
    [Header("文字載入進度")]
    public Text textLoading;
    [Header("圖片載入進度")]
    public Image imgLoading;
    [Header("載入畫面")]
    public CanvasGroup groupLoading;
    #endregion

    [Header("文字提示按任意鍵")]
    public GameObject goTip;

    private void Awake()
    {
        // 載入按鈕 按下事件 添加監聽器(載入)
        btnLoading.onClick.AddListener(() => { StartCoroutine(Loading()); });
    }

    // 協同程序
    // 1. 引用 System.Collections
    // 2. 傳回類型 IEnumerator
    // 3. 使用 StartCoroutine 啟動

    /// <summary>
    /// 載入
    /// </summary>
    private IEnumerator Loading()
    {
        btnLoading.interactable = false;    // 取消 按鈕 互動
        print("載入中...");

        for (int i = 0; i < 5; i++)
        {
            groupLoading.alpha += 0.2f;
            yield return new WaitForSeconds(0.02f);
        }

        // 載入資訊 = 非同步載入(場景名稱)
        AsyncOperation ao = SceneManager.LoadSceneAsync(nameScene);
        // 不允許場景啟動
        ao.allowSceneActivation = false;

        // 當 場景尚未載入成功
        while (!ao.isDone)
        {
            // 圖片 填滿數值 更新
            imgLoading.fillAmount = ao.progress / 0.9f;
            // 文字 更新
            textLoading.text = "Loading " + (ao.progress / 0.9f) * 100 + " %";
            // 等待 null 一個影格的時間
            yield return null;

            // 如果 進度 >= 0.9f
            if (ao.progress >= 0.9f)
            {
                goTip.SetActive(true);

                // 如果按下任意鍵
                if (Input.anyKey)
                {
                    // 允許載入場景
                    ao.allowSceneActivation = true;
                }
            }
        }
    }
}
