using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    [Header("Karakterler")]
    public GameObject[] characters;

    [Header("Kamera")]
    public Camera mainCamera;

    private int activeIndex = 0;

    void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == 0);
        }

        UpdateCamera();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchToNext();
        }
    }

    void SwitchToNext()
    {
        Vector3 currentPos = characters[activeIndex].transform.position;
        Vector2 currentVelocity = characters[activeIndex].GetComponent<Rigidbody2D>().linearVelocity;

        characters[activeIndex].SetActive(false);

        activeIndex = (activeIndex + 1) % characters.Length;

        // Yeni karakter ayný pozisyonda baþlasýn
        characters[activeIndex].transform.position = currentPos;
        characters[activeIndex].GetComponent<Rigidbody2D>().linearVelocity = currentVelocity;
        characters[activeIndex].SetActive(true);

        UpdateCamera();
    }

    void UpdateCamera()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Kamerayý aktif karaktere baðla
        mainCamera.GetComponent<CameraFollow>()?.SetTarget(characters[activeIndex].transform);
    }
}