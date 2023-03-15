using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishController : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Just hit another collider 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check which object the fish collided with
        if (collision.gameObject.tag == "Player")
        {
            //if the fish is caught in the net then increment the score
            //move the fish up above the screen so it falls back down
            transform.position=new Vector3(Random.Range(-7,7), 30, 0);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Score.text = "Score: "+(int.Parse(Score.text.Substring(6))+1);

        }
        else if (collision.gameObject.tag == "Ground")
        {
            //if the fish hits the ground decrement score 
            //move the fish up above the screen so it falls back down
            transform.position=new Vector3(Random.Range(-7,7), 30, 0);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
