using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Spaceship"){
            //FindObjectOfType<UIController>().updateCoins();
            FindObjectOfType<UIController>().Victory();
            Destroy(gameObject);
        }
    }
}
