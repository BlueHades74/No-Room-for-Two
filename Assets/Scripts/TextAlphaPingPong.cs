using TMPro;
using UnityEngine;

public class TextAlphaPingPong : MonoBehaviour
{
    [SerializeField] private float blinkingSpeed = 1.0f;

    private TextMeshProUGUI textObject;
    private Color color;

    

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        color = textObject.color;
        color.a = Mathf.PingPong(Time.time * blinkingSpeed, 1.0f);
        textObject.color = color;
    }
}
