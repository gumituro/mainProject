/*using UnityEngine;
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
            SceneManager.LoadScene("login");
        }
    }
}
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterSelection : MonoBehaviour
{
    public Text infoText;
    public GameObject archerButton;
    public GameObject swordsmanButton;

    private bool hasChosen = false; // برای جلوگیری از انتخاب دوباره

    void Start()
    {
        if (!playerData.isPlayer1LoggedIn)
        {
            infoText.text = "Choose your character";
        }
        else
        {
            infoText.text = "Oh! see who is here! our next player.";
        }
    }

    /*
    public void ChooseArcher()
    {
        if (hasChosen) return; 

        if (!playerData.isPlayer1LoggedIn)
        {
            playerData.player1Char = "Archer";
            playerData.isPlayer1LoggedIn = true; // ثبت اینکه بازیکن 1 لاگین شده
        }
        else
        {
            playerData.player2Char = "Archer";
        }

        AfterChoose();
    }*/
    
    public void ChooseArcher()
    {
        Debug.Log("Archer clicked!");
        if (hasChosen) return;
    
        if (!playerData.isPlayer1LoggedIn)
        {
            playerData.player1Char = "Archer";
            playerData.isPlayer1LoggedIn = true;
        }
        else
        {
            playerData.player2Char = "Archer";
        }

        AfterChoose();
    }

    public void ChooseSwordsman()
    {
        if (hasChosen) return; 

        if (!playerData.isPlayer1LoggedIn)
        {
            playerData.player1Char = "Swordsman";
            playerData.isPlayer1LoggedIn = true; // ثبت اینکه بازیکن 1 لاگین شده
        }
        else
        {
            playerData.player2Char = "Swordsman";
        }

        AfterChoose();
    }

    void AfterChoose()
    {
        hasChosen = true; 
        archerButton.SetActive(false);
        swordsmanButton.SetActive(false);

        // رفتن به مرحله بعد
        if (playerData.isPlayer1LoggedIn && !string.IsNullOrEmpty(playerData.player2Name))
        {
            SceneManager.LoadScene("StairCase");
        }
        else
        {
            SceneManager.LoadScene("login");
        }
    }
}