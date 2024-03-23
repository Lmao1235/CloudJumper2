using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private int Coins = 0; //�ӹǹ����­

    public TextMeshProUGUI cointext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coins")
        {
            Coins++; //�ǡ����­
            cointext.text = "Coins:" + Coins.ToString();
            Debug.Log(Coins);
            Destroy(other.gameObject); //������­
        }
    }
}
