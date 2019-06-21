using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rigidbody2D の使い方をテストするスクリプト
/// </summary>
public class VelocityTest : MonoBehaviour
{
    public void Accel()
    {
        Debug.Log("Accel() が呼ばれた");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();   // 自分自身の Rigidbody2D コンポーネントを取ってくる
        rb.velocity = rb.velocity * 1.5f;   // 速度ベクトルの大きさを 1.5 倍にする
    }

    public void HitUp()
    {
        Debug.Log("HitUp() が呼ばれた");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();   // 自分自身の Rigidbody2D コンポーネントを取ってくる
        rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);  // 上向きの力を加える
    }
}
