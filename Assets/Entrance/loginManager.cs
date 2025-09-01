using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginManager : MonoBehaviour {
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Text messageText;

    public void OnLogIn() {
        string msg;
        if (userManager.LogIn(usernameInput.text, passwordInput.text, out msg)) {
            if (!playerData.isPlayer1LoggedIn) {
                playerData.player1Name = usernameInput.text;
                playerData.isPlayer1LoggedIn = true;
            } else {
                playerData.player2Name = usernameInput.text;
            }
            SceneManager.LoadScene("ModeSelection");
        } else {
            messageText.text = msg;
        }
    }

    public void OnSignUp() {
        string msg;
        if (userManager.SignUp(usernameInput.text, passwordInput.text, out msg)) {
            messageText.text = msg;
            if (!playerData.isPlayer1LoggedIn) playerData.isPlayer1LoggedIn = true;
            SceneManager.LoadScene("ModeSelection");
        } else {
            messageText.text = msg;
        }
    }
}