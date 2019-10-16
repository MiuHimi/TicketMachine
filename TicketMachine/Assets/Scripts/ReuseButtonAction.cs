﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReuseButtonAction : MonoBehaviour
{
    // CalculationMoneyのスクリプト情報を格納
    private CalculationMoney calculationMoneyCs;

    // ManagementMoneyのスクリプト情報を格納
    private ManagementMoney managementMoneyCs;

    // Start is called before the first frame update
    void Start()
    {
        // 対象オブジェクトを格納
        GameObject attachCalculationMoneyCsObj = GameObject.Find("TicketMachineDirector");
        // CalculationMoneyのスクリプト情報を取得
        calculationMoneyCs = attachCalculationMoneyCsObj.GetComponent<CalculationMoney>();

        // 対象オブジェクトを格納
        GameObject attachManagementMoneyCsObj = GameObject.Find("MoneyArea");
        // ManagementMoneyのスクリプト情報を取得
        managementMoneyCs = attachManagementMoneyCsObj.GetComponent<ManagementMoney>();
    }

    /// <summary>
    /// ボタンが押された
    /// </summary>
    public void OnClick()
    {
        // お釣りの計算
        calculationMoneyCs.CalculationReturnMoney();

        // 購入完了だったら
        if (StateFlow.MachineState == StateFlow.STATE.GET_TICKET)
        {
            // お釣りを回収した所持金から金種別の最大値を再設定
            for (int i = 0; i < (int)ClickMoney.SELECTED_MONEY.NOT_SELECT/*(最大値)*/; i++)
            {
                managementMoneyCs.MaxMoneyCount[i] = managementMoneyCs.RemainMoneyCount[i];
            }
        }

        // 購入完了フラグをfalseにする
        calculationMoneyCs.IsFinishBuy = false;

        // 最初の状態に戻す
        StateFlow.MachineState = StateFlow.STATE.DEFAULT;
    }
}
