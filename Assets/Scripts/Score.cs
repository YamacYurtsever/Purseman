using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject scoreAlertCanvasPrefab;

    int currentScore = 0, currentHighScore = 0;
    int currentCash;
    int cashOfLevel;

    GameObject score, highScore;
    GameObject cash;
    GameObject scoreAlertPrefab, scoreAlert;
    TextMeshProUGUI scoreText, highScoreText;
    TextMeshProUGUI cashText;
    TextMeshProUGUI scoreAlertText;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        scoreText = score.GetComponent<TextMeshProUGUI>();
        highScore = GameObject.FindGameObjectWithTag("HighScore");
        highScoreText = highScore.GetComponent<TextMeshProUGUI>();
        cash = GameObject.FindGameObjectWithTag("Cashes");
        cashText = cash.GetComponent<TextMeshProUGUI>();
        scoreAlertPrefab = scoreAlertCanvasPrefab.transform.GetChild(0).gameObject;
        scoreAlertText = scoreAlertPrefab.GetComponent<TextMeshProUGUI>();
    }

    public void ScoreIncrement(int addedScore)
    {
        currentScore += addedScore;
        scoreText.text = currentScore.ToString();
        if (currentHighScore < currentScore)
        {
            currentHighScore = currentScore;
            highScoreText.text = currentHighScore.ToString();
        }
    }

    public void CashIncrement(int addedCash)
    {
        currentCash += addedCash;
        cashText.text = currentCash.ToString();
    }

    public void ScoreAlert(int scoreGiven, GameObject theObject)
    {
        scoreAlertText.text = scoreGiven.ToString();
        scoreAlert = Instantiate(scoreAlertCanvasPrefab, new Vector2(theObject.transform.position.x, theObject.transform.position.y), Quaternion.identity) as GameObject;
        cashOfLevel++;
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(scoreAlert);
    }
}
