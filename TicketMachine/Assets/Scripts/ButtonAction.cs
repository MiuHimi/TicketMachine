using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    // StateFlowのスクリプト情報を格納
    private StateFlow stateFlowCs;
    // StateFlowがアタッチされているオブジェクト
    private GameObject attachStateFlowCsObj;

    // Start is called before the first frame update
    void Start()
    {
        // 対象オブジェクトを格納
        attachStateFlowCsObj = GameObject.Find("TicketMachineDirector");
        // StateFlowのスクリプト情報を取得
        stateFlowCs = attachStateFlowCsObj.GetComponent<StateFlow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ボタンが押された
    public void OnClick()
    {
        // 券売機の状態を「ボタンが押された」にする
        stateFlowCs.MachineState = StateFlow.STATE.PUSH_BUY_BUTTON;
        Debug.Log(stateFlowCs.MachineState);

        // 非表示にする
        this.gameObject.SetActive(false);
    }
}
