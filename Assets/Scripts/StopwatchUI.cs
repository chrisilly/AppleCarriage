using TMPro;
using UnityEngine;

public class StopwatchUI : MonoBehaviour
{
    public TMP_Text stopWatchText;
    private float currentTime;
    public bool gameRunning = true;
    int minutes;
    int seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0f;
        UpdateDisplay();
    }

    public void ResetStopwatch()
    {
        currentTime = 0f;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        minutes = (int) (currentTime / 60);
        seconds = (int) (currentTime % 60);

        stopWatchText.text = $"Your time is {minutes} : {seconds}";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameRunning)
        {
            currentTime += Time.deltaTime;
            UpdateDisplay();
        }
        else
        {
            stopWatchText.text = $"Game over! Your time was: {minutes} : {seconds}";
        }
    }
}
