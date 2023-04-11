using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;

    private void OnTriggerEnter2D(Collider2D collision) {
        powerUp.SetActive(true);
        powerUp.transform.SetParent(null);
        Destroy(gameObject);
    }
}
