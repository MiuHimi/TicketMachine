using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonAction : MonoBehaviour
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

    }

    /// <summary>
    /// ボタンが押された
    /// </summary>
    public void OnClick()
    {
        // 券売機の状態を「購入ボタンが押された」にする
        stateFlowCs.MachineState = StateFlow.STATE.PUSH_BUY_BUTTON;

        // 非表示にする
        this.gameObject.SetActive(false);
    }
}
