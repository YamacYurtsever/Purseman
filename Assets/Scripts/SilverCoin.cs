using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SilverCoin : MonoBehaviour
{
    [SerializeField] int silverCoinScore = 10;

    GameObject coinDetection;
    Score scoreScript;
    Collider2D coinDetectionCollider;

    void Start()
    {
        coinDetection = GameObject.FindGameObjectWithTag("CoinDetection");
        coinDetectionCollider = coinDetection.GetComponent<Collider2D>();
        scoreScript = GameObject.FindGameObjectWithTag("GameStatus").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == coinDetectionCollider)
        {
            scoreScript.ScoreIncrement(silverCoinScore);
            Destroy(gameObject);
        }
    }
}
