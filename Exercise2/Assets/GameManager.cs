using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject Bomb;
    GameObject Fish;
    public Text GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        Bomb = GameObject.Find("bomb");
        Fish = GameObject.Find("fish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        //Show the game over message and move the fish and bomb off screen
        Debug.Log("Game Over");
        GameOverText.text = "Game Over!";
        Bomb.transform.position = new Vector3(0,-100,0);
        Fish.transform.position = new Vector3(0, -100, 0);
    }
}
