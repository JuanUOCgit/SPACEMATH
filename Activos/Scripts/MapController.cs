using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MapController : MonoBehaviour
{
    private float time = 5;
    [SerializeField] TMP_Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "MISSION START IN " +time.ToString("f0");
        if(time<=0){
            //timeText.text = "0";
            SceneManager.LoadScene("Scene1");
        }
    }
}
