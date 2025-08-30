using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterSelection : MonoBehaviour {
    public Text infoText;

    void Start() {
        if (!playerData.isPlayer1LoggedIn) {
            infoText.text = "Choose your character";
        } else {
            infoText.text = "Oh! see who is here! our next player.";
        }
    }

    public void ChooseArcher() {
        if (!playerData.isPlayer1LoggedIn) {
            playerData.player1Char = "Archer";
        } else {
            playerData.player2Char = "Archer";
        }
        NextStep();
    }

    public void ChooseSwordsman() {
        if (!playerData.isPlayer1LoggedIn) {
            playerData.player1Char = "Swordsman";
        } else {
            playerData.player2Char = "Swordsman";
        }
        NextStep();
    }

    void NextStep() {
        if (playerData.isPlayer1LoggedIn && !string.IsNullOrEmpty(playerData.player2Name)) {
            SceneManager.LoadScene("StairCase");
//staircase
        } else {
            // again login scene for player 2
            SceneManager.LoadScene("LogIn");
        }
    }
}