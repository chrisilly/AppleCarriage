using UnityEngine;

public class AddFuel : MonoBehaviour
{
    public CarController carController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        carController.fuel += 0.3f;
        carController.fuelCollected++;
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }

}
