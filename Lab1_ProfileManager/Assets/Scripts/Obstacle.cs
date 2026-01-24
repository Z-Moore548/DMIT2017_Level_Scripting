using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject car;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            car = other.transform.parent.gameObject;
            car.GetComponent<VehicleController>().SlowBoost(10);
        }
    }
}
