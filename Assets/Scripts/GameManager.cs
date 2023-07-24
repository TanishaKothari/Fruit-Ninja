using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Image fadeImage;

    public static GameManager _instance;

    [HideInInspector] public Blade blade;
    [HideInInspector] public Spawner spawner;
    public int score;

    private void Awake()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        } 
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Update () 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "ClassicMode" || SceneManager.GetActiveScene().name == "ZenMode" ||SceneManager.GetActiveScene().name == "ArcadeMode"){
            blade = FindObjectOfType<Blade>();
            spawner = FindObjectOfType<Spawner>();

            GameObject scoretext = GameObject.Find("Score");
            scoreText = scoretext.GetComponent<Text>();
            GameObject gameovertext = GameObject.Find("GameOverText");
            gameOverText = gameovertext.GetComponent<Text>();
            fadeImage = FindObjectOfType<Image>();

            NewGame();
        }
    }

    public void NewGame()
    {
        Time.timeScale = 1f;

        ClearScene();

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        gameOverText.enabled = false;
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits) {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs) {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;
        gameOverText.enabled = true;
        gameOverText.text = $"Game Over\nYour score is {score}";

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        // Fade to white
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        elapsed = 0f;

        // Fade back in
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
    }
}