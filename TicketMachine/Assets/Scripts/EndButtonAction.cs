using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonAction : MonoBehaviour
{
    // StateFlowのスクリプト情報を格納
    private StateFlow stateFlowCs;

    // Start is called before the first frame update
    void Start()
    {
        // 対象オブジェクトを格納
        GameObject attachStateFlowCsObj = GameObject.Find("TicketMachineDirector");
        // StateFlowのスクリプト情報を取得
        stateFlowCs = attachStateFlowCsObj.GetComponent<StateFlow>();
    }

    // Update is called once per frame
    void Update()
    {
        // 購入が完了していなかったら
        if (stateFlowCs.MachineState != StateFlow.STATE.GET_TICKET)
        {
            // 非表示にする
            this.gameObject.SetActive(false);
        }
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
