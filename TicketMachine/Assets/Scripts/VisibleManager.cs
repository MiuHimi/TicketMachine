using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleManager : MonoBehaviour
{
    // StateFlowのスクリプト情報を格納
    private StateFlow stateFlowCs;
    // StateFlowがアタッチされているオブジェクト
    private GameObject attachStateFlowCsObj;

    //UI取得用
    [SerializeField]
    private Text[] guideText;
    [SerializeField]
    private Text[] deficitText;
    [SerializeField]
    private Text[] throwText;
    [SerializeField]
    private Text[] returnText;
    [SerializeField]
    private Text[] remainText;

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
        // ボタンが押されてから以降
        if (stateFlowCs.MachineState >= StateFlow.STATE.PUSH_BUY_BUTTON)
        {
            for(int i = 0; i < guideText.Length; i++)
            {
                guideText[i].enabled = true;
            }
        }
        // 金銭が投入されてから以降
        if (stateFlowCs.MachineState >= StateFlow.STATE.THROW_CASH)
        {
            for (int i = 0; i < deficitText.Length; i++)
            {
                deficitText[i].enabled = true;
            }
        }
        // 購入が完了してから以降
        if (stateFlowCs.MachineState >= StateFlow.STATE.GET_TICKET)
        {
            for (int i = 0; i < throwText.Length; i++)
            {
                throwText[i].enabled = true;
            }
            for (int i = 0; i < returnText.Length; i++)
            {
                returnText[i].enabled = true;
            }
            for (int i = 0; i < remainText.Length; i++)
            {
                remainText[i].enabled = true;
            }
        }

        if (stateFlowCs.MachineState != StateFlow.STATE.PUSH_BUY_BUTTON &&
            stateFlowCs.MachineState != StateFlow.STATE.THROW_CASH &&
            stateFlowCs.MachineState != StateFlow.STATE.GET_TICKET)
        {
            for (int i = 0; i < guideText.Length; i++)
            {
                guideText[i].enabled = false;
            }
            for (int i = 0; i < deficitText.Length; i++)
            {
                deficitText[i].enabled = false;
            }
            for (int i = 0; i < throwText.Length; i++)
            {
                throwText[i].enabled = false;
            }
            for (int i = 0; i < returnText.Length; i++)
            {
                returnText[i].enabled = false;
            }
            for (int i = 0; i < remainText.Length; i++)
            {
                remainText[i].enabled = false;
            }
        }
    }
}
