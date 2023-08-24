using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //R�cuperation de la taille de l'�cran
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;

    //Speed camera
    float speed = 0.01f;
    void Start()
    {

    }


    void Update()
    {
        //Retourne la position de la souris
        Vector3 mousePosition = Input.mousePosition;

        //R�cuperation de la postion de la souris
        float mouseX = mousePosition.x;
        float mouseY = mousePosition.y;

        //d�placement gauche
        if (mouseX <= (screenHeight - screenHeight + 20))
        {
            transform.Translate(-speed, 0, 0);
        }
        //d�placement droite
        if (mouseX >= (screenWidth - 20))
        {
            transform.Translate(speed, 0, 0);
        }
        //d�placement haut
        if (mouseY >= (screenHeight - 20))
        {
            transform.Translate(0, speed, 0);
        }
        //d�placements bas
        if (mouseY <= screenWidth - screenWidth + 20)
        {
            transform.Translate(0, -speed, 0);
        }

    }
}
