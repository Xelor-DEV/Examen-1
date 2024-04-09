using UnityEngine;
using UnityEngine.InputSystem;
using System;
using TMPro;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text vida_texto;
    public GameObject perdiste;
    public Action CuandoElJugadorEsDerrotado;
    private void OnEnable()
    {
        CuandoElJugadorEsDerrotado += Morir;
    }
    public void Morir()
    {
        perdiste.SetActive(true);
        Time.timeScale = 0;
    }
    public void ActualizarVidaTexto(int vida)
    {
        vida_texto.text = "Vida: " + vida;
    }

}
