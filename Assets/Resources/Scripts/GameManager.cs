using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;      // Singleton instance
    private int score = 0;                          // Score
    private int coin = 0;                           // Coin
    private TextMeshProUGUI scoreText;              // Text component to show score
    private Shape shapePlayer;                      // Player's shape script
    private GameObject resButton;                   // Restart Button.

    #region Unity Callbacks
    void Awake()
    {
        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        // Make the game portrait only
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Initialization
    void Start()
    {
        shapePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Shape>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        resButton = GameObject.Find("RestartButton");
        resButton.SetActive(false);
        //Every second, game will speed up
        InvokeRepeating("SpeedUp", ConfigManager.instance.gameSpeedUpStartingSecond, ConfigManager.instance.gameSpeedUpInterval);
    }

    #endregion

    public void MorphShape(float toBeAdded)
    {
        shapePlayer.Morph(toBeAdded);
    }

    public void BakeShapesCollider()
    {
        shapePlayer.BakeCollider();
    }

    // To add score
    public void AddScore(int toBeAdded)
    {
        score += toBeAdded;
        scoreText.text = "Score: " + score;
        StartCoroutine("GlowScore");

    }

    // Speeds up the game
    private void SpeedUp()
    {
        ConfigManager.instance.scrollSpeed += ConfigManager.instance.gameSpeedUpIncreaseRate;
        ConfigManager.instance.spawnRate += ConfigManager.instance.gameSpeedUpIncreaseRate;
    }

    public void GameOver()
    {
        resButton.SetActive(true);
        scoreText.text = "Game Over!\n" + "Score: " + score;
        ConfigManager.instance.scrollSpeed = 0;
        ConfigManager.instance.gameSpeedUpIncreaseRate = 0;

    }

    public void AddCoin()
    {
        coin++;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Glow the score label
    IEnumerator GlowScore()
    {
        float dilationCoefficient = 0;

        while (dilationCoefficient < .3f)
        {
            dilationCoefficient = Mathf.MoveTowards(dilationCoefficient, .35f, Time.deltaTime * .25f);

            scoreText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, dilationCoefficient);
            scoreText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilationCoefficient);
            yield return null;
        }

        while (dilationCoefficient > 0)
        {
            dilationCoefficient = Mathf.MoveTowards(dilationCoefficient, 0, Time.deltaTime * .35f);
            scoreText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, dilationCoefficient);
            scoreText.fontSharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilationCoefficient);
            yield return null;
        }
    }
}