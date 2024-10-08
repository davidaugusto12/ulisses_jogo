using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;

    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }

    public void CharacterTookDamage(GameObject character, int damageReceived)
    {
    Vector3 worldPosition = character.transform.position + new Vector3(0, 0.5f, 0); 
    Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        gameCanvas.GetComponent<RectTransform>(),
        screenPosition,
        Camera.main,
        out Vector2 localPosition
    );

    TMP_Text tmpText = Instantiate(damageTextPrefab, gameCanvas.transform).GetComponent<TMP_Text>();
    tmpText.transform.localPosition = localPosition;

    tmpText.text = damageReceived.ToString();
    }

    public void CharacterHealed(GameObject character, int healthRestored)
    {
    Vector3 worldPosition = character.transform.position;
    Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        gameCanvas.GetComponent<RectTransform>(), 
        screenPosition, 
        Camera.main, 
        out Vector2 localPosition
    );

    TMP_Text tmpText = Instantiate(healthTextPrefab, gameCanvas.transform).GetComponent<TMP_Text>();
    tmpText.transform.localPosition = localPosition;

        tmpText.text = healthRestored.ToString();
    }

}
