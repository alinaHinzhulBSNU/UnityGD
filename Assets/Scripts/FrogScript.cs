using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Vector3 vector;

    void Start()
    {

    }

    void Update()
    {
        // Scale 
        vector = transform.localScale;
        vector.x += Time.deltaTime;
        vector.y += Time.deltaTime;
        transform.localScale = vector;
        
        // Rotate 
        transform.Rotate(new Vector3(0, 0, 1), 1);
    }

}
