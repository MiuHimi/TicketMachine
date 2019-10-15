using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 表示/非表示切り替え
    /// </summary>
    /// <param name="flag">切り替えフラグ</param>
    public void SetActive(bool flag)
    {
        this.gameObject.SetActive(flag);
    }

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
