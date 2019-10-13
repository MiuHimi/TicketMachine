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

    // ManagementCountのスクリプト情報を格納
    private ManagementCount managementCountCs;
    // ManagementCountがアタッチされているオブジェクト
    private GameObject attachManagementCountCsObj;

    // Start is called before the first frame update
    void Start()
    {
        // 対象オブジェクトを格納
        attachManagementCountCsObj = GameObject.Find("CountArea");
        // ManagementCountのスクリプト情報を取得
        managementCountCs = attachManagementCountCsObj.GetComponent<ManagementCount>();
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

            string str;
            // 金種に応じて表示テキスト変更
            switch (i)
            {
                case (int)ClickMoney.SELECTED_MONEY.TEN:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN].ToString();
                    CreateMoneyTypeText("10円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.FIFTY:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY].ToString();
                    CreateMoneyTypeText("50円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED].ToString();
                    CreateMoneyTypeText("100円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED].ToString();
                    CreateMoneyTypeText("500円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND].ToString();
                    CreateMoneyTypeText("1000円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND].ToString();
                    CreateMoneyTypeText("5000円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND].ToString();
                    CreateMoneyTypeText("10000円×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                case (int)ClickMoney.SELECTED_MONEY.CREDIT:
                    str = managementCountCs.ThrowMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT].ToString();
                    CreateMoneyTypeText("電子マネー×" + str, parent, 18, TextAnchor.MiddleCenter);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// お釣りを表示
    /// </summary>
    /// <param name="parent">表示するための親オブジェクト</param>
    private void ShowReturnMoneyText(GameObject parent)
    {

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
