using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public float deathY = -10f;
    private CharacterSwitcher switcher;

    void Start()
    {
        switcher = FindObjectOfType<CharacterSwitcher>();
    }

    void Update()
    {
        foreach (GameObject character in switcher.characters)
        {
            if (character.activeSelf && character.transform.position.y < deathY)
            {
                RespawnCharacter(character);
            }
        }
    }

    void RespawnCharacter(GameObject character)
    {
        character.transform.position = new Vector3(0, 2, 0);
        character.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}