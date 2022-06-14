using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    public float elapsedTime;
    public float time;
    public bool timeStop;

    public void Start () {
        gameTime = 15;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    public void EndGame() 
    {
        Debug.Log("GameOver");
        Restart();
    }

    void Restart() {
        SceneManager.LoadScene("Menu");
        Debug.Log("scene loaded");
        Destroy (GameObject.Find("Music"));
        ScoreScript.score = 0;
    }

    void FixedUpdate()
    {
        if (timeStop) {
        }
        else {
            elapsedTime += Time.deltaTime;
            time = gameTime - elapsedTime;
            timerSlider.value = time;
            if (time <= 0.05f) {
                EndGame();
            }
        }
    }


    public void SetGameTime() {
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        elapsedTime = 0f;
    }

    public void LoadNext() {
        int index = Random.Range(1,16);
        SceneManager.LoadScene(index);
        Debug.Log("scene loaded");
    }
}
