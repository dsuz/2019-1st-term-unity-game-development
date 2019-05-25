using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI を使うために必要になる

/// <summary>
/// ボールを制御するクラス
/// ボールのオブジェクトに追加して使う
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class BallController : MonoBehaviour
{
    /// <summary>ボールが最初に動く方向</summary>
    [SerializeField] Vector2 m_powerDirection = Vector2.up + Vector2.right;
    /// <summary>ボールを最初に動かす力の大きさ</summary>
    [SerializeField] float m_powerScale = 5f;
    Rigidbody2D m_rb2d;
    /// <summary>得点を表示する Text</summary>
    [SerializeField] Text m_scoreText;
    /// <summary>得点</summary>
    int m_score = 0;
    /// <summary>メッセージを表示する Text</summary>
    [SerializeField] Text m_messageText;
    /// <summary>ゲームスタートボタン</summary>
    [SerializeField] Button m_startButton;
    /// <summary>ボールが衝突した時の SFX</summary>
    [SerializeField] AudioClip m_sfx;
    AudioSource m_audioSource;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        // m_startButton が設定されていない時はボールを押す
        if (m_startButton == null)
        {
            Push();
        }

        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    /// <summary>
    /// ボールに力を加える
    /// </summary>
    public void Push()
    {
        m_rb2d.AddForce(m_powerDirection.normalized * m_powerScale, ForceMode2D.Impulse);

        // 得点をリセットする
        m_score = 0;

        // m_startButton がある場合は、非表示にする
        if (m_startButton)
        {
            m_startButton.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 衝突判定をする
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突相手から TargetBlockController コンポーネントを取得する
        TargetBlockController target = collision.gameObject.GetComponent<TargetBlockController>();
        if (target) // もしコンポーネントが取れたら（衝突相手が TargetBlock だったら
        {
            AddScore(target.Score);   // スコアを加算する
        }

        // Killzone にぶつかったらゲームオーバー
        /* === Killzone が Collider だと、ゲームオーバー時に音が鳴ってしまうのでここで処理するのはやめる
        if (collision.gameObject.tag == "KillzoneTag")
        {
            GameOver();
        }
        */

        // 音を鳴らす
        m_audioSource.PlayOneShot(m_sfx);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Killzone が Collider だと音が鳴ってしまうのでここで処理する
        // Killzone の Collider の設定をトリガーモードにしておくこと
        if (collision.gameObject.tag == "KillzoneTag")
        {
            GameOver();
        }
    }

    /// <summary>
    /// 点数を加える
    /// </summary>
    /// <param name="score">加算する点数</param>
    public void AddScore(int score)
    {
        m_score += score;   // 点数を足す
        Debug.Log("Score: " + m_score.ToString());  // Console に出力する

        if (m_scoreText)    // m_scoreText が設定されていたら
        {
            m_scoreText.text = "Score: " + m_score.ToString();  // 表示を更新する
        }

        // 残りのブロック数を集計する（ブロックが壊れる前に集計するので、一つ多いことに注意すること）
        TargetBlockController[] blocks = GameObject.FindObjectsOfType<TargetBlockController>();
        Debug.Log("残り " + blocks.Length + " 個");
        if (blocks.Length < 2)
        {
            Debug.Log("Clear!");
            GameClear();
        }
    }

    /// <summary>
    /// ゲームオーバーにする
    /// </summary>
    void GameOver()
    {
        // ボールを止める
        m_rb2d.velocity = Vector2.zero;

        // メッセージを表示する
        if (m_messageText)
        {
            m_messageText.text = "Game Over";
        }
    }

    /// <summary>
    /// ゲームをクリアした時に呼ばれる
    /// </summary>
    void GameClear()
    {
        // ボールを止める
        m_rb2d.velocity = Vector2.zero;

        // メッセージを表示する
        if (m_messageText)
        {
            m_messageText.text = "Clear!";
        }
    }
}