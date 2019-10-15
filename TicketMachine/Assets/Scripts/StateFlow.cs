using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateFlow
{
    // 券売機の状態
    public enum STATE
    {
        DEFAULT,            // 初期状態
        PUSH_BUY_BUTTON,    // 購入ボタンが押される
        THROW_CASH,         // お金が投入される
        GET_TICKET          // チケットが放出される
    }

    // 券売機の状態を保持
    [SerializeField]
    static private STATE machineState = STATE.DEFAULT;

    /// <summary>
    /// 取得・設定関数
    /// </summary>
    public static STATE MachineState { get { return machineState; } set { machineState = value; } }
}
