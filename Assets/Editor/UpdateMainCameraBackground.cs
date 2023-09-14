using UnityEngine;
using UnityEditor;

public class UpdateMainCameraBackground
{
    [MenuItem("귀차니즘방지/Main Camera Background 변경! (현재 Scene)")]
    static void SetMainCameraToBlack()
    {
        // MainCamera를 찾아옵니다.
        Camera mainCamera = Camera.main;

        // MainCamera가 존재한다면 배경색을 검정색으로 변경합니다.
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = Color.black;
        }
        else
        {
            // MainCamera가 존재하지 않을 경우 경고 메시지를 출력합니다.
            Debug.LogWarning("MainCamera가 존재하지 않습니다.");
        }
    }
}
