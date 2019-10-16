using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReuseButtonAction : MonoBehaviour
{
    // CalculationMoneyのスクリプト情報を格納
    private CalculationMoney calculationMoneyCs;

    // ManagementCountのスクリプト情報を格納
    private ManagementCount managementCountCs;

    // Start is called before the first frame update
    void Start()
    {
        // 対象オブジェクトを格納
        GameObject attachCalculationMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // CalculationMoneyのスクリプト情報を取得
        calculationMoneyCs = attachCalculationMoneyCsObj.GetComponent<CalculationMoney>();

        // 対象オブジェクトを格納
        GameObject attachManagementCountCsObj = GameObject.Find("CountArea");
        // ManagementCountのスクリプト情報を取得
        managementCountCs = attachManagementCountCsObj.GetComponent<ManagementCount>();
    }

    /// <summary>
    /// 表示/非表示切り替え
    /// </summary>
    /// <param name="flag">切り替えフラグ</param>
    public void SetActive(bool flag)
    {
        this.gameObject.SetActive(flag);
    }

    /// <summary>
    /// ボタンが押された
    /// </summary>
    public void OnClick()
    {
        // お釣りの値を取得
        int returnMoney = calculationMoneyCs.ReturnMoney;
        // 金種別のお釣りの枚数
        int[] returnMoneyCount = new int[(int)ClickMoney.SELECTED_MONEY.NOT_SELECT] { 0, 0, 0, 0, 0, 0, 0, 0};

        // お釣りがあれば回収する
        if (returnMoney != 0)
        {
            // お釣りの計算
            for (int i = (int)ClickMoney.SELECTED_MONEY.CREDIT/*CREDITは最大値*/; i >= 0 ; i--)
            {
                // 電子マネーはスキップ
                if (i == (int)ClickMoney.SELECTED_MONEY.CREDIT) continue;

                // 割って余りがある場合
                if (returnMoney / managementCountCs.MoneyList[i] != 0)
                {
                    // 枚数をカウント
                    returnMoneyCount[i] = returnMoney / managementCountCs.MoneyList[i];
                    // お釣りからカウントした分だけの金額を引く
                    returnMoney -= managementCountCs.MoneyList[i] * returnMoneyCount[i];
                }
                // 余らない場合その金種はお釣りで使わない
                else
                {
                    returnMoneyCount[i] = 0;
                }

                // お釣りを所持金に戻す
                managementCountCs.ReturnMoneyToRemainMoney(i, returnMoneyCount[i]);
            }
        }

        // 購入完了だったら
        if (StateFlow.MachineState == StateFlow.STATE.GET_TICKET)
        {
            // 所持金から金種別の最大値を設定
            for (int i = 0; i < (int)ClickMoney.SELECTED_MONEY.NOT_SELECT/*(最大値)*/; i++)
            {
                managementCountCs.MaxMoneyCount[i] = managementCountCs.RemainMoneyCount[i];
            }
        }

        // 終了フラグをfalseにする
        calculationMoneyCs.IsFinishBuy = false;

        // 最初の状態に戻す
        StateFlow.MachineState = StateFlow.STATE.DEFAULT;
    }
}
