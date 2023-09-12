using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen : MonoBehaviour
{
    public GameObject box;
    public ParticleSystem particles;
    public Light pointLight;
    public float lightMaxIntensity = 1.5f;
    public float animationTime = 3.0f;

    private float currentTime = 0.0f;
    private bool isBoxOpened = false;

    void Update()
    {
        if (!isBoxOpened)
        {
            // 상자를 열기 (임의의 애니메이션 코드)
            // ...

            // 파티클 효과 활성화
            particles.Play();

            // 빛의 강도를 점점 높힘
            while(currentTime < animationTime)
            {
                currentTime += Time.deltaTime;
                pointLight.intensity = Mathf.Lerp(0, lightMaxIntensity, currentTime / animationTime);
            }

            isBoxOpened = true;
        }
    }
}
