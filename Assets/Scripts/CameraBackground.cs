using UnityEngine;
using UnityEngine.UI;

public class CameraBackground : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    void Start()
    {
        // WebCamTexture 객체 생성
        webCamTexture = new WebCamTexture();
        
        // RawImage에 WebCamTexture 연결
        RawImage rawImage = GetComponent<RawImage>();
        rawImage.texture = webCamTexture;
        
        // WebCamTexture 시작
        webCamTexture.Play();
    }

    void Update()
    {
        // 여기에 필요한 로직을 추가할 수 있습니다.
    }
}
