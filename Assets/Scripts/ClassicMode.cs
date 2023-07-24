using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClassicMode : MonoBehaviour
{
    private GameManager gameManager;
    public Text gameOverText;
    public Image fadeImage;

    public int lifeCount = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public bool gameOver;

    private void Start()
    {
        gameOver = false;
        UpdateLivesUI();
        gameManager = GameManager._instance;
    }

    public void LoseLife()
    {
        if (!gameOver)
        {
            lifeCount--;

            // Check if all lives are lost
            if (lifeCount <= 0)
            {
                gameOver = true;
                gameManager.blade.enabled = false;
                gameManager.spawner.enabled = false;
                gameOverText.enabled = true;
                gameOverText.text = $"Game Over\nYour score is {gameManager.score}";
            }
        }
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        life1.SetActive(lifeCount >= 1);
        life2.SetActive(lifeCount >= 2);
        life3.SetActive(lifeCount >= 3);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!gameOver && collision.CompareTag("Fruit"))
        {
            MeshRenderer whole_fruit = collision.gameObject.GetComponentInChildren<MeshRenderer>();
            if (whole_fruit.CompareTag("Whole"))
            {
                LoseLife();
                Destroy(collision.gameObject);
            }
        }
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("ModeSelection");
    }
}