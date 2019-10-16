using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabGenerator
{
    // プレハブ生成
    public static GameObject CreatePrefab(string checkTag, string loadPath, GameObject parentObj, Vector3 posotion, Quaternion rotation, Vector3 scale)
    {
        GameObject obj = null;
        int reuseButtonTags = CheckTagNum(checkTag);
        if (reuseButtonTags == 0)
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load(loadPath);
            // プレハブからインスタンスを生成
            obj = Object.Instantiate(prefab);

            // 親オブジェクト設定
            obj.transform.SetParent(parentObj.transform, false);
            // 位置、回転、拡大設定
            obj.transform.localPosition = posotion;
            obj.transform.localRotation = rotation;
            obj.transform.localScale = scale;

            return obj;
        }
        else
        {
            return obj;
        }
    }

    /// <summary>
    /// タグが付いたオブジェクトを数えて個数を返す
    /// </summary>
    /// <param name="tagname">タグの名前</param>
    /// <returns>指定のオブジェクトの個数</returns>
    private static int CheckTagNum(string tagname)
    {
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        // タグが付いたオブジェクトの数を返す
        return tagObjects.Length;
    }
}
