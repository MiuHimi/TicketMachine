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
    // 電子マネーの残量
    private Text digitalCashAmount;

    // 残りのお金を保持
    private int[] remainMoneyCount = { 0 };

    // 投入された金銭を保持
    private int[] throwMoneyCount = { 0 };

    // ClickMoneyのスクリプト情報を格納
    private ClickMoney clickMoneyCs;
    // ClickMoneyがアタッチされているオブジェクト
    private GameObject attachClickMoneyCsObj;

    // CalculationMoneyのスクリプト情報を格納
    private CalculationMoney calculationMoneyCs;
    // CalculationMoneyがアタッチされているオブジェクト
    private GameObject attachCalculationMoneyCsObj;

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
        GameObject digitalCash = GameObject.Find("DisitalCashText");
        
        // 対象のテキストを格納
        tenAmount = ten.GetComponent<Text>();
        fiftyAmount = fifty.GetComponent<Text>();
        oneHundredAmount= oneHundred.GetComponent<Text>();
        fiveHundredAmount = fiveHundred.GetComponent<Text>();
        oneThousandAmount = oneThousand.GetComponent<Text>();
        fiveThousandAmount = fiveThousand.GetComponent<Text>();
        tenThousandAmount = tenThousand.GetComponent<Text>();
        digitalCashAmount = digitalCash.GetComponent<Text>();

        // 残りのお金を保持
        remainMoneyCount = new int[]
        {
            
            StringToInt(ten.GetComponent<Text>().text.ToString()),
            StringToInt(fifty.GetComponent<Text>().text.ToString()),
            StringToInt(oneHundred.GetComponent<Text>().text.ToString()),
            StringToInt(fiveHundred.GetComponent<Text>().text.ToString()),
            StringToInt(oneThousand.GetComponent<Text>().text.ToString()),
            StringToInt(fiveThousand.GetComponent<Text>().text.ToString()),
            StringToInt(tenThousand.GetComponent<Text>().text.ToString()),
            StringToInt(digitalCash.GetComponent<Text>().text.ToString())
        };

        // 初期化(最初はすべて0)
        throwMoneyCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        // 対象オブジェクトを格納
        attachClickMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // StateFlowのスクリプト情報を取得
        clickMoneyCs = attachClickMoneyCsObj.GetComponent<ClickMoney>();

        // 対象オブジェクトを格納
        attachCalculationMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // CalculationMoneyのスクリプト情報を取得
        calculationMoneyCs = attachCalculationMoneyCsObj.GetComponent<CalculationMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (clickMoneyCs.SelectedMoney)
        {
            case ClickMoney.SELECTED_MONEY.TEN:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.TEN);
                calculationMoneyCs.ThrowMoney(10);
                break;
            case ClickMoney.SELECTED_MONEY.FIFTY:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.FIFTY);
                calculationMoneyCs.ThrowMoney(50);
                break;
            case ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED);
                calculationMoneyCs.ThrowMoney(100);
                break;
            case ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED);
                calculationMoneyCs.ThrowMoney(500);
                break;
            case ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND);
                calculationMoneyCs.ThrowMoney(1000);
                break;
            case ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND);
                calculationMoneyCs.ThrowMoney(5000);
                break;
            case ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND]++;
                DisCount((int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND);
                calculationMoneyCs.ThrowMoney(10000);
                break;
            case ClickMoney.SELECTED_MONEY.CREDIT:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT]++;
                //DisCount((int)ClickMoney.SELECTED_MONEY.CREDIT);
                calculationMoneyCs.ThrowMoney(1000);
                break;
            default:
                break;
        }
    }

    private void DisCount(int moneyType)
    {
        int count = 0;
        switch (moneyType)
        {
            case (int)ClickMoney.SELECTED_MONEY.TEN:
                // 型変換
                count = StringToInt(tenAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                tenAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.FIFTY:
                // 型変換
                count = StringToInt(fiftyAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                fiftyAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                // 型変換
                count = StringToInt(oneHundredAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                oneHundredAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                // 型変換
                count = StringToInt(fiveHundredAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                fiveHundredAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                // 型変換
                count = StringToInt(oneThousandAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                oneThousandAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                // 型変換
                count = StringToInt(fiveThousandAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                fiveThousandAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                // 型変換
                count = StringToInt(tenThousandAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                tenThousandAmount.text = count.ToString();
                break;
            case (int)ClickMoney.SELECTED_MONEY.CREDIT:
                // 型変換
                //count = StringToInt(digitalCashAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count--;
                }
                digitalCashAmount.text = count.ToString();
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
    /// 残りのお金取得・設定関数
    /// </summary>
    public int[] RemainMoneyCount { get { return remainMoneyCount; } set { remainMoneyCount = value; } }

    public int[] ThrowMoneyCount { get { return throwMoneyCount; } set { throwMoneyCount = value; } }

    /// <summary>
    /// 枚数取得・設定関数
    /// </summary>
    //public Text MoneyCount { get { return moneyCount; } set { moneyCount = value; } }
}
