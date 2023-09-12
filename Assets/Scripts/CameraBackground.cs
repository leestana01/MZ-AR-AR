using UnityEngine;
using UnityEngine.UI;

public class CameraBackground : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    public Image boxImage;  // 상자 이미지를 나타내는 Image
    public RawImage background;
    public float sensitivity = 1.0f;  // 상자가 움직이는 민감도를 높임

    private Vector2 initialBoxPosition;

    void Start()
    {
        // 자이로스코프 활성화
        Input.gyro.enabled = true;

        // WebCamTexture 객체 생성
        webCamTexture = new WebCamTexture();

        // RawImage에 WebCamTexture 연결
        background.texture = webCamTexture;

        // WebCamTexture 회전 조절
        background.rectTransform.localEulerAngles = new Vector3(0, 0, -90);

        // WebCamTexture 시작
        webCamTexture.Play();

        // 초기 상자의 위치 저장
        initialBoxPosition = boxImage.rectTransform.anchoredPosition;
    }

    void Update()
    {
        // 자이로스코프의 회전값 가져오기
        Quaternion gyroRotation = Input.gyro.attitude;
        gyroRotation = Quaternion.Euler(90f, 0f, 0f) * new Quaternion(gyroRotation.x, gyroRotation.y, -gyroRotation.z, -gyroRotation.w);

        // 상자의 새로운 위치 설정 (x축 반전)
        Vector2 newBoxPosition = initialBoxPosition + new Vector2(gyroRotation.y, -gyroRotation.x) * sensitivity * 100;  // x 축 반전
        boxImage.rectTransform.anchoredPosition = newBoxPosition;
    }
}