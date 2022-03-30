using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class MainStartMenuButton : MonoBehaviour
{
    public TextMeshProUGUI lifetimeCorrectCoffees;
    public int correctCoffees;
    private void Start()
    {
        CoffeeData data = SaveSystem.loadTotalCoffees();
        correctCoffees = data.correctCoffees;
        lifetimeCorrectCoffees.text = (" Lifetime Total Correct Coffees = " + correctCoffees);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
