using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonAction : MonoBehaviour
{
    /// <summary>
    /// ボタンが押された
    /// </summary>
    public void OnClick()
    {
        // 終了する
        Quit();
    }

    /// <summary>
    /// 終了
    /// </summary>
    void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }
}
