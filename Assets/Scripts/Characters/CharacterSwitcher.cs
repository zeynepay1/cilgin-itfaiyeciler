using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    [Header("Karakterler")]
    public GameObject[] characters;

    private int activeIndex = 0;

    void Start()
    {
        // Sadece ilk karakteri aktif et, diðerlerini kapat
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        // Tab veya Shift ile geçiþ
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchToNext();
        }
    }

    void SwitchToNext()
    {
        // Mevcut karakteri kapat
        characters[activeIndex].SetActive(false);

        // Sýradaki karaktere geç (sona gelince baþa dön)
        activeIndex = (activeIndex + 1) % characters.Length;

        // Yeni karakteri aç
        characters[activeIndex].SetActive(true);
    }
}