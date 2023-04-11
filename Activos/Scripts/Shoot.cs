using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 2;
    //[SerializeField] private GameObject playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * Vector3.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")){
            Destroy(gameObject);
        }
        if(collision.CompareTag("Help")){
            Destroy(gameObject);
        }
    }

}
