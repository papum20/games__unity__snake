using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
public class BorderGenerator : MonoBehaviour
{

    //Singleton
    public static BorderGenerator mapGeneration;


    [SerializeField]
    public int rows, cols;

    Transform tidyParent;





    private void Awake()
    {
        mapGeneration = this;
    }


    private void Start()
    {
        tidyParent = GameObject.Find("tidyParent").transform;
    }



    private void Update()
    {
        if (!Application.isPlaying)
            Spawner();
    }



    void Spawner()
    {
        if (tidyParent != null) DestroyImmediate(tidyParent.gameObject);
        tidyParent = new GameObject("tidyParent").transform;

        for(int y = 0; y < rows; y++)
        {
            GameObject.Instantiate(Resources.Load("BorderPrefab"), new Vector2(0, y), Quaternion.identity, tidyParent);
            GameObject.Instantiate(Resources.Load("BorderPrefab"), new Vector2(cols-1, y), Quaternion.identity, tidyParent);
        }
        for (int x = 1; x < cols-1; x++)
        {
            GameObject.Instantiate(Resources.Load("BorderPrefab"), new Vector2(x, 0), Quaternion.identity, tidyParent);
            GameObject.Instantiate(Resources.Load("BorderPrefab"), new Vector2(x, rows-1), Quaternion.identity, tidyParent);
        }

    }



}








/*
[SerializeField]
int rows, cols;
[SerializeField]
float size;

//    Transform tidyParent;




void Start()
{
//        tidyParent = GameObject.Find("tidyParent").transform;
    Generator();
}


private void Update()
{
//        Generator();
}





void Generator()
{
//        if (tidyParent != null) DestroyImmediate(tidyParent.gameObject);
//        tidyParent = new GameObject("tidyParent").transform;


    float rectangleHalfBase = Mathf.Ceil((float)cols / 2) - ((cols % 2 == 0) ? 0.5f : 1);
    float rectangleHalfHeight = Mathf.Ceil((float)rows / 2) - ((rows % 2 == 0) ? 0.5f : 1);

    for (int i = 0; i < rows; i++)
    {
        Vector2 tile1 = new Vector2(-rectangleHalfBase * size, (rectangleHalfHeight - i) * size);
        Vector2 tile2 = new Vector2(rectangleHalfBase * size, (rectangleHalfHeight - i) * size);
        GameObject.Instantiate(Resources.Load("BorderPrefab"), tile1, Quaternion.identity);
        GameObject.Instantiate(Resources.Load("BorderPrefab"), tile2, Quaternion.identity);
    }



    for (int j = 1; j < cols - 1; j++)
    {
        Vector2 tile1 = new Vector2((rectangleHalfBase - j) * size, -rectangleHalfHeight * size);
        Vector2 tile2 = new Vector2((rectangleHalfBase - j) * size, rectangleHalfHeight * size);
        GameObject.Instantiate(Resources.Load("BorderPrefab"), tile1, Quaternion.identity);
        GameObject.Instantiate(Resources.Load("BorderPrefab"), tile2, Quaternion.identity);
    }
}


*/