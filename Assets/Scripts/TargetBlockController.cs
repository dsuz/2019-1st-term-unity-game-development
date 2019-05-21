using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ターゲットブロック（ボールが当たったら壊れるブロック）を制御する
/// ターゲットブロックの GameObject に追加して使う
/// </summary>
public class TargetBlockController : MonoBehaviour
{
    /// <summary>ブロックを壊した時に入る点数</summary>
    public int Score = 100;

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
        // このログはもう不要なので無効にする
        // Debug.Log("Enter OnCollisionEnter2D."); // 関数が呼び出されたら Console にログを出力する

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
        Debug.Log("Enter OnTriggerEnter2D."); // 関数が呼び出されたら Console にログを出力する

        // 衝突相手がボールだったら自分自身を破棄する
        if (collision.gameObject.tag == "BallTag")
        {
            Destroy(this.gameObject);
        }
    }
}
