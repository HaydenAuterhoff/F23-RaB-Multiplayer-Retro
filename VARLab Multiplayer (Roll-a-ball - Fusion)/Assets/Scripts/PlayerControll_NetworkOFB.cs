using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControll_NetworkOFB : MonoBehaviour
{
    [SerializeField] private string countTextName;
    [SerializeField] private string winTextObjectName;

    private TextMeshProUGUI countText;
    private GameObject winTextObject;

    private Rigidbody _rb;
    private int _count;

    void Start()
    {
        _count = 0;
        _rb = GetComponent<Rigidbody>();

        countText = GameObject.Find(countTextName)?.GetComponent<TextMeshProUGUI>();
        winTextObject = GameObject.Find(winTextObjectName);

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();

        if (_count >= 6)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}