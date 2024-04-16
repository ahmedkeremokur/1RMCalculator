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
            paragraph.text = "Bu program �al��t���n�z a��rl�k ile en fazla yapabildi�iniz tekrar say�s�na g�re bir tekrar ile en fazla ka� kg kald�rabilece�inizi hesaplar. " +
                "7 farkl� form�l ile hesaplanm�� de�erleri g�receksiniz" +
                "De�erleri 25 tekrar�n alt�nda ve kg cinsinden giriniz.";

            btntext.text = "1 RM Hesaplay�c�";

            _dropdown.value = 0;

            nameText.text = "1 RM\nHesaplay�c�";
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
            paragraph.text = "Bu program �al��t���n�z a��rl�k ile en fazla yapabildi�iniz tekrar say�s�na g�re bir tekrar ile en fazla ka� kg kald�rabilece�inizi hesaplar. " +
                "7 farkl� form�l ile hesaplanm�� de�erleri g�receksiniz" +
                "De�erleri 25 tekrar�n alt�nda ve kg cinsinden giriniz.";

            btntext.text = "1 RM Hesaplay�c�";

            nameText.text = "1 RM\nHesaplay�c�";
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
