using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public int halfWidth;
    public int halfHeight;



    private void GenerateFood()
    {
        Vector2 newPosition = new Vector2(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight));
        GameObject.Instantiate(Resources.Load("FoodPrefab"), newPosition, Quaternion.identity);
    }

}










/*
//   public static FoodSpawner foodAccessPoint;



private Vector2Int foodGridPosition;

[SerializeField]
int width, height;
//    [SerializeField]
//    Material spriteFood;



/*
public LevelGrid(int width, int height)
{
    this.width = width;
    this.height = height;

    SpawnFood();

}
*


private void Awake()
{
    //       foodAccessPoint = this;
    SpawnFood();
}






public void SpawnFood()
{
    foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

    GameObject foodGameObject = new GameObject("food", typeof(SpriteRenderer));
    foodGameObject.GetComponent<SpriteRenderer>() = SpriteRenderer.;
    foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
}

*/
