using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameGrid : MonoBehaviour
{
    public Sprite doraemonSprite;
    public Sprite beanSprite;
    public Sprite minionSprite;
    public Sprite noddySprite;
    public Sprite mouseSprite;
    public Sprite popeyeSprite;
    public Sprite shinchanSprite;
    public Sprite scoobySprite;
    public Sprite blankSprite;

    public GameObject StartButton;
    public GameObject RestartButton;
    public GameObject MessageText;

    private List<Sprite> Layout;

    private GameObject LastClicked = null;
    private GameObject JustClicked = null;

    private int Matches;

    // Start is called before the first frame update
    void Start()
    {
        //create a random layout of cards
        Layout = GenerateLayout();
        for (int i = 0;i < 16; i++)
        {
            //change the blank card sprite to the appropriate character
            gameObject.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Layout[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<Sprite> GenerateLayout()
    {
        //if the layout has not been created yet then create it by shuffling the list of sprites into a random order
        if(Layout== null)
        {
            return ShuffleList(new List<Sprite>() { doraemonSprite, beanSprite, mouseSprite, noddySprite, popeyeSprite, shinchanSprite, scoobySprite, minionSprite, doraemonSprite, beanSprite, mouseSprite, noddySprite, popeyeSprite, shinchanSprite, scoobySprite, minionSprite, });
        }
        return ShuffleList(Layout);
    }

    public static List<Sprite> ShuffleList(List<Sprite> list)
    {
        //make list.Count number of random switches
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    public void StartGameClicked()
    {
        for (int i = 0; i < 16; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Image>().sprite = blankSprite;
        }
        StartButton.SetActive(false);
    }

    public void CardClicked(GameObject card)
    {
        //set the card that was just clicked
        LastClicked = JustClicked;
        JustClicked = card;
        //change the sprite of the justclicked card to whatever its appropriate character from the layout is
        card.GetComponent<UnityEngine.UI.Image>().sprite = Layout[getIndex(card.name)];
        //if a pair of cards is clicked, check if they match
        if (LastClicked != null){
            Invoke("CheckMatch", (float)0.5);
        }
    }

    private int getIndex(string name)
    {
        return int.Parse(name.Substring(15));
    }

    private void CheckMatch()
    {
        //if the pair of cards has the same sprite then they are a match
        if (JustClicked.GetComponent<UnityEngine.UI.Image>().sprite == LastClicked.GetComponent<UnityEngine.UI.Image>().sprite)
        {
            //increment the matches counter
            Matches++;
            //make disable the pair so that they can't be clicked
            JustClicked.GetComponent<UnityEngine.UI.Button>().interactable = false;
            LastClicked.GetComponent<UnityEngine.UI.Button>().interactable = false;
            //set the card pair to null so the user can choose another pair
            LastClicked = null;
            JustClicked = null;
            //check if all cards have been matched
            if (Matches == 8)
            {
                GameOver();
            }
        }
        else
        {
            //if the cards don't match then "turn them back over" by changing the sprite back to the blank card
            JustClicked.GetComponent<UnityEngine.UI.Image>().sprite = blankSprite;
            LastClicked.GetComponent<UnityEngine.UI.Image>().sprite = blankSprite;
            //set the card pair to null so the user can choose another pair
            LastClicked = null;
            JustClicked = null;
        }
        
    }

    private void GameOver()
    {
        //show a game over message and restart button
        MessageText.SetActive(true);
        RestartButton.SetActive(true);
        //set the match count back to zero 
        Matches = 0;
    }

    public void RestartGameClicked()
    {
        //hide the gameover message and restart game button
        MessageText.SetActive(false);
        RestartButton.SetActive(false);
        //show the start button
        StartButton.SetActive(true);
        //set all cards back to interactable
        for (int i = 0; i < 16; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
        Start();
    }

}
