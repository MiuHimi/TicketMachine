using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFlow : MonoBehaviour
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
    public STATE machineState;

    // Start is called before the first frame update
    void Start()
    {
        // 初期状態
        machineState = STATE.DEFAULT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
