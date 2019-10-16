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

    // お金一覧
    public int[] moneyList = { 0 };

    // 全てのお金の枚数を保持
    [SerializeField]
    private int[] maxMoneyCount = { 0 };

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

        // 要素数確保
        remainMoneyCount = new int[maxMoneyCount.Length];
        // 全てのお金と残りのお金を初期化
        for (int i = 0; i< maxMoneyCount.Length;i++)
        {
            remainMoneyCount[i] = maxMoneyCount[i];
        }

        // 初期化(最初はすべて0)
        throwMoneyCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        // 対象オブジェクトを格納
        attachClickMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // ClickMoneyのスクリプト情報を取得
        clickMoneyCs = attachClickMoneyCsObj.GetComponent<ClickMoney>();

        // 対象オブジェクトを格納
        attachCalculationMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // CalculationMoneyのスクリプト情報を取得
        calculationMoneyCs = attachCalculationMoneyCsObj.GetComponent<CalculationMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        // 初期状態だったら
        if(StateFlow.MachineState == StateFlow.STATE.DEFAULT)
        {
            // 投入金額の枚数は0にする
            for (int i = 0; i < (int)ClickMoney.SELECTED_MONEY.NOT_SELECT/*(最大値)*/; i++)
            {
                throwMoneyCount[i] = 0;
            }
        }

        // 選択された金種に応じて処理を変える
        switch (clickMoneyCs.SelectedMoney)
        {
            case ClickMoney.SELECTED_MONEY.TEN:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.TEN);
                calculationMoneyCs.ThrowMoney(10);
                break;
            case ClickMoney.SELECTED_MONEY.FIFTY:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIFTY] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.FIFTY);
                calculationMoneyCs.ThrowMoney(50);
                break;
            case ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED);
                calculationMoneyCs.ThrowMoney(100);
                break;
            case ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED);
                calculationMoneyCs.ThrowMoney(500);
                break;
            case ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND);
                calculationMoneyCs.ThrowMoney(1000);
                break;
            case ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND);
                calculationMoneyCs.ThrowMoney(5000);
                break;
            case ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND]++;
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND] =
                    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND];
                if (remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND] < 0) remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND] = 0;
                DisCount((int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND);
                calculationMoneyCs.ThrowMoney(10000);
                break;
            case ClickMoney.SELECTED_MONEY.CREDIT:
                throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT] = remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT];
                // 最大枚数から投入枚数を引いて現在の枚数を更新
                remainMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT] -= calculationMoneyCs.DificitMoney;
                //    maxMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT] - throwMoneyCount[(int)ClickMoney.SELECTED_MONEY.CREDIT];
                // 所持金から不足分を引く(所持金の更新)
                DisCount((int)ClickMoney.SELECTED_MONEY.CREDIT);
                // 不足分から投入金額を引く(不足金額とお釣りの更新)
                calculationMoneyCs.ThrowMoney(1000);
                break;
            default:
                break;
        }

        for (int i = 0; i < (int)ClickMoney.SELECTED_MONEY.NOT_SELECT/*最大値*/; i++)
        {
            int count = 0;
            switch (i)
            {
                case (int)ClickMoney.SELECTED_MONEY.TEN:
                    count = RemainMoneyCount[i];
                    tenAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.FIFTY:
                    count = RemainMoneyCount[i];
                    fiftyAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.ONE_HUNDRED:
                    count = RemainMoneyCount[i];
                    oneHundredAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.FIVE_HUNDRED:
                    count = RemainMoneyCount[i];
                    fiveHundredAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.ONE_THOUSAND:
                    count = RemainMoneyCount[i];
                    oneThousandAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.FIVE_THOUSAND:
                    count = RemainMoneyCount[i];
                    fiveThousandAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.TEN_THOUSAND:
                    count = RemainMoneyCount[i];
                    tenThousandAmount.text = count.ToString();
                    break;
                case (int)ClickMoney.SELECTED_MONEY.CREDIT:
                    count = RemainMoneyCount[i];
                    digitalCashAmount.text = count.ToString();
                    break;
                default:
                    break;
            }
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
                count = StringToInt(digitalCashAmount.text);
                // ディスカウント
                if (count > 0)
                {
                    count -= calculationMoneyCs.DificitMoney;
                }
                digitalCashAmount.text = count.ToString();
                break;
            default:
                break;
        }
    }

    public void ReturnMoneyToRemainMoney(int i, int returnMoney)
    {
        RemainMoneyCount[i] += returnMoney;
    }

    // stringからintへ変換して値を返す
    private int StringToInt(string text)
    {
        return int.Parse(text);
    }

    /// <summary>
    /// お金一覧取得・設定関数
    /// </summary>
    public int[] MoneyList { get { return moneyList; } set { moneyList = value; } }

    /// <summary>
    /// 金種別の最大値取得・設定関数
    /// </summary>
    public int[] MaxMoneyCount { get { return maxMoneyCount; } set { maxMoneyCount = value; } }


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
