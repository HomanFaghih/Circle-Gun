using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int hearts;
    [SerializeField] List<GameObject> heartsUI = new List<GameObject>();
    public AudioClip explosion;
    GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
    }

    void Damage()
    {
        Destroy(heartsUI[hearts - 1]);
        hearts--;
        if (hearts == 0)
        {
            gameManager.GameOver();
        }
    }
}
