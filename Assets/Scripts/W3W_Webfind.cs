using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class W3W_Webfind : MonoBehaviour
{
    private string urlText;
    [SerializeField]
    private Button yourButton;
    [SerializeField]
    private TMP_Text w3wText;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        urlText = "https://what3words.com/" + w3wText.text;
        Application.OpenURL(urlText);
    }
    // Start is called before the first frame update
}
