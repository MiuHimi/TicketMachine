using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeVisible : MonoBehaviour
{
    // StateFlowのスクリプト情報を格納
    private StateFlow stateFlowCs;
    // StateFlowがアタッチされているオブジェクト
    private GameObject attachStateFlowCsObj;

    // 表示できる状態
    public StateFlow.STATE visibleState;

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
        // 表示できる状態が現在の状態よりも小さかったら表示しない
        // 例：(現在)STATE.DEFAULT(0) < (表示できる状態)STATE.PUSH_BUY_BUTTON(1)
        if (stateFlowCs.machineState < visibleState)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        
    }
}
