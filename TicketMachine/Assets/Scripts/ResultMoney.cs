using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMoney : MonoBehaviour
{
    // テキストプレハブ
    public GameObject textPrefab;
    // 投入したお金を表示するための親オブジェクト
    public GameObject throwMoneyParentObj;
    // お釣りを表示するための親オブジェクト
    public GameObject returnMoneyParentObj;
    // 残りのお金を表示するための親オブジェクト
    public GameObject remainMoneyParentObj;

    // お金一覧
    public int[] moneyList = { 0 };

    // お釣り
    private int returnMoney;

    // ClickMoneyのスクリプト情報を格納
    private ClickMoney clickMoneyCs;
    // ClickMoneyがアタッチされているオブジェクト
    private GameObject attachClickMoneyCsObj;

    // ManagementCountのスクリプト情報を格納
    private ManagementCount managementCountCs;
    // ManagementCountがアタッチされているオブジェクト
    private GameObject attachManagementCountCsObj;

    // CalculationMoneyのスクリプト情報を格納
    private CalculationMoney calculationMoneyCs;
    // CalculationMoneyがアタッチされているオブジェクト
    private GameObject attachCalculationMoneyCsObj;

    // Start is called before the first frame update
    void Start()
    {
        // 対象オブジェクトを格納
        attachClickMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // ClickMoneyのスクリプト情報を取得
        clickMoneyCs = attachClickMoneyCsObj.GetComponent<ClickMoney>();

        // 対象オブジェクトを格納
        attachManagementCountCsObj = GameObject.Find("CountArea");
        // ManagementCountのスクリプト情報を取得
        managementCountCs = attachManagementCountCsObj.GetComponent<ManagementCount>();

        // 対象オブジェクトを格納
        attachCalculationMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // CalculationMoneyのスクリプト情報を取得
        calculationMoneyCs = attachCalculationMoneyCsObj.GetComponent<CalculationMoney>();
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    // 購入結果表示
    public void ShowResultMoney()
    {
        // 投入したお金の表示
        ShowThrowMoneyText(throwMoneyParentObj);
        // お釣りの表示
        ShowReturnMoneyText(returnMoneyParentObj);
        // 現在のお金の表示
        ShowRemainMoneyText(remainMoneyParentObj);
    }

    /// <summary>
    /// 投入したお金を表示
    /// </summary>
    /// <param name="parent">表示するための親オブジェクト</param>
    private void ShowThrowMoneyText(GameObject parent)
    {
        for (int i = 0; i < managementCountCs.ThrowMoneyCount.Length; i++)
        {
            // 投入していないものはスキップ
            if (managementCountCs.ThrowMoneyCount[i] == 0) continue;

            // 金種別の表示
            ShowMoneyClassification(i, managementCountCs.ThrowMoneyCount, parent, 18);
        }
    }

    /// <summary>
    /// お釣りを表示
    /// </summary>
    /// <param name="parent">表示するための親オブジェクト</param>
    private void ShowReturnMoneyText(GameObject parent)
    {
        // お釣りの値を取得
        returnMoney = calculationMoneyCs.ReturnMoney;
        // 金種別のお釣りの枚数
        int[] returnMoneyCount = new int[] { 0, 0, 0, 0, 0, 0, 0};

        // 電子マネーは現金のお釣りで返さない
        if (clickMoneyCs.SelectedMoney == ClickMoney.SELECTED_MONEY.CREDIT) return;

        // お釣りの計算
        for(int i = returnMoneyCount.Length -1; i >= 0; i--)
        {
            // 割って余りがある場合
            if (returnMoney / moneyList[i] != 0)
            {
                // クレジットはスキップ
                if (i == (int)ClickMoney.SELECTED_MONEY.CREDIT) continue;
                // 枚数をカウント
                returnMoneyCount[i] = returnMoney / moneyList[i];
                // お釣りからカウントした分だけの金額を引く
                returnMoney -= moneyList[i] * returnMoneyCount[i];
            }
            // 余らない場合その金種はお釣りで使わない
            else
            {
                returnMoneyCount[i] = 0;
            }
        }

        for (int i = 0; i < returnMoneyCount.Length; i++)
        {
            // 返ってこないものはスキップ
            if (returnMoneyCount[i] == 0) continue;

            // 金種別の表示
            ShowMoneyClassification(i, returnMoneyCount, parent, 18);
        }
    }

    /// <summary>
    /// 残りのお金を表示
    /// </summary>
    /// <param name="parent">表示するための親オブジェクト</param>
    private void ShowRemainMoneyText(GameObject parent)
    {
        for (int i = 0; i < managementCountCs.RemainMoneyCount.Length; i++)
        {
            // 電子マネー以外
            if (i != (int)ClickMoney.SELECTED_MONEY.CREDIT)
            {
                // 現在残っているお金を計算
                managementCountCs.RemainMoneyCount[i] -= managementCountCs.ThrowMoneyCount[i];
            }
            // 電子マネー
            else if(i == (int)ClickMoney.SELECTED_MONEY.CREDIT)
            {
                // 現在残っているお金を計算
                managementCountCs.RemainMoneyCount[i] = returnMoney;
            }

            // 金種別の表示
            ShowMoneyClassification(i, managementCountCs.RemainMoneyCount, parent, 18);
        }
    }

    /// <summary>
    /// 金種別の表示
    /// </summary>
    /// <param name="moneyType">金種</param>
    /// <param name="countObject">枚数をカウントするオブジェクト</param>
    /// <param name="parent">表示するための親オブジェクト</param>
    /// <param name="fontSize">フォントサイズ</param>
    private void ShowMoneyClassification(int moneyType, int[] countObject, GameObject parent, int fontSize)
    {
        string str;
        // 金種に応じて表示テキスト変更
        switch (moneyType)
        {
            case (int)ClickMoney.SELECTED_MONEY.TEN:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.TEN].ToString();
                CreateMoneyTypeText("10円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.FIFTY:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.FIFTY].ToString();
                CreateMoneyTypeText("50円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED].ToString();
                CreateMoneyTypeText("100円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED].ToString();
                CreateMoneyTypeText("500円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND].ToString();
                CreateMoneyTypeText("1000円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND].ToString();
                CreateMoneyTypeText("5000円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND].ToString();
                CreateMoneyTypeText("10000円×" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            case (int)ClickMoney.SELECTED_MONEY.CREDIT:
                str = countObject[(int)ClickMoney.SELECTED_MONEY.CREDIT].ToString();
                CreateMoneyTypeText("電子マネー  ￥" + str, parent, fontSize, TextAnchor.MiddleCenter);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// テキストオブジェクト生成
    /// </summary>
    /// <param name="moneyType">金種</param>
    /// <param name="parent">表示するための親オブジェクト</param>
    /// <param name="fontSize">フォントサイズ</param>
    /// <param name="textAnchor">アラインメント</param>
    private void CreateMoneyTypeText(string moneyType, GameObject parent, int fontSize, TextAnchor textAnchor)
    {
        GameObject obj = Instantiate(textPrefab);
        obj.gameObject.GetComponent<Text>().text = moneyType;
        obj.transform.SetParent(parent.transform, false);
        obj.GetComponent<Text>().fontSize = fontSize;
        obj.GetComponent<Text>().alignment = textAnchor;
    }
}
