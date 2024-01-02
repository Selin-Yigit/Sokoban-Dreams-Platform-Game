using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    [SerializeField] TextMeshProUGUI _text;


    void Awake()
    {

        _text.text = Score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            AudioSource.PlayClipAtPoint(clickSound, other.transform.position);
            Destroy(other.gameObject);
            Score.totalScore++;
            _text.text = Score.totalScore.ToString();
        }
    }
}
