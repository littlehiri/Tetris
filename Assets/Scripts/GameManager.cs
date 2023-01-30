using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager referencia;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI Lineas;

    public int Puntos;
    public float Puntos2;

    private void Awake()
    {
        if (referencia == null)
        {
            referencia = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
