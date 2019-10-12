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
    private Text guideText;
    [SerializeField]
    private Text deficitText;
    [SerializeField]
    private Text deficitMoneyText;
    //[SerializeField]
    //Text text;

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
        if (stateFlowCs.MachineState >= StateFlow.STATE.PUSH_BUY_BUTTON)
        {
            guideText.enabled = true;
            deficitText.enabled = true;
            deficitMoneyText.enabled = true;
        }
        else
        {
            guideText.enabled = false;
            deficitText.enabled = false;
            deficitMoneyText.enabled = false;
        }
    }
}
