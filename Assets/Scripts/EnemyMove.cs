using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D enemyRB;
    private AudioSource audioSource;
    [SerializeField] AudioClip Explosion;
    public float speed;
    Vector2 moveAime;
    GameManager gameManager;
    


    private void Awake() 
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyRB = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate() 
    {
        if(!gameManager.isGameOver)
        {
            moveAime = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            enemyRB.MovePosition(moveAime);
        }
        else
        {
            enemyRB.freezeRotation = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            gameManager.Explosion(this.gameObject, Explosion);
        }
    }


}
