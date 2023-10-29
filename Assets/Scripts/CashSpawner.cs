using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawner : MonoBehaviour
{
    [SerializeField] GameObject cashPrefab;

    void Start()
    {
        StartCoroutine(cashSpawner());
    }

    IEnumerator cashSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 25f));
            GameObject cash = Instantiate(cashPrefab, new Vector2(0, -10), Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(5f);
            Destroy(cash);
        }
    }
}
