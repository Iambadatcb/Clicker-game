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
    public int cpb = 1;


    public float bakerSpeed = 2f;
    
    [Header("Upgrade")]

    public int upgrade=0;


    private Clicker clicker;

    private void Start(){
        clicker=FindObjectOfType<Clicker>();
        InvokeRepeating("Cook",0,bakerSpeed);
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
        // if (count>0){
        //     InvokeRepeating("BakerJob",0.1f,1.0f);
        // }
    }
    
    void Cook()
    {
        clicker.clickVFX.Emit(cpb * count);
        clicker.clicks+=cpb*count;
        UIManager.instance.UpdateClicks(clicker.clicks);
        PlayerPrefs.SetInt("Rebirths",count);
        PlayerPrefs.Save();
         
    }
    public void Upgrade()
    {
        if(clicker.clicks >= 1000){

            upgrade++;
            count = 0;
            clicker.clicks=0;
            UIManager.instance.UpdateClicks(clicker.clicks);
        }
    }
    // private void Update()
    // {
    //     if (count>0){
    //         InvokeRepeating("BakerJob",0.1f,1.0f);
    //     }
    // }
    // void BakerJob()
    // {
    //     clicker.clicks += 1*count;
    // }
    
}
