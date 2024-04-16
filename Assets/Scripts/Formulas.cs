using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Formulas : MonoBehaviour
{
    public InputField weightInput, repsInput;
    public TMP_Text brzyckiResult, epleyResult, landerResult, lombardiResult, mayhewResult, connerResult, wathanResult, weightText, repsText, calculateButtonText;
    public GameObject brzyckiTextObject, epleyTextObject, landerTextObject, lombardiTextObject, mayhewTextObject, connerTextObject, wathanTextObject, repsTextObject, weightTextObject;
    public GameObject calculateButton, weightput, repsput, renew, warningTextObject, closeButton, weightInputObject, repsInputObject;
    public TextMeshProUGUI brzyckires, epleyres, landerres, lombardires, mayhewres, connerres, wathanres, warningText;

    public int brzycki;
    public int epley;
    public int lander;
    public int lombardi;
    public int mayhew;
    public int conner;
    public int wathan;

    private double weight;
    private double reps;
    public double lombardiReps;
    public double wathanNumber;
    public double mayhewNumber;
    public double euler = 2.71828;


    void Start()
    {
        // Printing texts according to language preference. Language: Turkish
        if (PlayerPrefs.GetInt("language") == 0)
        {

            weightText.text = "Aðýrlýk";
            repsText.text = "Tekrar";
            calculateButtonText.text = "Hesapla";

        }

        // Printing texts according to language preference. Language: English
        else if (PlayerPrefs.GetInt("language") == 1)
        {

            weightText.text = "Weight";
            repsText.text = "Reps";
            calculateButtonText.text = "Calculate";

        }


        //All the objects at the scene. False objects are: if you calculate more than 12 reps. I preferred to write them all one by one.

        closeButton.SetActive(false);
        warningTextObject.SetActive(false);
        brzyckires.gameObject.SetActive(true);
        brzyckiTextObject.SetActive(false);
        epleyres.gameObject.SetActive(true);
        epleyTextObject.SetActive(false);
        landerres.gameObject.SetActive(true);
        landerTextObject.SetActive(false);
        lombardires.gameObject.SetActive(true);
        lombardiTextObject.SetActive(false);
        mayhewres.gameObject.SetActive(true);
        mayhewTextObject.SetActive(false);
        connerres.gameObject.SetActive(true);
        connerTextObject.SetActive(false);
        wathanres.gameObject.SetActive(true);
        wathanTextObject.SetActive(false);
        calculateButton.SetActive(true);
        weightput.SetActive(true);
        weightTextObject.SetActive(true);
        repsput.SetActive(true);
        repsTextObject.SetActive(true);
    }
    public void Calculate()
    {

        if (!string.IsNullOrEmpty(weightInput.text))
        {

            //---------Calculator-----
            weight = int.Parse(weightInput.text);
            reps = int.Parse(repsInput.text);

            lombardiReps = Math.Pow(reps, 0.1);
            wathanNumber = Math.Pow(euler, -0.075 * reps);
            mayhewNumber = Math.Pow(euler, -0.055 * reps);

            if (int.TryParse(repsInput.text, out int repsCount))
            {
                if (repsCount == 1)
                {
                    //show results
                    brzyckiTextObject.SetActive(true);
                    epleyTextObject.SetActive(true);
                    landerTextObject.SetActive(true);
                    lombardiTextObject.SetActive(true);
                    mayhewTextObject.SetActive(true);
                    connerTextObject.SetActive(true);
                    wathanTextObject.SetActive(true);

                    //It will be active after renew();
                    weightInputObject.SetActive(false);
                    repsInputObject.SetActive(false);
                    calculateButton.SetActive(false);
                    weightTextObject.SetActive(false);
                    repsTextObject.SetActive(false);

                    // If you can lift at most once, you can lift that much weight at most. Maybe 2-3 kg more you can lift but nevermind..
                    brzycki = (int)weight;
                    epley = (int)(weight);
                    lander = (int)(weight);
                    lombardi = (int)(weight);
                    mayhew = (int)(weight);
                    conner = (int)(weight);
                    wathan = (int)(weight);

                    //New Calculation
                    renew.SetActive(true);
                    
                }
                else if (repsCount <= 12)
                {
                    //formulas
                    brzycki = (int)(weight * (36 / (37 - reps)));
                    epley = (int)(weight * (1 + reps / 30));
                    lander = (int)((100 * weight) / (101.3 - 2.67123 * reps));
                    lombardi = (int)(weight * lombardiReps);
                    mayhew = (int)((100 * weight) / (52.2 + (41.9 * mayhewNumber)));
                    conner = (int)(weight * (1 + (0.025 * reps)));
                    wathan = (int)((100 * weight) / (48.8 + (53.8 * wathanNumber)));

                    //show results
                    brzyckiTextObject.SetActive(true);
                    epleyTextObject.SetActive(true);
                    landerTextObject.SetActive(true);
                    lombardiTextObject.SetActive(true);
                    mayhewTextObject.SetActive(true);
                    connerTextObject.SetActive(true);
                    wathanTextObject.SetActive(true);

                    //It will be active after renew();
                    weightInputObject.SetActive(false);
                    repsInputObject.SetActive(false);
                    calculateButton.SetActive(false);
                    weightTextObject.SetActive(false);
                    repsTextObject.SetActive(false);

                    //new calculation
                    renew.SetActive(true);
                }
                else if (repsCount > 12)
                {
                    //True: A warning about reps input and close button.
                    closeButton.SetActive(true);
                    warningTextObject.SetActive(true);

                    brzyckires.gameObject.SetActive(false);
                    brzyckiTextObject.SetActive(false);
                    epleyres.gameObject.SetActive(false);
                    epleyTextObject.SetActive(false);
                    landerres.gameObject.SetActive(false);
                    landerTextObject.SetActive(false);
                    lombardires.gameObject.SetActive(false);
                    lombardiTextObject.SetActive(false);
                    mayhewres.gameObject.SetActive(false);
                    mayhewTextObject.SetActive(false);
                    connerres.gameObject.SetActive(false);
                    connerTextObject.SetActive(false);
                    wathanres.gameObject.SetActive(false);
                    wathanTextObject.SetActive(false);
                    calculateButton.SetActive(false);
                    weightput.SetActive(false);
                    weightTextObject.SetActive(false);
                    repsput.SetActive(false);
                    repsTextObject.SetActive(false);
                    
                    calculateButton.SetActive(false);
                    renew.SetActive(false);

                    //Warning: Turkish
                    if (PlayerPrefs.GetInt("language") == 0)
                    {
                        warningText.text = "Tekrar kýsmýna 1-12 arasý deðer gir!";
                    }

                    //Warning: English
                    else if (PlayerPrefs.GetInt("language") == 1)
                    {
                        warningText.text = "Enter a value between 1-12 in Reps section!";
                    }                    
                }
            }
            



            // ------------Console (Not Important)---------------
            Debug.Log("brzycki: " + brzycki);
            Debug.Log("epley: " + epley);
            Debug.Log("lander: " + lander);
            Debug.Log("lombardi: " + lombardi);
            Debug.Log("mayhew: " + mayhew);
            Debug.Log("connor: " + conner);
            Debug.Log("wathan: " + wathan);             

            //--------Printing----------

            brzyckiResult.text = brzycki.ToString();
            epleyResult.text = epley.ToString();
            landerResult.text = lander.ToString();
            lombardiResult.text = lombardi.ToString();
            mayhewResult.text = mayhew.ToString();
            connerResult.text = conner.ToString();
            wathanResult.text = wathan.ToString();

        }
    }

    public void WarningClose()
    {
        //It's a new calculation. False: Close button, warning, results, new calculation button. 
        closeButton.SetActive(false);
        warningTextObject.SetActive(false);
        brzyckires.gameObject.SetActive(true);
        brzyckiTextObject.SetActive(false);
        epleyres.gameObject.SetActive(true);
        epleyTextObject.SetActive(false);
        landerres.gameObject.SetActive(true);
        landerTextObject.SetActive(false);
        lombardires.gameObject.SetActive(true);
        lombardiTextObject.SetActive(false);
        mayhewres.gameObject.SetActive(true);
        mayhewTextObject.SetActive(false);
        connerres.gameObject.SetActive(true);
        connerTextObject.SetActive(false);
        wathanres.gameObject.SetActive(true);
        wathanTextObject.SetActive(false);
        calculateButton.SetActive(true);
        weightput.SetActive(true);
        weightTextObject.SetActive(true);
        repsput.SetActive(true);
        repsTextObject.SetActive(true);

        renew.SetActive(false);
        calculateButton.SetActive(true);

        brzyckiResult.text = null;
        epleyResult.text = null;
        landerResult.text = null;
        lombardiResult.text = null;
        mayhewResult.text = null;
        connerResult.text = null;
        wathanResult.text = null;

        weightInput.text = null;
        repsInput.text = null;
    }

    public void Renew()
    {
        //Refresh
        brzyckiResult.text = null;
        epleyResult.text = null;
        landerResult.text = null;
        lombardiResult.text = null;
        mayhewResult.text = null;
        connerResult.text = null;
        wathanResult.text = null;

        weightInput.text = null;
        repsInput.text = null;

        calculateButton.SetActive(true);
        renew.SetActive(false);

        //Deactive results.
        brzyckiTextObject.SetActive(false);
        epleyTextObject.SetActive(false);
        landerTextObject.SetActive(false);
        lombardiTextObject.SetActive(false);
        mayhewTextObject.SetActive(false);
        connerTextObject.SetActive(false);
        wathanTextObject.SetActive(false);

        //Active input areas and their texts.
        weightInputObject.SetActive(true);
        repsInputObject.SetActive(true);
        weightTextObject.SetActive(true);
        repsTextObject.SetActive(true);
    }

    //-------Quit Button----------
    public void Quit()
    {
        Application.Quit();
    }

    //-------Menu Button--------
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
