using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDoor : MonoBehaviour
{
    GameObject purseman;
    Collider2D pursemanCollider;
    bool doorIsTrigger;

    void Start()
    {
        purseman = GameObject.FindGameObjectWithTag("Purseman");
        pursemanCollider = purseman.GetComponent<Collider2D>();
        doorIsTrigger = gameObject.GetComponent<Collider2D>().isTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == pursemanCollider)
        {
            while (collision == pursemanCollider)
            {
                doorIsTrigger = false;
            }
        }
    }
}
