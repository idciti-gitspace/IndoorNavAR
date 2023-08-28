using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinPointController : MonoBehaviour
{
    [SerializeField]
    private NavigationController navigationController;

    [SerializeField]
    private TMP_Text w3wText;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PinPointArea"))
        {
            navigationController.transform.position = other.transform.parent.position;
            w3wText.text = other.gameObject.GetComponent<Text>().text;
        }
    }
}
