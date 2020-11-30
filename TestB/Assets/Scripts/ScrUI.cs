using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per ...
/// AUTOR:  ...
/// DATA:   ...
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. ...
/// ----------------------------------------------------------------------------------
/// </summary>



public class ScrUI : MonoBehaviour
{
    [SerializeField]
    Text puntuacio,temps,pickups; // per accedir a l'elemnt de la UI

    float crono = 0;


    // Start is called before the first frame update
    void Start()
    {
        
  
    }

    // Update is called once per frame
    void Update()
    {
        crono += Time.deltaTime;
        puntuacio.text = "Puntuació: " + ScrControlGame.punts;
        pickups.text = ScrControlGame.pickups.ToString();
        temps.text = "Temps: " + crono.ToString("0.0");
    }
}
