using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int score;
    public float speed;
    public Snake head;
    public Snake tail;
    public Vector2 direction;
    public Vector2 newDirection;

    public int maxSize;
    public int currentSize;

    GameObject currentFood;
    public int halfWidth;
    public int halfHeight;

    public Text scoreText;





    private void OnEnable()
    {
        Snake.hit += hit;
    }

    private void Start()
    {
        InvokeRepeating("ToRepeat", 0, speed);
        GenerateFood();
    }

    private void OnDisable()
    {
        Snake.hit -= hit;
    }

    private void Update()
    {
        ChangeDirection();
    }





    private void ToRepeat()
    {
        Move();

        if (currentSize >= maxSize) TailFunction();
        else currentSize++;
    }




    private void Move()
    {
        GameObject tmp;

        Vector2 newPosition = head.transform.position;
        if ((Mathf.Abs(newDirection.x) == 1 && direction.x != -newDirection.x) || (Mathf.Abs(newDirection.y) == 1 && direction.y != -newDirection.y))
            direction = newDirection;
        newPosition += direction;
        if (newPosition.x < -halfWidth) newPosition.x = halfWidth;
        else if (newPosition.x > halfWidth) newPosition.x = -halfWidth;
        else if (newPosition.y < -halfHeight) newPosition.y = halfHeight;
        else if (newPosition.y > halfHeight) newPosition.y = -halfHeight;

        tmp = (GameObject)Instantiate(Resources.Load("BodyPrefab"), newPosition, transform.rotation);
        head.SetNext(tmp.GetComponent<Snake>());
        head = tmp.GetComponent<Snake>();

        return;
    }


    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) newDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) newDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) newDirection = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) newDirection = Vector2.left;
    }




    private void TailFunction()
    {
        Snake tmp = tail;
        tail = tail.GetNext();
        tmp.DestroyTail();
    }





    private void GenerateFood()
    {
        Vector2 newPosition = new Vector2(Random.Range(-(halfWidth-1), halfWidth-1), Random.Range(-(halfHeight-1), halfHeight-1));
        currentFood = (GameObject)Instantiate(Resources.Load("FoodPrefab"), newPosition, Quaternion.identity);
        StartCoroutine(CheckRender(currentFood));
    }


    IEnumerator CheckRender(GameObject IN)
    {
        yield return new WaitForEndOfFrame();
        if(IN.GetComponent<Renderer>().isVisible == false && IN.tag == "Food")
        {
            Destroy(IN);
            GenerateFood();
        }
    }



    void hit(string WhatWasSent)
    {
        if(WhatWasSent == "Food")
        {
            GenerateFood();
            maxSize++;
            score++;
            scoreText.text = score.ToString();
            int tmp = PlayerPrefs.GetInt("HighScore");
            if (score > tmp)
                PlayerPrefs.SetInt("HighScore", score);
        }
        else if(WhatWasSent == "Snake")
        {
            CancelInvoke("ToRepeat");
            Exit();
        }
    }



    public void Exit()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

}



