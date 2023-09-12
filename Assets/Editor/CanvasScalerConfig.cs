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
        
        if (scaler != null)
        {
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1080, 1920);
        }
    }
}
#endif
