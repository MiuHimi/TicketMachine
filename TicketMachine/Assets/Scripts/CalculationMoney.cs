using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationMoney : MonoBehaviour
{
    // 不足分金額
    private int dificitMoney;
    // 不足分テキスト
    private Text difictText;

    // お釣り
    private int returnMoney;

    // チケットを購入したかどうか
    private bool isFinishBuy;

    // ClickMoneyのスクリプト情報を格納
    private ClickMoney clickMoneyCs;

    // ManagementMoneyのスクリプト情報を格納
    private ManagementMoney managementMoneyCs;

    // ResultMoneyのスクリプト情報を格納
    private ResultMoney resultMoneyCs;

    // Start is called before the first frame update
    void Start()
    {
        // 不足分オブジェクト初期化
        GameObject difictObject = GameObject.Find("DeficitMoneyText");
        dificitMoney = 0;
        difictText = difictObject.GetComponent<Text>();

        // お釣り初期化
        returnMoney = 0;

        // 購入済みかどうかフラグを初期化
        isFinishBuy = false;

        // 対象オブジェクトを格納
        GameObject attachClickMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // ClickMoneyのスクリプト情報を取得
        clickMoneyCs = attachClickMoneyCsObj.GetComponent<ClickMoney>();

        // 対象オブジェクトを格納
        GameObject attachManagementMoneyCsObj = GameObject.Find("MoneyArea");
        // ManagementMoneyのスクリプト情報を取得
        managementMoneyCs = attachManagementMoneyCsObj.GetComponent<ManagementMoney>();

        // 対象オブジェクトを格納
        GameObject attachResultMoneyCsObj = GameObject.Find("TickectMachineArea");
        // ResultMoneyのスクリプト情報を取得
        resultMoneyCs = attachResultMoneyCsObj.GetComponent<ResultMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        // 不足分テキスト
        difictText.text = dificitMoney.ToString();
    }

    /// <summary>
    /// 不足残金から投入された金額を引く
    /// お釣りが出る場合、金額を保持
    /// </summary>
    /// <param name="throwMoney">投入される金額</param>
    public void ThrowMoney(int throwMoney)
    {
        // 不足金額から投入金額を引く
        dificitMoney -= throwMoney;

        // 不足金額が0以下
        // (必要な分だけ投入されたら)
        if (dificitMoney <= 0)
        {
            // 正の値にしてお釣り金額保存
            returnMoney = dificitMoney * -1;
            resultMoneyCs.ReturnMoney = CalculationReturnMoney();
            // 不足分は0円にしておく
            dificitMoney = 0;
            // 購入完了
            isFinishBuy = true;

            // 「購入完了」に変更
            StateFlow.MachineState = StateFlow.STATE.GET_TICKET;
        }
    }

    /// <summary>
    /// お釣りの計算をして金種別の配列で返す
    /// </summary>
    /// <returns>金種別の配列</returns>
    public int[] CalculationReturnMoney()
    {
        // 金種別のお釣りの枚数
        int[] returnMoneyCount = new int[(int)ClickMoney.SELECTED_MONEY.NOT_SELECT/*列挙型金種の最大値*/] { 0, 0, 0, 0, 0, 0, 0, 0 };

        // 現金で払っていて、お釣りがあれば回収する
        if (returnMoney != 0 && clickMoneyCs.HowToPay == ClickMoney.PAY.CASH)
        {
            // お釣りの計算
            for (int i = (int)ClickMoney.SELECTED_MONEY.CREDIT/*CREDITは金種の最大値*/; i >= 0; i--)
            {
                // 電子マネーはスキップ
                if (i == (int)ClickMoney.SELECTED_MONEY.CREDIT) continue;

                // 割って余りがある場合
                if (returnMoney / managementMoneyCs.MoneyList[i] != 0)
                {
                    // 枚数をカウント
                    returnMoneyCount[i] = returnMoney / managementMoneyCs.MoneyList[i];
                    // お釣りからカウントした分だけの金額を引く
                    returnMoney -= managementMoneyCs.MoneyList[i] * returnMoneyCount[i];
                }
                // 余らない場合その金種はお釣りで使わない
                else
                {
                    returnMoneyCount[i] = 0;
                }
            }
        }

        return returnMoneyCount;
    }

    /// <summary>
    /// 支払い残金取得・設定関数
    /// </summary>
    public int DificitMoney { get { return dificitMoney; } set { dificitMoney = value; } }

    /// <summary>
    /// お釣り金額取得・設定関数
    /// </summary>
    public int ReturnMoney { get { return returnMoney; } set { returnMoney = value; } }

    /// <summary>
    /// 切符購入状態取得・設定関数
    /// </summary>
    public bool IsFinishBuy { get { return isFinishBuy; } set { isFinishBuy = value; } }
}
