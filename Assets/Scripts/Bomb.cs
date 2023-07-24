using UnityEngine;
using UnityEngine.SceneManagement;
public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            if (SceneManager.GetActiveScene().name == "ClassicMode"){
                FindObjectOfType<ClassicMode>().gameOver = true;
            }
            FindObjectOfType<GameManager>().Explode();
        }
    }
}