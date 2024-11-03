using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Baker")]
    public TextMeshProUGUI priceText;
    public int price = 10;
    public TextMeshProUGUI countText;
    public int count;

    private Clicker clicker;

    private void Start(){
        clicker=FindObjectOfType<Clicker>();
    }

    public void BuyBaker()
    {
        if(clicker.clicks >= price){
            clicker.clicks-=price;
            UIManager.instance.UpdateClicks(clicker.clicks);

            count++;
            countText.text = count.ToString();

            price = (int)(price*1.1f);
            priceText.text = $"Price: {price}";
        }
        if (count>0){
            InvokeRepeating("BakerJob",0.1f,1.0f);
        }
    }
    void BakerJob()
    {
        clicker.clicks += 1*count;
    }
    
}
