using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public float rot_speed = 30;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate(Vector3.one * rot_speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //Destroy(collision.gameObject);
            //send message from this to collison object because to call method from ball item_pickUp method
            collision.gameObject.SendMessage("item_pickUp");
            //also can call
            //collision.gameObject.GetComponent<ball>().item_pickUp();
        }
    }
}
