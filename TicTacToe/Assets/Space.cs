using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Space : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    private GameController gameController;
    
    // Getting a reference to the GameController script for later use.
    public void SetControllerReference(GameController control) {
	gameController = control;
    }

    // After the player makes a move, this function will be called to 
    // place an X or an O on the space and make sure the button object
    // you click is no longer interactable. It will then call GameController’s
    // EndTurn function to change whose turn it is.
    public void SetSpace() {
	buttonText.text = gameController.GetSide();
	button.interactable = false;
	gameController.EndTurn();
    }

}
