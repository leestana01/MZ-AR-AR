#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

[InitializeOnLoad]
public class CanvasScalerConfig
{
    static CanvasScalerConfig()
    {
        EditorSceneManager.sceneOpened += SceneOpenedCallback;
    }

    private static void SceneOpenedCallback(UnityEngine.SceneManagement.Scene scene, OpenSceneMode mode)
    {
        CanvasScaler scaler = GameObject.FindObjectOfType<CanvasScaler>();
        GameObject canvasGameObject = scaler.gameObject;
        
        if (scaler != null)
        {
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1080, 1920);
            scaler.matchWidthOrHeight = 0.0f;  // Width에 완전히 맞춤
        }

        // 검은색 패널 생성 및 설정
        GameObject blackBarPanel = new GameObject("BlackBarPanel");
        blackBarPanel.transform.SetParent(canvasGameObject.transform, false);
        RectTransform rectTransform = blackBarPanel.AddComponent<RectTransform>();
        
        // 앵커와 오프셋 설정으로 패널을 화면 전체로 확장
        rectTransform.anchorMin = new Vector2(-0.5f, -0.5f);
        rectTransform.anchorMax = new Vector2(1.5f, 1.5f);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        Image image = blackBarPanel.AddComponent<Image>();
        image.color = Color.black;

        // 검은색 패널을 맨 뒤로 보냄
        blackBarPanel.transform.SetAsFirstSibling();
    }
}
#endif
