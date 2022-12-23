using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    //Ultima caida(bajando) de la pieza hace 0 segundos
    float lastFall = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento horizontal de las piezas
        //Movimiento de la ficha a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Llamamos al metodo de movimiento horizontal y le pasamos la direccion izquierda
            MovePieceHorizontal(-1);
        }
        //Movimiento de la ficha a la derecha
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Llamamos al metodo de movimiento horizontal y le pasamos la direccion derecha
            MovePieceHorizontal(1);
        }
        //Rotacion de la pieza
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //roto la pieza hacia la derecha
            this.transform.Rotate(0, 0, 90);

            //Si la posicion es valida
            if (IsvalidPosition())
            {
                //actualizamos la rejilla, guardando la nueva posicion en el Gridhelper
                UpdateGrid();
            }
            //Si la posicion no fuese valida
            else
            {
                //Revierto la rotacion hacia el lado contrario izquierdo
                this.transform.Rotate(0, 0, 90);
            }
        }
        //Mover la pieza hacia abajo al pulsar la tecla o cuando haya pasado

    }
    //Metodo para el movimiento horizontal
    void MovePieceHorizontal(int direction) //con direction, le pasamos un numero para
    {
        //Muevo la pieza en la direccion dada
        this.transform.position += new Vector3(direction, 0, 0);
        //comprobamos si la nueva posicion es valida
        if (IsvalidPosition())
        {
            //Actualizamos la rejill, guardando la nueva posición en el gridhelper
            UpdateGrid();
        }
        else
        {
            //Revertimos el movimiento a la posicion en la que estaba antes
            this.transform.position += new Vector3(-direction, 0, 0);
        }
    }
    //Metodo que comprueba si la posicion en la que se encuentra ahora mismo la pieza, es o no valida
    private bool IsvalidPosition()
    {
        //Hacemos una pasada por todas las posiciones de los hijos de la pieza (los bloques)
        foreach (Transform block in this.transform)
        {
            //Recuperamos su posicion (la de los bloques, hijos de la pieza) y la redondeamos
            Vector2 pos = GridHelper.RoundVector(block.position);

            //Si no esta dentro de los bordes, la posicion, la posicion no es valida. Es decir
            if(!GridHelper.IsInsideBorder(pos))
            {
                //Si algun bloque de la pieza no está en una posicion valida
                return false;
            }

            //Si ya hay otro bloque en esa misma posicion, la posicion tampoco es valida.
            //Como la posicion podria ser un float(tener decimales), la transformamos en numero
            transform possibleObject = GridHelper.grid[(int)pos.x, (int)pos.y];
            //Si ya hay una pieza y este no es hijo del mismo objeto (osea el bloque esta dentro de otro)
            if (possibleObject != null && possibleObject.parent != this.transform)
            {
                //la posicion no es valida
                return false;
            }
            //Si ninguna de las cosas anteriormente mencionadas se cumple, sera que este bloque
            return true;
        }
    }
    private void UpdateGrid()
    {
        //Comparamos si el padre del objeto coincide con el del bloque estamos mirando
        for (int y = 0; y < GridHelper.h; y++)
        {
            //Despues por colummnas de cada fila
            for (int x = 0; x < GridHelper.w; x++)
            {
                //comprobamos si en esa posicion hay un bloque
                if(GridHelper.grid[x, y] != null)
                {
                    //Comprobamos si el padre del bloque es la pieza donde está este script metido
                    if (GridHelper.grid[x, y].parent == this.transform)
                    {
                        //Se carga los bloques que quedan de esa pieza y pone esas posiciones
                        GridHelper.grid[x, y] = null;
                    }
                }
            }
        }
        //Insertamos los bloques en las posiciones que deben estar
        //hacemos una pasada por cada uno de los bloques de la pieza actual
        foreach (Transform transform in this.transform)
        {
            //cojo la posicion donde este cada uno de los hijos y la redondeo
            Vector2 pos = GridHelper.RoundVector(block.position);
            //Metemos
        }
    }
}
