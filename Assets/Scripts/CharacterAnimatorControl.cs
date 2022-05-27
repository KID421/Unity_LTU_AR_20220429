using UnityEngine;

public class CharacterAnimatorControl : MonoBehaviour
{
    // 控制元件的方式
    // 1. 將元件定義為欄位 field
    // 2. 透過 Unity API 成員存取

    public Animator aniMing;

    // UI 按鈕 Button 點擊後執行 C# 內容的設定流程
    // 1. 設定一個公開的方法 public method
    // 2. C# 腳本必須放在實體物件上變成元件 Component
    // 3. 按鈕 Button 的 On Click 指定該物件與公開的方法

    public void SetCharacterWalk()
    {
        print("小明走路");

        aniMing.SetBool("開關走路", true);
    }

    public void SetCharacterWave()
    {
        print("小明招手");

        aniMing.SetBool("開關走路", false);
    }
}
