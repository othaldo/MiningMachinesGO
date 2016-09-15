using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game_Menu_GUI : MonoBehaviour
{

    public UnityEngine.UI.InputField usernameLogin;
    public UnityEngine.UI.InputField passwordLogin;

    public UnityEngine.UI.InputField usernameRegister;
    public UnityEngine.UI.InputField passwordRegister;
    public UnityEngine.UI.InputField passwordRegisterRepeat;
    public UnityEngine.UI.InputField emailRegister;

    public UnityEngine.UI.Button login;
    public UnityEngine.UI.Button register;

    public UnityEngine.UI.Button sendRegistration;
    public UnityEngine.UI.Button cancelRegistration;

    public UnityEngine.UI.Text currentGameMenu;
    public UnityEngine.UI.Text errorText;

    public UnityEngine.GameObject loginPanel;
    public UnityEngine.GameObject registerPanel;

    void Start()
    {
        currentGameMenu.text = "Login";
    }
    public void Login()
    {
        if (usernameLogin.text == "" || passwordLogin.text == "")
        {
            errorText.text = "Please fill in all info";
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("login", usernameLogin.text);
            form.AddField("password", passwordLogin.text);
            WWW w = new WWW("http://zockerdudes.de/miningsmachinesgo/login.php", form);
            StartCoroutine(LogIn(w));
        }

    }

    public void StartRegistration()
    {
        currentGameMenu.text = "Create Account";
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
        RectTransform rect = errorText.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, -810);
        errorText.text = "";
    }
    public void CancelRegistration()
    {
        currentGameMenu.text = "Login";
        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
        RectTransform rect = errorText.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, -640);
        errorText.text = "";
    }
    public void CreateAccount()
    {
        if (usernameRegister.text != "" || emailRegister.text != "")
        {
            if (passwordRegister.text.Equals(passwordRegisterRepeat.text))
            {
                WWWForm form = new WWWForm();
                form.AddField("login", usernameRegister.text);
                form.AddField("password", passwordRegisterRepeat.text);
                form.AddField("email", emailRegister.text);
                WWW w = new WWW("http://zockerdudes.de/miningsmachinesgo/register.php", form);
                StartCoroutine(CreateAccount(w));
            }
            else
            {
                errorText.text = "Passwort stimmt nicht überein";
            }
        } else
        {
            errorText.text = "Please fill in all info";
        }


    }
    private IEnumerator LogIn(WWW _w)
    {
        yield return _w;
        if (_w.error == null)
        {
            if (_w.text == "Log in successful!")
            {
                SceneManager.LoadScene("KlickerSzene");
            }
            else
            {
                errorText.text = _w.text;
            }
        }
        else
        {
            errorText.text = "Error" + _w.error;
        }
    }
    private IEnumerator CreateAccount(WWW _w)
    {
        yield return _w;
        if (_w.error == null)
        {
            errorText.text = _w.text;
        }
        else
        {
            errorText.text = "Error" + _w.error;
        }
    }
}