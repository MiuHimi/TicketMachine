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

    // Start is called before the first frame update
    void Start()
    {
        // 不足分オブジェクト初期化
        difictObject = GameObject.Find("DeficitMoneyText");
        dificitMoney = 0;
        difictText = difictObject.GetComponent<Text>();

        // お釣り初期化
        returnMoney = 0;

        // 購入済みかどうかフラグを初期化
        isFinishBuy = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 不足分テキスト
        difictText.text = dificitMoney.ToString();
    }

    // 不足残金から投入された金額を引く
    // お釣りが出る場合、金額を保持
    public void ThrowMoney(int throwMoney)
    {
        // 不足金額から投入金額を引く
        dificitMoney -= throwMoney;

        // 不足金額が0以下
        // (必要な分だけ投入されたら)
        if (dificitMoney <= 0)
        {
            // 正の値にしてお釣り保存
            returnMoney = dificitMoney * -1;
            // 不足分は0円にしておく
            dificitMoney = 0;
            // 購入完了
            isFinishBuy = true;

            // 「購入完了」に変更
            StateFlow.MachineState = StateFlow.STATE.GET_TICKET;
        }
    }

    /// <summary>
    /// 支払い残金取得・設定関数
    /// </summary>
    public int DificitMoney { get { return dificitMoney; } set { dificitMoney = value; } }

    /// <summary>
    /// お釣り取得・設定関数
    /// </summary>
    public int ReturnMoney { get { return returnMoney; } set { returnMoney = value; } }

    /// <summary>
    /// 切符購入状態取得・設定関数
    /// </summary>
    public bool IsFinishBuy { get { return isFinishBuy; } set { isFinishBuy = value; } }
}
