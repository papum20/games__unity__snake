using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float z_offset = -10;



    // Start is called before the first frame update
    void Start()
    {
        float x = BorderGenerator.mapGeneration.cols / 2f;
        float y = BorderGenerator.mapGeneration.rows / 2f;

        transform.position = new Vector3(x, y, z_offset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
