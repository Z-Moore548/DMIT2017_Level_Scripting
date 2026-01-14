using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    [SerializeField] InputAction accel, stop, steer;

    public float accelValue, stopValue, steerValue, decelerationValue = 1.0f;
    public float currentSpeed, maxSpeed;
    const float ACCELERATION_FACTOR = 5.0f;
    const float STOP_FACTOR = 5.0f;
    const float STEER_FACTOR = 50.0f;

    private Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        OnEnable();

        accel.performed += AccelInput;
        accel.canceled += AccelInput;

        stop.performed += StopInput;
        stop.canceled += StopInput;

        steer.performed += SteerInput;
        steer.canceled += SteerInput;
    }
    void Update()
    {
        currentSpeed -= decelerationValue * Time.deltaTime;
        currentSpeed += accelValue * Time.deltaTime;
        currentSpeed -= stopValue * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);//stops from going over max speed

        if(Mathf.Abs(currentSpeed) > 0.01f)
        {
            float steer = steerValue * Mathf.Sign(currentSpeed);
            transform.Rotate(0, steer * Time.deltaTime, 0);
        }

        Vector3 tmp = transform.forward * currentSpeed;

        tmp.y = rBody.linearVelocity.y;
        rBody.linearVelocity = tmp;
    }

    public void AccelInput(InputAction.CallbackContext c)
    {
        accelValue = c.ReadValue<float>() * ACCELERATION_FACTOR;
    }

    public void StopInput(InputAction.CallbackContext c)
    {
        stopValue = c.ReadValue<float>() * STOP_FACTOR;
    }

    public void SteerInput(InputAction.CallbackContext c)
    {
        steerValue = c.ReadValue<float>() * STEER_FACTOR;
    }

    void OnEnable()
    {
        accel.Enable();
        stop.Enable();
        steer.Enable();
    }
}
