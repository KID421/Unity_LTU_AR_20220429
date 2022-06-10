using UnityEngine;

public class ParticleSliderControl : MonoBehaviour
{
    [Header("光點粒子系統")]
    public ParticleSystem psLightPoint;

    // Single 在 C# 為 float

    public void ControlParticleEmission(float sliderValue)
    {
        print("滑桿的值：" + sliderValue);

        // emission 指定為 光點粒子的噴射
        var emission = psLightPoint.emission;
        // 控制光點的噴射 為 滑桿的值
        emission.rateOverTime = sliderValue;
    }
}
