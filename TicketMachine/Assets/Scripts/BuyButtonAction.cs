using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ボタンが押された
    /// </summary>
    public void OnClick()
    {
        // 券売機の状態を「購入ボタンが押された」にする
        StateFlow.MachineState = StateFlow.STATE.PUSH_BUY_BUTTON;

        // 非表示にする
        //this.gameObject.SetActive(false);
    }
}
