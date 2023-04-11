using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    [SerializeField] private Transform shootStart;
    [SerializeField] private GameObject shoot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right") && transform.position.x < 8){
            transform.position += Time.deltaTime * Vector3.right * speed;
        }
        if(Input.GetKey("left") && transform.position.x > -8){
            transform.position += Time.deltaTime * Vector3.left * speed;
        }
        if(Input.GetKeyDown("space")){
            //Debug.Log("DISPARO");
            Shoot();
        } 
    }

    private void Shoot(){
        Instantiate(shoot,shootStart.position,shootStart.rotation);
    }
}
