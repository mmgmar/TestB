using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrControlGame : MonoBehaviour
{
    public static int punts = 0;  // puntuació
    public static int pickups = 0;  // nombre de pickups a l'escena

    // [SerializeField] Text fi;
    [SerializeField] AudioSource so; // Per accedir so ambient
    bool pausat = false;
    [SerializeField] GameObject misatgeFi;

    string[] escenes = { "Level1", "Level2", "Level3" };
    static int level = 0;

    private void Start()
    {
        so.ignoreListenerPause = true;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (ScrControlGame.pickups == 0) JocFinalitzat();
        ControlEntradaUsuari();
    }
    void JocFinalitzat()
    {
        // print("S'ha acabat!");
        // fi.text = "Fi del joc";
        // ScrControlGame.pickups = -1;
        misatgeFi.SetActive(true);
        Time.timeScale = 0;
    }

    void ControlEntradaUsuari()
    {
        if (Input.GetKeyDown(KeyCode.X)) // ScrControlGame.pickups = 0;  primer prototipus
            EliminaPickups();
        if (Input.GetKeyDown(KeyCode.B)) MuteFons();
        if (Input.GetKeyDown(KeyCode.M)) MuteAudio();
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) so.volume -= 0.05f;
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) so.volume += 0.05f;
        if (Input.GetKeyDown(KeyCode.Alpha1)) AudioListener.volume -= 0.05f;
        if (Input.GetKeyDown(KeyCode.Alpha2)) AudioListener.volume += 0.05f;
        AudioListener.volume = Mathf.Clamp(AudioListener.volume, 0, 1); // Clamp manté valors entre dos límits
        if (Input.GetKeyDown(KeyCode.Return) && ScrControlGame.pickups == 0) NextLevel();

    }

    void EliminaPickups()
    {
        GameObject[] picks;
        picks = GameObject.FindGameObjectsWithTag("pickup");
        foreach(GameObject p in picks)
        {
            pickups--;
            punts += p.GetComponent<ScrPickup>().valor; // per incrementar punts del player
            Destroy(p);
        }
    }

    void MuteFons()
    {
        pausat = !pausat;
        if (pausat) so.Pause(); else so.Play();
    }
    void MuteAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    void NextLevel()
    {
        level++;
        if (level < escenes.Length)
            SceneManager.LoadScene(escenes[level]);
        else print("GAME OVER"); // Prototipus

    }
}
