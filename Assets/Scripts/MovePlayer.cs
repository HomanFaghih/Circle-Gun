using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    [SerializeField] int speed;
    [SerializeField] Vector2 mousePos;
    [SerializeField] GameObject mousePointer;
    [SerializeField] GameObject firePointer;
    Vector2 direction;
    GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!gameManager.isGameOver)
        {
            ControlPlayer();
        }
    }

    private void Update() 
    {
        //fire
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }    
    }


    void ControlPlayer()
    {
        //move with keyboard
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime, Space.World);

        //limit player move
        SetWalls();


        //move mouse for gun
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
        mousePointer.transform.position = mousePos;
    }

    void Fire()
    {
        GameObject newBullet = ObjectPool.Instance.FindABullet();
        if(newBullet != null)
        {
            print("avalable");
            newBullet.transform.position = firePointer.transform.position;
            newBullet.transform.rotation = firePointer.transform.rotation;
            newBullet.SetActive(true);
        }
        else
        {
            print("not avalable!");
        }
    }

    void SetWalls()
    {
        if(transform.position.x > 7.5 )
        {
            transform.position = new Vector2(7.5f, transform.position.y);
        }
        else if(transform.position.x < -7.5 )
        {
            transform.position = new Vector2(-7.5f, transform.position.y);
        }
        if(transform.position.y > 3.8 )
        {
            transform.position = new Vector2(transform.position.x, 3.8f);
        }
        else if(transform.position.y < -3.8 )
        {
            transform.position = new Vector2(transform.position.x, -3.8f);
        }

    }
}
