using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        FIFTEEN,
        ONE_HUNDRED,
        FIVE_HUNDRED,
        ONE_THOUSAND,
        FIVE_THOUSAND,
        TEN_THOUSAND,
        CREDIT,

        MAX
    }

    // 支払い方法
    private PAY howToPay;

    // 支払うもの
    private SELECTED_MONEY selectedMoney;

    // レイが当たったオブジェクトの情報を入れる
    private RaycastHit hit;
    // レイの飛ばせる距離
    private float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        // 支払い方法(方法未定)
        howToPay = PAY.NONE;

        // レイを飛ばせる距離
        rayDistance = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
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

                switch(objectName)
                {
                    case "10yen":
                        if(howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "50yen":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "100yen":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "500yen":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "1000yen":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "5000yen":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "10000yen":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.CASH;
                        }
                        break;
                    case "DigitalCash":
                        if (howToPay == PAY.NONE)
                        {
                            howToPay = PAY.DIGITAL_CASH;
                        }
                        break;
                    default:            Debug.Log("お金払って");         break;
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
