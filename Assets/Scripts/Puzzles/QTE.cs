using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTE : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private ScoreRef scoreManager;

    [Header("QTE")]
    [SerializeField] private int qteSize;
    [SerializeField] private GameObject circle;
    [SerializeField] private List<Transform> circlePos;

    [SerializeField] private List<Sprite> arrows;

    private Direction[] directions;
    private int idQte;

    [Header("Door")]
    [SerializeField] GameObject door;
    [SerializeField] float doorSpeed;
    private bool isOkay;

    private bool isActivated;



    enum Direction
    {
        Up = 0,
        Left = 1,  
        Right = 2,
        Down = 3,
    }

    private void Awake()
    {
        directions = new Direction[qteSize];

        for (int i = 0; i < directions.Length; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    directions[i] = Direction.Up;
                    circlePos[i].GetComponent<SpriteRenderer>().sprite = arrows[0];
                    break;
                case 1:
                    directions[i] = Direction.Left;
                    circlePos[i].GetComponent<SpriteRenderer>().sprite = arrows[1];
                    break;
                case 2:
                    directions[i] = Direction.Right;
                    circlePos[i].GetComponent<SpriteRenderer>().sprite = arrows[2];
                    break;
                case 3:
                    directions[i] = Direction.Down;
                    circlePos[i].GetComponent<SpriteRenderer>().sprite = arrows[3];
                    break;
                default:
                    break;
            }
        }

        UpdateCirclePos();
        Debug.Log($" QTE : {directions[0]} {directions[1]} {directions[2]} {directions[3]}");
    }
    void CheckInput(Direction dir)
    {
        if (directions[idQte] == dir)
        {
            idQte++;
            if (idQte >= directions.Length) MoveDoor();
            //else Debug.Log($"Step {idQte} completed !!");
            UpdateCirclePos();
        }
        else
        {
            //Debug.Log($"Wrong !!");
            idQte = 0;
            UpdateCirclePos();
        }
    }

    void UpdateCirclePos()
    {
        if (idQte >= circlePos.Count) circle.SetActive(false);
        else circle.transform.position = circlePos[idQte].transform.position;
    }

    void MoveDoor()
    {
        door.GetComponent<Rigidbody>().velocity = new Vector3(0, doorSpeed, 0);
        scoreManager.Instance.AddScore(100);
    }

    public void UpInput(InputAction.CallbackContext context)
    {
        if (!context.started || !isActivated) return;
        CheckInput(Direction.Up);
    }

    public void DownInput(InputAction.CallbackContext context)
    {
        if (!context.started || !isActivated) return;
        CheckInput(Direction.Down);
    }

    public void LeftInput(InputAction.CallbackContext context)
    {
        if (!context.started || !isActivated) return;
        CheckInput(Direction.Left);
    }

    public void RightInput(InputAction.CallbackContext context)
    {
        if (!context.started || !isActivated) return;
        CheckInput(Direction.Right);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuzzleActivation")
        {
            isActivated = true;
        }
    }
}
