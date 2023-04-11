using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject settings;


    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text operationText;

    private static int updateCoins = 0;
    public static int updateLives = 3;
    private static int updateLevel = 1;

    public float time;
    public int sum;
    public int res;
    public char mm;
    public int n1;
    public int n2;
    public bool onPause;
    public bool check2;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ESTAS EN EL NIVEL:"+ updateLevel);

        //updateCoins = 0;
        //updateLives = 3;
        //updateLevel = 1;
        Operation();
        //Debug.Log("VIDAS " + updateLives);
        livesText.text = "LIVES " + updateLives.ToString();
        coinsText.text = "COINS " + updateCoins.ToString();
        levelText.text = updateLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time.ToString("f0");
        if(time<=0){
            timeText.text = "0";
            gameOver.SetActive(true);
        }

        if(Input.GetKey(KeyCode.P)){
            Pause();
        }
    }

    public void SumCoins(int coins){
        updateCoins += coins;
        coinsText.text = "COINS " + updateCoins.ToString();
    }

    public void Sumlives(int lives){
        //Debug.Log("VIDAS " +updateLives);
        //Debug.Log("VALOR " +lives);
        switch (lives)
        {
        case 0:
            break;
        case 1:
            updateLives++;
            break;
        case -1:
            updateLives--;
            break;
        default:
            break;
        }
        livesText.text = "LIVES " + updateLives.ToString();

    }

    public void SumLevel(){
        ++updateLevel;
        levelText.text = updateLevel.ToString();
    }

    public void Gameover(){
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void Victory(){
        Time.timeScale = 0;
        victory.SetActive(true);
    }

    public void Settings(){
        settings.SetActive(true);
    }

    public void BackSettings(){
        settings.SetActive(false);
    }

    public void Pause(){
        if(onPause){
            pause.SetActive(true);
            Time.timeScale = 0;
            onPause = false;
        }else{
            pause.SetActive(false);
            Time.timeScale = 1;
            onPause = true;
        }
    }

    public void Continue(){
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
        updateCoins = 0;
        updateLives = 3;
        updateLevel = 1;
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Intro(){
        SceneManager.LoadScene("Intro");
    }

    public void NextLevel(){
        SumLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        time = 45;
    }

    public void Operation(){
        //Debug.Log("NIVEL"+updateLevel);
        if(updateLevel<=5)
        {
            n1 = Random.Range(0,9);
            n2 = Random.Range(0,9);
            sum = n1 + n2;
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?";            
        }
        if(updateLevel>=6 && updateLevel<=10){
            do{
                n1 = Random.Range(0,9);
                n2 = Random.Range(0,9);
            }while(n1<n2);
            res = n1 - n2;
            operationText.text = n1.ToString() + " - " + n2.ToString() + " = ?";            
        }

        /*if(updateLevel>=7 && updateLevel<=9){
            n1 = Random.Range(0,30);
            multi = Random.Range(1,5);

            for(int i=1; i<=5; i++) {
                switch (i)
                {
                case 1:
                    operationText.text = n1.ToString();
                    n1+=multi;
                    break;
                case 2:
                    operationText.text += n1.ToString();
                    n1+=multi;                    
                    break;
                case 3:
                    operationText.text += n1.ToString() + " ? ";
                    n1+=multi;
                    break;
                case 4:
                    operationText.text += n1.ToString();
                    n1+=multi;                    
                    break;
                case 5:
                    operationText.text += n1.ToString();
                    n1+=multi;
                    break;
                default:
                    break;
                }
            }
        }*/

        if(updateLevel==11){
            SceneManager.LoadScene("TheEnd");
        }
    }
    
    public void updateOperation(int number1){
        if(updateLevel<=5)
        {
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = " + number1;
        }
        else if(updateLevel>5){
                operationText.text = n1.ToString() + " - " + n2.ToString() + " = " + number1;
        }

    }

    public void updateOperation2a(int number2){
        if(updateLevel<=5)
        {
        operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?"+ number2;
        }
        else if(updateLevel>5){
                operationText.text = n1.ToString() + " - " + n2.ToString() + " = ?"+ number2;
        }
        check2 = true;
    }

    public void updateOperation2b(int number3, int number2){
        if(updateLevel<=5)
        {
        operationText.text = n1.ToString() + " + " + n2.ToString() + " = " + number2 + number3;
        }
        else if(updateLevel>5){
                operationText.text = n1.ToString() + " -" + n2.ToString() + " = " + number2 + number3;
        }
    }

           /*switch (updateLevel)
        {
        case 1:
            n1 = Random.Range(0,9);
            n2 = Random.Range(0,9);
            sum = n1 + n2;
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?";            
            break;
        case 5:
            do{
                n1 = Random.Range(0,9);
                n2 = Random.Range(0,9);
            }while(n1<n2);
            res = n1 - n2;
            operationText.text = n1.ToString() + " - " + n2.ToString() + " = ?";            
            break;
        }*/
    }
        /*//if(currentlevel<=5){  
            n1 = Random.Range(0,9);
            n2 = Random.Range(0,9);
            sum = n1 + n2;
            //Debug.Log(sum);
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?";
        /*}*/
        
        /*public void addition(n1,n2){
            sum = n1 + n2;
            operationText.text = n1.ToString() + " + " + n2.ToString() + " = ?";
        }

        public void subtraction(n1,n2){
            sum = n1 - n2;
            operationText.text = n1.ToString() + " - " + n2.ToString() + " = ?";
        }*/
        /*
        public void mayorOmenor(){

            n1 = Random.Range(0,99);
            n2 = Random.Range(0,99);

            if(n1 > n2){
                res = ">";
            }else if(n1 < n2){
                res = "<";
            }else if(n1 = n2){
                res = "=";
            }

            operationText.text = n1.ToString() + " ? " + n2.ToString();
        }

        public void secuences(){
            n1 = Random.Range(0,30);
            multi = Random.Range(1,5);

            for(int i=1; i<=5; i++) {
                if(i==1){
                    operationText.text = n1.ToString();
                    n1+=multi;
                }
                if(i==2){
                    operationText.text += n1.ToString();
                    n1+=multi;
                }
                if(i==3){
                    operationText.text += n1.ToString() + " ? ";
                    n1+=multi;
                }
                if(i==4){
                    operationText.text += n1.ToString();
                    n1+=multi;
                }
                if(i==5){
                    operationText.text += n1.ToString();
                    n1+=multi;
                }
            }

        }

        public void geometrics(){

        }


        else if(currentlevel<=10){
            res(num1,num2);
        }
        else if(currentlevel<=15){
            mayorOmenor();
        }
        else if(currentlevel<=20){
            secuences();
        }
        else if(currentlevel<=25){
            geometrics();
        }*/

    



