using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UpdateMainCameraBackgrounds : Editor
{
    [MenuItem("귀차니즘방지/MainCamera Backgrounds 일괄 변경!")]
    public static void UpdateCameraBackground()
    {
        // 현재 열린 씬 저장하기
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

        // 프로젝트 내의 모든 씬 경로 가져오기
        string[] scenePaths = AssetDatabase.FindAssets("t:Scene");
        for (int i = 0; i < scenePaths.Length; i++)
        {
            scenePaths[i] = AssetDatabase.GUIDToAssetPath(scenePaths[i]);
        }

        // 각 씬에 대해 순회하면서 카메라의 BackGround 색상 업데이트
        foreach (var scenePath in scenePaths)
        {
            EditorSceneManager.OpenScene(scenePath);

            // MainCamera를 찾는다
            GameObject mainCameraObj = GameObject.FindWithTag("MainCamera");

            if (mainCameraObj != null)
            {
                // Camera 컴포넌트를 가져온다
                Camera mainCamera = mainCameraObj.GetComponent<Camera>();

                if (mainCamera != null)
                {
                    // 색상을 3A3A3A로 설정한다
                    // 16진수를 0~1 사이의 값으로 변환한다 (58/255 = 0.227)
                    mainCamera.backgroundColor = new Color(0.227f, 0.227f, 0.227f, 1f);
                }
            }

            // 변경 사항 저장하기
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }
}
