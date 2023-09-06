using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTE : MonoBehaviour
{
    [SerializeField] private int qteSize;
    [SerializeField] private GameObject circle;
    [SerializeField] private List<Transform> circlePos;

    private Direction[] directions;
    private int idQte;

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
                    break;
                case 1:
                    directions[i] = Direction.Left;
                    break;
                case 2:
                    directions[i] = Direction.Right;
                    break;
                case 3:
                    directions[i] = Direction.Down;
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
            if (idQte >= directions.Length) Debug.Log($"Step {idQte} completed !! Puzzle completed !!");
            else Debug.Log($"Step {idQte} completed !!");
            UpdateCirclePos();
        }
        else
        {
            Debug.Log($"Wrong !!");
            idQte = 0;
            UpdateCirclePos();
        }
    }

    void UpdateCirclePos()
    {
        if (idQte >= circlePos.Count) circle.SetActive(false);
        else circle.transform.position = circlePos[idQte].transform.position;
    }

    public void UpInput(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        CheckInput(Direction.Up);
    }

    public void DownInput(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        CheckInput(Direction.Down);
    }

    public void LeftInput(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        CheckInput(Direction.Left);
    }

    public void RightInput(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        CheckInput(Direction.Right);
    }
}
