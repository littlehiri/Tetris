using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    //Array donde guardamos los objetos que seran spawneados
    public GameObject[] levelPieces;
    // Start is called before the first frame update
    void Start()
    {
        //sacará una pieza al empezar el juego
        SpawnNextPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metodo de spwanear cada pieza
    public void SpawnNextPiece()
    {
        //Tomamos un valor aleatorio comprendido en la longitud del array
        int i = Random.Range(0, levelPieces.Length); //random.range(valor más bajo, valor mas alto)

        //instanciamos la pieza seleccionada en la posicion del objeto spawneado
        Instantiate(levelPieces[i], this.transform.position, Quaternion.identity);
        
        //Quaternion.iden guarda la rotacion del objeto
    }
}
