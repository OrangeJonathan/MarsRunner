using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float horizontalMoveSpeed = 4.0f;
    public bool isJumping = false;
    public bool isFalling = false;
    public bool isPlaying = true;
    public GameObject playerObject;


    void Start()
    {
        moveSpeed = 8.0f;
        if (!isPlaying) moveSpeed = 0.5f;
    }
    void Update()
    {
        if (!isPlaying) {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);
            return;
        }

        moveSpeed = 8.0f + (LevelDistance.distanceRun / (99 - (LevelDistance.distanceRun / 90)));
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > LevelBoundry.leftSide)
            {
                transform.Translate(horizontalMoveSpeed * Time.deltaTime * Vector3.left, Space.World);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < LevelBoundry.rightSide)
            {
                transform.Translate(horizontalMoveSpeed * Time.deltaTime * Vector3.right, Space.World);
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (!isJumping && !isFalling)
            {
                playerObject.GetComponent<Animator>().Play("Jumping");
                StartCoroutine(Jump());
            }
        }

    }

    IEnumerator Jump()
    {
        isJumping = true;
        float jumpHeight = 3f;
        while (jumpHeight > 0)
        {
            transform.Translate(Vector3.up * 0.1f);
            jumpHeight -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        isJumping = false;
        isFalling = true;
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        float fallHeight = 3f;
        while (fallHeight > 0)
        {
            transform.Translate(Vector3.down * 0.1f);
            fallHeight -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        isFalling = false;
        playerObject.GetComponent<Animator>().Play("Walking");
    }
}
