using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] GameObject car;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            car = other.transform.parent.gameObject;
            car.GetComponent<VehicleController>().SpeedBoost(50);
        }
    }
}
