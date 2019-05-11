using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ターゲットブロック（ボールが当たったら壊れるブロック）を制御する
/// ターゲットブロックの GameObject に追加して使う
/// </summary>
public class TargetBlockController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// Collider に衝突判定があった時に呼ばれる
    /// </summary>
    /// <param name="collision">衝突の情報</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突相手がボールだったら自分自身を破棄する
        if (collision.gameObject.tag == "BallTag")
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 「トリガーモードの」Collider に衝突判定があった時に呼ばれる
    /// </summary>
    /// <param name="collision">衝突の情報</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突相手がボールだったら自分自身を破棄する
        if (collision.gameObject.tag == "BallTag")
        {
            Destroy(this.gameObject);
        }
    }
}
