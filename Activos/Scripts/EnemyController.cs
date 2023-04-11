using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject num;
    [SerializeField] private GameObject coin;

    public Sprite E0;
    public Sprite E1;
    public Sprite E2;
    public Sprite E3;
    public Sprite E4;
    public Sprite E5;

    // Start is called before the first frame update
    void Start()
    {
        int ramdonNumber = Random.Range(0,5);

        switch (ramdonNumber)
        {
        case 0:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = E0;
            break;
        case 1:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = E1;
            break;
        case 2:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = E2;
            break;
        case 3:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = E3;
            break;
        case 4:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = E4;
            break;
        case 5:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = E5;
            break;
        default:
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        num.SetActive(true);
        num.transform.SetParent(null);
        coin.SetActive(true);
        coin.transform.SetParent(null);
        Destroy(gameObject);
    }

}
