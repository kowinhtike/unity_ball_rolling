using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7;
    private Rigidbody rb;
    public Vector3 vector;

    public float miniJump = 8;
    public float bigJump = 12;

    public bool hitGround = false;
    public bool doubleJump = true;
    public LayerMask ground;

    //for text show
    public TextMeshProUGUI textMeshProUGUI;
    public int max_item;
    public int current_item;

    //add sound
    public AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //get total items with tag
        max_item = GameObject.FindGameObjectsWithTag("Item").Length;
        textMeshProUGUI.text = "0/" + max_item.ToString();
        src.clip = clip;
        src.Play();

    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //check first for big jump and needed to hit ground
        if (hitGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += new Vector3(0, bigJump, 0);
            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
            {
                rb.velocity = new Vector3(0, bigJump/2, 0);
                //rb.velocity += new Vector3(0, bigJump / 2, 0);
                doubleJump = false;
            }else if (Input.GetKeyUp(KeyCode.Space))
            {
                //and check for one click space button
                if (rb.velocity.y > miniJump)
                {
                    rb.velocity = new Vector3(0, miniJump, 0);

                }
            }

        }
        
        
    }

    public void item_pickUp()
    {
        current_item++;
        textMeshProUGUI.text = current_item.ToString()+"/"+max_item.ToString();
        if(current_item == max_item)
        {
            Debug.Log("Win the game");
            SceneManager.LoadScene("FinishedGame");
        }
    }

    //this is builtin unity function for smooth
    private void FixedUpdate()
    {
        rb.AddForce(vector * speed);
        //check layer input as ground
        if(Physics.Raycast(transform.position, Vector3.down, 0.75f, ground))
        {
            hitGround = true;
            doubleJump = true;
        }
        else
        {
            hitGround= false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OutArea"))
        {
            //don't forget to enable is trigger check button
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }
}
