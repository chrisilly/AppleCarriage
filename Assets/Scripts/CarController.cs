using UnityEngine;

public class CarController : MonoBehaviour
{
    public float fuel = 1;
    public float fuelconsumption = 0.1f;
    public Rigidbody2D carController;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float maxSpeed = 20;
    private float acceleration = 5f;
    private float currentSpeed = 5f;
    private float carTorque = 10;
    private float movement;

    public float fuelCollected = 0;

    public UnityEngine.UI.Image image;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        image.fillAmount = fuel;

        if(movement != 0 && fuel > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        if(fuel > 0)
        {
            backTire.AddTorque(-movement * currentSpeed * Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * currentSpeed * Time.fixedDeltaTime);
            carController.AddTorque(-movement * carTorque * Time.fixedDeltaTime);
        }

        fuel -= fuelconsumption * Time.fixedDeltaTime * Mathf.Abs(movement);
        Mathf.Clamp(fuel, 0, 1);
    }
}
