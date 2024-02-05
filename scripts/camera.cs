using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour

{
    // Start is called before the first frame update

    public Transform ball;
    public Vector3 vector;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vector = ball.position;
        transform.position = new Vector3(vector.x, vector.y + 5, vector.z -5);
    }
}
