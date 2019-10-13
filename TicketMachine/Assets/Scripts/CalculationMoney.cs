using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationMoney : MonoBehaviour
{
    // 不足分テキスト
    private GameObject difictObject;
    // 不足分(int)
    private int dificitMoney;
    // 不足分(Text)
    private Text difictText;

    // お釣り
    private int returnMoney;

    // チケットを購入したかどうか
    private bool isFinishBuy;

    // ClickMoneyのスクリプト情報を格納
    private ClickMoney clickMoneyCs;
    // ClickMoneyがアタッチされているオブジェクト
    private GameObject attachClickMoneyCsObj;

    // Start is called before the first frame update
    void Start()
    {
        difictObject = GameObject.Find("DeficitMoneyText");
        dificitMoney = 0;
        difictText = difictObject.GetComponent<Text>();

        returnMoney = 0;

        isFinishBuy = false;

        // 対象オブジェクトを格納
        attachClickMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // StateFlowのスクリプト情報を取得
        clickMoneyCs = attachClickMoneyCsObj.GetComponent<ClickMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        difictText.text = dificitMoney.ToString();
    }

    // 不足残金から投入された金額を引く
    // お釣りが出る場合、金額を保持
    public void ThrowMoney(int throwMoney)
    {
        dificitMoney -= throwMoney;
        if (dificitMoney < 0)
        {
            // 正の値にして保存
            returnMoney = dificitMoney * -1;
            dificitMoney = 0;
        }
    }

    /// <summary>
    /// 支払い残金取得・設定関数
    /// </summary>
    public int DificitMoney { get { return dificitMoney; } set { dificitMoney = value; } }
}
