using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Holds all of the text that will be on our buttons in the game.
    public Text[] spaceList;

    // It will be activated whenever the game has ended.
    public GameObject gameOverPanel;
    public Text gameOverText;

    // Appears at the end of the game and will ask the user if they
    // wish to start a new game of Tic-tac-toe.
    public GameObject restartButton;
    private int moves; // Keeps track of how many moves have been played so far.
    private string side; // Keeps track of whose turn it is in the game.

    // Start is is setting the side to ‘X’, setting the number of moves to zero,
    // and deactivating the gameOverPanel and restartButton. 
    void Start()
    {
        SetGameControllerReferenceForButtons();
        side = "X";
        gameOverPanel.SetActive(false);
        moves = 0;
        restartButton.SetActive(false);
    }

    void SetGameControllerReferenceForButtons() {
	for (int i = 0; i < spaceList.Length; i++) {
		spaceList[i].GetComponentInParent<Space>().SetControllerReference(this);
    }
    }

    // Gets the current player's turn and setting an X or O on which
    // space you clicked on.
    public string GetSide() {
        return side;
    }

    // Controls the changing of player turns.
    void ChangeSide() {
        if (side == "X") {
            side = "O";
        }
        else {
            side = "X";
        }
    }

    // Handling the process of incrementing the moves var as well as checking
    // to see if any sort of game over state has been achieved. If a player has won,
    // it will call a GameOver func which will be created momentarily. It will also
    // check to see if the # of moves has reached a certain limit, and if it has,
    // it will activate the gameOverPanel and restartButton.
    public void EndTurn() {
        moves++;
        if (spaceList[0].text == side && spaceList[1].text == side && spaceList[2].text == side)
            GameOver();
        else if (spaceList[3].text == side && spaceList[4].text == side && spaceList[5].text == side)
            GameOver();
        else if (spaceList[6].text == side && spaceList[7].text == side && spaceList[8].text == side)
            GameOver();
        else if (spaceList[0].text == side && spaceList[3].text == side && spaceList[6].text == side)
            GameOver();
        else if (spaceList[1].text == side && spaceList[4].text == side && spaceList[7].text == side)
            GameOver();
        else if (spaceList[2].text == side && spaceList[5].text == side && spaceList[8].text == side)
            GameOver();
        else if (spaceList[0].text == side && spaceList[4].text == side && spaceList[8].text == side)
            GameOver();
        else if (spaceList[2].text == side && spaceList[4].text == side && spaceList[6].text == side)
            GameOver();

        if (moves >= 9) {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Tie!";
            restartButton.SetActive(true);
        }
        ChangeSide();
    }

    void GameOver() {
        gameOverPanel.SetActive(true);
        gameOverText.text = side + " wins!";
        restartButton.SetActive(true);

        for (int i = 0; i < spaceList.Length; i++) {
            SetInteractable(false);
        }
    }

    // Gathers all the button components in the parent obj of
    // each txt obj in spaceList and setting interactable to 
    // whather you assign in the setting boolean.
    void SetInteractable(bool setting) {
        for (int i = 0; i < spaceList.Length; i++) {
            spaceList[i].GetComponentInParent<Button>().interactable = setting;
        }
    }

    // After the game is over, the user will need a way to restart the game.
    // Similar to the GameOver func but in reverse.
    public void Restart() {
        side = "X";
        moves = 0;
        gameOverPanel.SetActive(false);
        SetInteractable(true);
        restartButton.SetActive(false);

        for (int i = 0; i < spaceList.Length; i++) {
            spaceList[i].text = "";
        }
    }
}

