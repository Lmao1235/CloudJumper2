using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private int Coins = 0; //จำนวนเหรียญ

    public TextMeshProUGUI cointext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coins")
        {
            Coins++; //บวกเหรียญ
            cointext.text = "Coins:" + Coins.ToString();
            Debug.Log(Coins);
            Destroy(other.gameObject); //เก็บเหรียญ
        }
    }
}
