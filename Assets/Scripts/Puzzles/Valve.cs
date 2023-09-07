using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Valve : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Reference<Score> scoreManager;

    [Header("Objects")]
    //[SerializeField] GameObject wheel1;
    [SerializeField] GameObject wheel2;
    [SerializeField] GameObject wheel3;
    [SerializeField] GameObject wheelref;

    [Header("Values")]
    [SerializeField] float speed;
    [SerializeField] Vector2 randomStartPosition;
    private int currentValve;
    [SerializeField] float tolerance;

    [Header("Door")]
    [SerializeField] GameObject door;
    [SerializeField] float doorSpeed;
    private bool isOkay;

    private bool isActivated;


    private void Awake()
    {
        //wheel1.transform.Rotate(0, 0,Random.Range(randomStartPosition.x, randomStartPosition.y) * speed);
        wheel2.transform.Rotate(0, 0,Random.Range(randomStartPosition.x, randomStartPosition.y) * speed);
        wheel3.transform.Rotate(0, 0,Random.Range(randomStartPosition.x, randomStartPosition.y) * speed);
        wheelref.transform.Rotate(0, 0,Random.Range(randomStartPosition.x, randomStartPosition.y) * speed);
        isActivated = true;
        currentValve = 1;
    }

    void Update()
    {
        
        if(/*CheckAngle(wheel1) && */CheckAngle(wheel2) && CheckAngle(wheel3) && !isOkay)
        {
            isOkay = true;
            MoveDoor();
        }
    }

    void RotateValve(GameObject valve, float value)
    {
        if (value < 0)
        {
            valve.transform.Rotate(0, 0, -value * speed * Time.deltaTime);
        }
        else if (value > 0)
        {
            valve.transform.Rotate(0, 0, -value * speed * Time.deltaTime);
        }
    }

    bool CheckAngle(GameObject wheel)
    {
        Debug.Log(wheel.transform.eulerAngles.z + " " + wheelref.transform.eulerAngles.z);
        if (wheel.transform.eulerAngles.z > wheelref.transform.eulerAngles.z - tolerance && wheel.transform.eulerAngles.z < wheelref.transform.eulerAngles.z + tolerance) return true;
        return false;
    }

    void MoveDoor()
    {
        door.GetComponent<Rigidbody>().velocity = new Vector3(0, doorSpeed, 0);
        scoreManager.Instance.AddScore(100);
    }


    public void MovementInput(InputAction.CallbackContext context)
    {
        if (isOkay || !isActivated) return;
        float value = context.ReadValue<float>();

        switch (currentValve)
        {
            case 0:
                //RotateValve(wheel1, value);
                break;
            case 1:
                RotateValve(wheel2, value);
                break;
            case 2:
                RotateValve(wheel3, value);
                break;
            default:
                break;
        }

    }

    public void LeverLeftInput(InputAction.CallbackContext context)
    {
        if (!isActivated) return;


        if(currentValve == 1) 
        {
            currentValve = 2;
        }
        else
        {
            currentValve = 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuzzleActivation")
        {
            isActivated = true;
        }
    }
}
