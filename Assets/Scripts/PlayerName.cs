using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text userNameInputText;
    public static string playername;
    public GameObject canvas;


    void Start()
    {
        userNameInputText.text = inputField.text;
    }

    void Update()
    {
        // this shouldnt be in here
        playername = userNameInputText.text;

        //print("userNameInputText: " + userNameInputText.text);
        //print("playerName: " + playername);
    }

    public void InputYourName() 
    {
        playername = userNameInputText.text;
    }
}


