using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIImageUpdater : Editor
{
    [MenuItem("귀차니즘방지/Logo 일괄 변경! (근데 안먹힘 ㅎ..)")]
    public static void UpdateAllLogos()
    {
        // 현재 열린 씬 저장하기
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

        // 프로젝트 내의 모든 씬 경로 가져오기
        string[] scenePaths = AssetDatabase.FindAssets("t:Scene");
        for (int i = 0; i < scenePaths.Length; i++)
        {
            scenePaths[i] = AssetDatabase.GUIDToAssetPath(scenePaths[i]);
        }

        // 각 씬에 대해 순회하면서 로고 업데이트
        foreach (var scenePath in scenePaths)
        {
            EditorSceneManager.OpenScene(scenePath);
            UpdateLogosInHierarchy();
            
            // 변경 사항 저장하기
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }

    static void UpdateLogosInHierarchy()
    {
        // 모든 게임 오브젝트를 가져온다
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

        // 각 게임 오브젝트에 대해 로고 태그가 있는지 확인한다
        foreach (GameObject go in allGameObjects)
        {
            if (go.CompareTag("logo"))
            {
                // Image 컴포넌트 가져오기
                Image imageComponent = go.GetComponent<Image>();

                // 새로운 로고 이미지 로드하기
                Sprite newLogo = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Images/Logo_Lotte.png");

                // 설정 변경하기
                if (imageComponent != null && newLogo != null)
                {
                    imageComponent.sprite = newLogo;
                    go.transform.localPosition = new Vector3(go.transform.localPosition.x, -910, go.transform.localPosition.z);
                    imageComponent.rectTransform.sizeDelta = new Vector2(310, 100);
                }
            }
        }
    }
}
