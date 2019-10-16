using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonAction : MonoBehaviour
{
    /// <summary>
    /// ボタンが押された
    /// </summary>
    public void OnClick()
    {
        // 券売機の状態を「購入ボタンが押された」にする
        StateFlow.MachineState = StateFlow.STATE.PUSH_BUY_BUTTON;
    }
}
