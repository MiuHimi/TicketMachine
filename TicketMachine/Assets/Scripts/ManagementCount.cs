using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagementCount : MonoBehaviour
{
    // 10円の残量
    private Text tenAmount;
    // 50円の残量
    private Text fiftyAmount;
    // 100円の残量
    private Text oneHundredAmount;
    // 500円の残量
    private Text fiveHundredAmount;
    // 1000円の残量
    private Text oneThousandAmount;
    // 5000円の残量
    private Text fiveThousandAmount;
    // 10000円の残量
    private Text tenThousandAmount;

    // ClickMoneyのスクリプト情報を格納
    private ClickMoney clickMoneyCs;
    // StateFlowがアタッチされているオブジェクト
    private GameObject attachClickMoneyCsObj;

    // Start is called before the first frame update
    void Start()
    {
        // 対象のオブジェクトを格納
        GameObject ten = GameObject.Find("10yenText");
        GameObject fifty = GameObject.Find("50yenText");
        GameObject oneHundred = GameObject.Find("100yenText");
        GameObject fiveHundred = GameObject.Find("500yenText");
        GameObject oneThousand = GameObject.Find("1000yenText");
        GameObject fiveThousand = GameObject.Find("5000yenText");
        GameObject tenThousand = GameObject.Find("10000yenText");

        // 対象のテキストを格納
        tenAmount = ten.GetComponent<Text>();
        fiftyAmount = fifty.GetComponent<Text>();
        oneHundredAmount= oneHundred.GetComponent<Text>();
        fiveHundredAmount = fiveHundred.GetComponent<Text>();
        oneThousandAmount = oneThousand.GetComponent<Text>();
        fiveThousandAmount = fiveThousand.GetComponent<Text>();
        tenThousandAmount = tenThousand.GetComponent<Text>();

        // 対象オブジェクトを格納
        attachClickMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // StateFlowのスクリプト情報を取得
        clickMoneyCs = attachClickMoneyCsObj.GetComponent<ClickMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (clickMoneyCs.SelectedMoney)
        {
            case ClickMoney.SELECTED_MONEY.TEN:
                DisCount(10);
                break;
            case ClickMoney.SELECTED_MONEY.FIFTY:
                DisCount(50);
                break;
            case ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                DisCount(100);
                break;
            case ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                DisCount(500);
                break;
            case ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                DisCount(1000);
                break;
            case ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                DisCount(5000);
                break;
            case ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                DisCount(10000);
                break;
        }
    }

    private void DisCount(int money)
    {
        int count = 0;
        switch (money)
        {
            case 10:
                // 型変換
                count = StringToInt(tenAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                tenAmount.text = count.ToString();
                break;
            case 50:
                // 型変換
                count = StringToInt(fiftyAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                fiftyAmount.text = count.ToString();
                break;
            case 100:
                // 型変換
                count = StringToInt(oneHundredAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                oneHundredAmount.text = count.ToString();
                break;
            case 500:
                // 型変換
                count = StringToInt(fiveHundredAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                fiveHundredAmount.text = count.ToString();
                break;
            case 1000:
                // 型変換
                count = StringToInt(oneThousandAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                oneThousandAmount.text = count.ToString();
                break;
            case 5000:
                // 型変換
                count = StringToInt(fiveThousandAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                fiveThousandAmount.text = count.ToString();
                break;
            case 10000:
                // 型変換
                count = StringToInt(tenThousandAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                tenThousandAmount.text = count.ToString();
                break;
            default:
                break;
        }
    }

    // stringからintへ変換して値を返す
    private int StringToInt(string text)
    {
        return int.Parse(text);
    }

    /// <summary>
    /// 枚数取得・設定関数
    /// </summary>
    //public Text MoneyCount { get { return moneyCount; } set { moneyCount = value; } }
}
