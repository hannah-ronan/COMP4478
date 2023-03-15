using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour
{
    GameObject Manager;
    
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Just hit another collider 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the bomb is colliding with the player or the ground
        if (collision.gameObject.tag == "Player")
        {
            //if the bomb is caught in the net the game is over
            transform.position = new Vector3(Random.Range(-7, 7), 30, 0);
            Manager.GetComponent<GameManager>().GameOver();

        }
        else if (collision.gameObject.tag == "Ground")
        {
            //if the bomb hits the ground
            transform.position = new Vector3(Random.Range(-7,7),30,0);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
