using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int valueCoin;

    void Start()
    {
        Destroy(gameObject,5f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Spaceship"){
            FindObjectOfType<UIController>().SumCoins(valueCoin);
            Destroy(gameObject);
        }
    }
}
