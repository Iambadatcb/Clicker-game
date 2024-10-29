using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public TextMeshProUGUI clickText;

    private void Awake()
    {
        if(instance == null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateClicks(int clicks)
    {
        clickText.text = clicks.ToString();
    }
}
