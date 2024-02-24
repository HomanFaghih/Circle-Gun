using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    private GameObject player;
    private int score;
    private AudioSource audioSource;
    [SerializeField] GameObject particle;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI gameOverUI;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] AudioClip playerExplosion;
    
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Start() 
    {
        Cursor.visible = false;
        player = GameObject.Find("Player");
        score = 0;
    }
    public void GameOver()
    {
        Cursor.visible = true;
        isGameOver = true;
        //Destroy(player);
        Explosion(player, playerExplosion);
        gameOverCanvas.SetActive(true);
        gameOverUI.text = $"Your score is {score}";
    }

    public void Explosion(GameObject objectToBoom, AudioClip ExplotionSound)
    {
        audioSource.PlayOneShot(ExplotionSound);
        Instantiate(particle, objectToBoom.transform.position, Quaternion.identity);
        CameraShake.cameraShake.ShakeCamera();
        Destroy(objectToBoom);
        if(objectToBoom.CompareTag("Enemy"))
        {
            score ++; 
            scoreUI.text = $"Score: {score}";
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
