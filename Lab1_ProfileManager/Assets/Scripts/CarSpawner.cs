using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject grayCar, greenCar, purpleCar;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        if(gameManager.CarSelected == "Gray")
        {
            Instantiate(grayCar, transform.position, transform.rotation);
        }
        if(gameManager.CarSelected == "Green")
        {
            Instantiate(greenCar, transform.position, transform.rotation);
        }
        if(gameManager.CarSelected == "Purple")
        {
            Instantiate(purpleCar, transform.position, transform.rotation);
        }
    }
}
