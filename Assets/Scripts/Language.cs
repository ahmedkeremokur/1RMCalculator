using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public TextMeshProUGUI paragraph, btntext, nameText;
    public TMP_Dropdown _dropdown;

    //Get the language prefs at the start.
    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedOption"))
        {
            int selectedIndex = PlayerPrefs.GetInt("SelectedOption");
            _dropdown.value = selectedIndex;
        }

        if (PlayerPrefs.GetInt("language") == 0)
        {
            paragraph.text = "Bu program çalýþtýðýnýz aðýrlýk ile en fazla yapabildiðiniz tekrar sayýsýna göre bir tekrar ile en fazla kaç kg kaldýrabileceðinizi hesaplar. " +
                "7 farklý formül ile hesaplanmýþ deðerleri göreceksiniz" +
                "Deðerleri 25 tekrarýn altýnda ve kg cinsinden giriniz.";

            btntext.text = "1 RM Hesaplayýcý";

            _dropdown.value = 0;

            nameText.text = "1 RM\nHesaplayýcý";
        }
        else if (PlayerPrefs.GetInt("language") == 1)
        {
            paragraph.text = "This program calculates the maximum weight you can lift for a given number of " +
                "repetitions based on the maximum number of repetitions you can perform with the weight you are currently using." +
                "You will see values calculated with 7 different formulas." +
                "Enter the values in kilograms and below 25 repetitions.";

            btntext.text = "1 RM Calculator";

            _dropdown.value = 1;

            nameText.text = "1 RM\nCalculator";

        }

    }

    //---------Language------------
    public void HandleInputData (int novemberRain)
    {
        //Set language prefs
        PlayerPrefs.SetInt("language", novemberRain);


        //Get language prefs
        if (PlayerPrefs.GetInt("language") == 0)
        {
            paragraph.text = "Bu program çalýþtýðýnýz aðýrlýk ile en fazla yapabildiðiniz tekrar sayýsýna göre bir tekrar ile en fazla kaç kg kaldýrabileceðinizi hesaplar. " +
                "7 farklý formül ile hesaplanmýþ deðerleri göreceksiniz" +
                "Deðerleri 25 tekrarýn altýnda ve kg cinsinden giriniz.";

            btntext.text = "1 RM Hesaplayýcý";

            nameText.text = "1 RM\nHesaplayýcý";
        }
        else if (PlayerPrefs.GetInt("language") == 1)
        {
            paragraph.text = "This program calculates the maximum weight you can lift for a given number of " +
                "repetitions based on the maximum number of repetitions you can perform with the weight you are currently using." +
                "You will see values calculated with 7 different formulas." +
                "Enter the values in kilograms and below 25 repetitions.";

            btntext.text = "1 RM Calculator";

            nameText.text = "1 RM\nCalculator";
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("RepMax");
    }

}
