using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 衝突判定をテストするためのスクリプト
/// </summary>
public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;    // ぶつかった「相手」の GameObject を取得する
        string othersName = other.name; // ぶつかった相手の GameObject 名を取得する
        Debug.Log(othersName + " にぶつかった");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;    // ぶつかった「相手」の GameObject を取得する
        string othersName = other.name; // ぶつかった相手の GameObject 名を取得する
        Debug.Log(othersName + " に接触している");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;    // ぶつかった「相手」の GameObject を取得する
        string othersName = other.name; // ぶつかった相手の GameObject 名を取得する
        Debug.Log(othersName + " から離れた");
    }
}
