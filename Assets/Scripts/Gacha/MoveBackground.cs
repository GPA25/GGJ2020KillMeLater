using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private enum DIR
    {
        Right,
        Down,
        Left,
        Up
    }

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float moveX;

    [SerializeField]
    private float moveY;

    private Vector3 originalPos;
    private DIR moveDir;
    private IEnumerator moveCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;

        moveCoroutine = MoveCoroutine();
        StartCoroutine(moveCoroutine);
    }

    private IEnumerator MoveCoroutine()
    {
        moveDir = DIR.Right;
        while (true)
        {
            switch (moveDir)
            {
                case DIR.Right:
                    {
                        float newX = transform.position.x + Time.deltaTime * moveSpeed;
                        if (newX >= originalPos.x + moveX)
                        {
                            newX = originalPos.x + moveX;
                            moveDir = DIR.Down;
                        }
                        transform.position = new Vector3(newX, transform.position.y);
                    }
                    break;
                case DIR.Down:
                    {
                        float newY = transform.position.y - Time.deltaTime * moveSpeed;
                        if (newY <= originalPos.y - moveY)
                        {
                            newY = originalPos.y - moveY;
                            moveDir = DIR.Left;
                        }
                        transform.position = new Vector3(transform.position.x, newY);
                    }
                    break;
                case DIR.Left:
                    {
                        float newX = transform.position.x - Time.deltaTime * moveSpeed;
                        if (newX <= originalPos.x - moveX)
                        {
                            newX = originalPos.x - moveX;
                            moveDir = DIR.Up;
                        }
                        transform.position = new Vector3(newX, transform.position.y);

                    }
                    break;
                case DIR.Up:
                    {
                        float newY = transform.position.y + Time.deltaTime * moveSpeed;
                        if (newY >= originalPos.y + moveY)
                        {
                            newY = originalPos.y + moveY;
                            moveDir = DIR.Right;
                        }
                        transform.position = new Vector3(transform.position.x, newY);
                    }
                    break;
            }
            yield return null;
        }
    }

    public void StopMove()
    {
        StopCoroutine(moveCoroutine);
    }
}
