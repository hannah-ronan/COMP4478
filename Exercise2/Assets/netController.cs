using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netController : MonoBehaviour
{
    public int speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //get the current x coordinate of the net
        float x = transform.position.x;
        //make sure it's in a valid location
        if (x < 7 && x > -7)
        {
            //move the net in the direction of player input
            float InputX = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(speed * InputX, 0, 0);

            movement *= Time.deltaTime;
            transform.Translate(movement);
        }
        //if not then move the net back into a valid area
        else if (x > 7)
        {
            transform.Translate((float)-0.2, 0, 0);
        }
        else if (x < -7)
        {
            transform.Translate((float)0.2, 0, 0);
        }

    }

}
