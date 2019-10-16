using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleManager : MonoBehaviour
{
    //UI取得用
    [SerializeField]
    private Text[] guideText;
    [SerializeField]
    private Text[] deficitText;
    [SerializeField]
    private Text[] throwText;
    [SerializeField]
    private Text[] returnText;
    [SerializeField]
    private Text[] remainText;

    // 購入するボタン(クローン、プレハブから取得)
    private GameObject cloneBuyButton;
    // 購入するボタンの親オブジェクト
    [SerializeField]
    private GameObject buyButtonParentObj;

    // 再使用ボタン(クローン、プレハブから取得)
    private GameObject cloneReuseButton;
    // 再使用ボタンの親オブジェクト
    [SerializeField]
    private GameObject reuseButtonParentObj;

    // 終了ボタン(クローン、プレハブから取得)
    private GameObject cloneEndButton;
    // 終了ボタンの親オブジェクト
    [SerializeField]
    private GameObject endButtonParentObj;

    // ResultMoneyのスクリプト情報を格納
    private ResultMoney resultMoneyCs;
    
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクト情報を初期化
        cloneBuyButton = null;
        cloneReuseButton = null;
        cloneEndButton = null;

        // 対象オブジェクトを格納
        GameObject attachResultMoneyCsObj = GameObject.Find("TickectMachineArea");
        // ResultMoneyのスクリプト情報を取得
        resultMoneyCs = attachResultMoneyCsObj.GetComponent<ResultMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        // ボタンが押されてから以降
        if (StateFlow.MachineState >= StateFlow.STATE.PUSH_BUY_BUTTON)
        {
            // 購入するボタン削除(非表示)
            if (cloneBuyButton)
            {
                Destroy(cloneBuyButton);
            }

            // 案内テキスト表示
            for (int i = 0; i < guideText.Length; i++)
            {
                guideText[i].enabled = true;
            }
        }
        // 金銭が投入されてから以降
        if (StateFlow.MachineState >= StateFlow.STATE.THROW_CASH)
        {
            // 不足金額テキスト表示
            for (int i = 0; i < deficitText.Length; i++)
            {
                deficitText[i].enabled = true;
            }
        }
        // 購入が完了してから以降
        if (StateFlow.MachineState >= StateFlow.STATE.GET_TICKET)
        {
            // 投入した金額テキスト表示
            for (int i = 0; i < throwText.Length; i++)
            {
                throwText[i].enabled = true;
            }
            // お釣りテキスト表示
            for (int i = 0; i < returnText.Length; i++)
            {
                returnText[i].enabled = true;
            }
            // 残りのお金テキスト表示
            for (int i = 0; i < remainText.Length; i++)
            {
                remainText[i].enabled = true;
            }

            // 結果画面を表示
            if (!resultMoneyCs.IsShowed)
            {
                resultMoneyCs.ShowResultMoney();
                resultMoneyCs.IsShowed = true;
            }

            // 再使用ボタン生成(表示)
            if (cloneReuseButton == null)
            {
                cloneReuseButton = PrefabGenerator.CreatePrefab("ReuseButton", "Buttons/ReuseButton", reuseButtonParentObj,
                                   new Vector3(120.0f, 205.0f, 0.0f), Quaternion.identity, new Vector3(1.0f, 1.0f, 1.0f));
            }

            // 終了ボタン生成(表示)
            if (cloneEndButton == null)
            {
                cloneEndButton = PrefabGenerator.CreatePrefab("EndButton", "Buttons/EndButton", endButtonParentObj,
                                 new Vector3(260.0f, 205.0f, 0.0f), Quaternion.identity, new Vector3(1.0f, 1.0f, 1.0f));
            }            
        }

        // 券売機がデフォルト(初期)状態だったら
        if (StateFlow.MachineState == StateFlow.STATE.DEFAULT)
        {
            // 購入するボタン生成(表示)
            if (cloneBuyButton == null)
            {
                cloneBuyButton = PrefabGenerator.CreatePrefab("BuyButton", "Buttons/BuyButton", buyButtonParentObj,
                                 new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, new Vector3(1.0f, 1.0f, 1.0f));
            }

            // 案内テキスト非表示
            for (int i = 0; i < guideText.Length; i++)
            {
                guideText[i].enabled = false;
            }
            // 不足金額テキスト非表示
            for (int i = 0; i < deficitText.Length; i++)
            {
                deficitText[i].enabled = false;
            }
            // 投入した金額テキスト非表示
            for (int i = 0; i < throwText.Length; i++)
            {
                throwText[i].enabled = false;
            }
            // お釣りテキスト非表示
            for (int i = 0; i < returnText.Length; i++)
            {
                returnText[i].enabled = false;
            }
            // 残りのお金テキスト非表示
            for (int i = 0; i < remainText.Length; i++)
            {
                remainText[i].enabled = false;
            }

            // 再使用ボタン削除(非表示)
            if(cloneReuseButton)
            {
                Destroy(cloneReuseButton);
            }
            // 終了ボタン削除(非表示)
            if (cloneEndButton)
            {
                Destroy(cloneEndButton);
            }

            // 結果画面表示フラグをfalseに
            resultMoneyCs.IsShowed = false;
        }
    }
}
