using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool gameRunning;
    bool won;
    bool lost;
    public GameObject carController;
    public GameObject fuelCans;
    public TMP_Text endText;
    AddFuel[] canChildren;
    StopwatchUI stopwatchUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopwatchUI = GetComponent<StopwatchUI>();
        gameRunning = true;
        canChildren = fuelCans.GetComponentsInChildren<AddFuel>();
        endText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        stopwatchUI.gameRunning = gameRunning;
        if (gameRunning)
        {
            if (carController.transform.position.x > 20)
            {
                lost = false;
                gameRunning = false;
            }
            if (carController.GetComponent<CarController>().fuel <= 0)
            {
                lost = true;
                gameRunning = false;
            }
            if (carController.transform.rotation.x >= 145)
            {
                lost = true;
                gameRunning = false;
            }
        }
        else
        {
            GameReset();
        }
    }

    void GameReset()
    {
        endText.enabled = true;
        if (lost)
        {
            endText.text = "Uh oh, You Lost!";
        }
        else
        {
            endText.text = "Congrats! You won!";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            endText.enabled = false;
            lost = false;
            stopwatchUI.ResetStopwatch();
            carController.GetComponent<CarController>().Reset();
            foreach (var can in canChildren)
            {
                can.Reset();
            }
            gameRunning = true;
        }
    }
}
