using TMPro;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float fuel = 1;
    public float fuelconsumption = 0.1f;
    public Rigidbody2D carController;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float speed = 100;
    private float acceleration = 5f;
    //private float currentSpeed = 5f;
    private float carTorque = 10;
    private float movement;

    public float fuelCollected = 0;

    public UnityEngine.UI.Image image;
    public TMP_Text text;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        image.fillAmount = fuel;

        text.text = $"Fuel Cans Collected: {fuelCollected}";
    }

    private void FixedUpdate()
    {
        if(fuel > 0)
        {
            backTire.AddTorque(-movement *  speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            carController.AddTorque(-movement * carTorque * Time.fixedDeltaTime);
        }

        fuel -= fuelconsumption * Time.fixedDeltaTime * Mathf.Abs(movement);
        Mathf.Clamp(fuel, 0, 1);
    }

    public void Reset()
    {
        ResetRigidbody(backTire);
        ResetRigidbody(frontTire);
        ResetRigidbody(carController);

        transform.position = new Vector3(-45, 0, 0);
        transform.rotation = Quaternion.identity;
        fuel = 1;
        fuelCollected = 0;
    }

    void ResetRigidbody(Rigidbody2D rb)
    {
        rb.angularVelocity = 0;
        rb.linearVelocity = Vector2.zero;
        rb.totalForce = Vector2.zero;
        rb.totalTorque = 0;
    }
}
