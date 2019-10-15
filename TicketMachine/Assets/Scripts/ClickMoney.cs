using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMoney : MonoBehaviour
{
    // 支払い方法一覧
    public enum PAY
    {
        NONE,
        CASH,
        DIGITAL_CASH
    }

    // 選択したお金
    public enum SELECTED_MONEY
    {
        TEN,
        FIFTY,
        ONE_HUNDRED,
        FIVE_HUNDRED,
        ONE_THOUSAND,
        FIVE_THOUSAND,
        TEN_THOUSAND,
        CREDIT,

        NOT_SELECT,
    }

    // 支払い方法
    private PAY howToPay;

    // 支払うもの
    private SELECTED_MONEY selectedMoney;

    // レイが当たったオブジェクトの情報を入れる
    private RaycastHit hit;
    // レイの飛ばせる距離
    private float rayDistance;

    // CalculationMoneyのスクリプト情報を格納
    private CalculationMoney calculationMoneyCs;
    // CalculationMoneyがアタッチされているオブジェクト
    private GameObject attachCalculationMoneyCsObj;

    // Start is called before the first frame update
    void Start()
    {
        // 支払い方法(方法未定)
        howToPay = PAY.NONE;

        // 非選択
        selectedMoney = SELECTED_MONEY.NOT_SELECT;

        // レイを飛ばせる距離
        rayDistance = 200.0f;

        // 対象オブジェクトを格納
        attachCalculationMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // CalculationMoneyのスクリプト情報を取得
        calculationMoneyCs = attachCalculationMoneyCsObj.GetComponent<CalculationMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        // クリックされていないときは非選択に
        selectedMoney = SELECTED_MONEY.NOT_SELECT;

        // 切符を購入できるまで投入が可能
        if (calculationMoneyCs.IsFinishBuy) return;

        // クリックしたとき
        if (Input.GetMouseButtonDown(0))
        {
            //　カメラからクリックした位置にレイを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // もしもレイにオブジェクトが衝突したら
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // オブジェクトの名前を取得
                string objectName = hit.collider.gameObject.name;

                // 「購入」ボタンが押されていて、金銭が投入中だったら
                if(StateFlow.MachineState >= StateFlow.STATE.PUSH_BUY_BUTTON &&
                   StateFlow.MachineState <= StateFlow.STATE.THROW_CASH)
                {
                    // 投入されたものが現金だったら
                    if (objectName == "10yen" || objectName == "50yen" ||
                        objectName == "100yen" || objectName == "500yen" ||
                        objectName == "1000yen" || objectName == "5000yen" ||
                        objectName == "10000yen")
                    {
                        // 支払い方法を現金に設定
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                            // 現金の場合の代金
                            calculationMoneyCs.DificitMoney = 130;
                        }
                    }
                    // 電子マネーだったら
                    else if(objectName == "DigitalCash")
                    {
                        // 支払い方法を電子マネーに設定
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.DIGITAL_CASH;
                            // 電子マネーの場合の代金
                            calculationMoneyCs.DificitMoney = 124;
                        }
                    }

                    switch (objectName)
                    {
                        case "10yen":
                            // 10円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.TEN;
                            break;
                        case "50yen":
                            // 50円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.FIFTY;
                            break;
                        case "100yen":
                            // 100円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.ONE_HUNDRED;
                            break;
                        case "500yen":
                            // 500円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.FIVE_HUNDRED;
                            break;
                        case "1000yen":
                            // 1000円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.ONE_THOUSAND;
                            break;
                        case "5000yen":
                            // 5000円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.FIVE_THOUSAND;
                            break;
                        case "10000yen":
                            // 10000円を選択
                            if (howToPay == PAY.CASH) selectedMoney = SELECTED_MONEY.TEN_THOUSAND;
                            break;
                        case "DigitalCash":
                            // ICカードを選択
                            if (howToPay == PAY.DIGITAL_CASH) selectedMoney = SELECTED_MONEY.CREDIT;
                            break;
                        default:            Debug.Log("お金払って");         break;
                    }
                    // 券売機の状態を「金銭投入中」にする
                    StateFlow.MachineState = StateFlow.STATE.THROW_CASH;
                    Debug.Log(StateFlow.MachineState);
                }
            }
        }
    }

    /// <summary>
    /// 支払い方法取得・設定関数
    /// </summary>
    public PAY HowToPay { get { return howToPay; } set { howToPay = value; } }

    /// <summary>
    /// 選択貨幣取得・設定関数
    /// </summary>
    public SELECTED_MONEY SelectedMoney { get { return selectedMoney; } set { selectedMoney = value; } }
}
