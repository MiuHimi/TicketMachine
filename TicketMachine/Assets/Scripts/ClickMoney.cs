using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoney : MonoBehaviour
{
    // レイが当たったオブジェクトの情報を入れる
    private RaycastHit hit;
    // レイの飛ばせる距離
    private float rayDistance = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log(objectName);
            }
        }
    }
}
