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
    }

    void FixedUpdate()
    {
        if (timeStop) {
        }
        else {
            elapsedTime += Time.deltaTime;
            time = gameTime - elapsedTime;
            timerSlider.value = time;
        }
    }


    public void SetGameTime() {
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        elapsedTime = 0f;
    }
}
