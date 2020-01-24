using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerData playerData;
    public Text scoreText;
    public Text loseText;

    void Start()
    {
        loseText.text = "YOU LOST!";
        loseText.gameObject.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score: " + playerData.score;

        if (playerData.didLose)
        {
            Time.timeScale = 0;
            loseText.gameObject.SetActive(true);
        }
    }
}
