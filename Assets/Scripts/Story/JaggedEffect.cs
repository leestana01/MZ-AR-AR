using UnityEngine;
using UnityEngine.UI;

public class JaggedEffect : MonoBehaviour
{
    public Image image1; // 자글자글 효과를 적용할 이미지

    public float maxRotation = 5.0f; // 최대 회전 각도
    public float rotateSpeed = 50.0f; // 회전 속도

    private float currentRotation = 0.0f; // 현재 회전 각도
    private bool isRotatingPositive = true; // 회전 방향 플래그

    void Update()
    {
        // 회전 각도를 계산
        float deltaRotation = rotateSpeed * Time.deltaTime;

        if (!isRotatingPositive)
        {
            deltaRotation = -deltaRotation;
        }

        // 현재 회전 각도를 업데이트
        currentRotation += deltaRotation;

        // 회전 방향을 결정
        if (Mathf.Abs(currentRotation) >= maxRotation)
        {
            isRotatingPositive = !isRotatingPositive;
        }

        // 실제 회전 적용
        image1.transform.localRotation = Quaternion.Euler(0, 0, currentRotation);
    }
}
