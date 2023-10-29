using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cash : MonoBehaviour
{
    [SerializeField] int cashScore = 200;

    int cashIncrement = 1;

    GameObject coinDetection;
    Collider2D coinDetectionCollider;
    Score scoreScript;

    void Start()
    {
        coinDetection = GameObject.FindGameObjectWithTag("CoinDetection");
        coinDetectionCollider = coinDetection.GetComponent<Collider2D>();
        scoreScript = GameObject.FindGameObjectWithTag("GameStatus").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == coinDetectionCollider)
        {
            scoreScript.ScoreIncrement(cashScore);
            scoreScript.CashIncrement(cashIncrement);
            scoreScript.ScoreAlert(cashScore, gameObject);
            Destroy(gameObject);
        }
    }
}
