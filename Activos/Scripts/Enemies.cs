using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(float j = 1; j<=2; j++){
            float y = 0 + j;
            for(float i = 0; i<=14; i++){
                float x = -7 + i;
                Vector3 position = new Vector3(x,y,0);
                Quaternion rotation = new Quaternion();
                Instantiate(enemyPrefab, position, rotation);
            }
        }
    }

}
