using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int Coins = 0;

    public TextMeshProUGUI cointext;

    private void OnTriggerEnter(Collision other)
    {
        if (other.transform.tag == "Coins")
        {
            cointext.text = "Coin(s): " + Coins.ToString();
            Coins++;
            Debug.Log(Coins);
            Destroy(other.gameObject);
        }
    }
}
