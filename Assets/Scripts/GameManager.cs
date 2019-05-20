using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI

public class GameManager : MonoBehaviour
{
    [SerializeField] Text m_scoreText;
    int m_score = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddScore(int score)
    {
        m_score += score;
        Debug.Log("Score: " + m_score.ToString());

        m_scoreText.text = "Score: " + m_score.ToString();

        TargetBlockController[] blocks = GameObject.FindObjectsOfType<TargetBlockController>();
        Debug.Log("残り " + blocks.Length + " 個");
    }
}
