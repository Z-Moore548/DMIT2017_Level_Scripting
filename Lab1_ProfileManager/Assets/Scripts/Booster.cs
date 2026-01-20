using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] GameObject car;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            car.GetComponent<VehicleController>().SpeedBoost(10);
        }
    }
}
