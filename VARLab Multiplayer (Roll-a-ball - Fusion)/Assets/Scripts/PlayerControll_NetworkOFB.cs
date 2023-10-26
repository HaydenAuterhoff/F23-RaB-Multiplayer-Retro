using Fusion;
using TMPro;
using UnityEngine;

public class PlayerControll_NetworkOFB : NetworkBehaviour
{
    [SerializeField] private string countTextName;
    [SerializeField] private string winTextObjectName;
    [SerializeField] private string mainCamera;

    private TextMeshProUGUI countText;
    private GameObject winTextObject;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

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

    public override void Spawned()
    {
        if (HasInputAuthority)
        {
            camera = Camera.main;
            camera.GetComponent<CameraController>().player = GetComponent<NetworkTransform>().InterpolationTarget;
        }
    }
}