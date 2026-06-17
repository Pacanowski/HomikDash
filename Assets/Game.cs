using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject cam;
    public Rigidbody2D rb;
    
    int time = 0;

    bool onGround = false;

    public GameObject wygrana;

    public GameObject przegrana;

    public GameObject sky;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FixedUpdate(){
        time++;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 10*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        cam.transform.position = new Vector3(gameObject.transform.position.x + 10, cam.transform.position.y, gameObject.transform.position.z - 100);
        sky.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, gameObject.transform.position.z);
       

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && onGround){
        
            rb.velocity = new Vector2(rb.velocity.x, 20f);

            onGround = false;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we hit has a specific tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("wybuch")) {
            Destroy(gameObject);
            przegrana.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("karma")) {
            wygrana.SetActive(true);
            Destroy(gameObject);
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the object we hit has a specific tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    
    }
    

   

}

