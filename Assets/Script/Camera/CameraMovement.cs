using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Récuperation de la taille de l'écran
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;

    public bool canMove;

    //Speed camera
    float speed = 0.05f;
    void Start()
    {
        canMove = true;
    }


    void Update()
    {
        if (canMove == true)
        {

            //Retourne la position de la souris
            Vector3 mousePosition = Input.mousePosition;

            //Récuperation de la postion de la souris
            float mouseX = mousePosition.x;
            float mouseY = mousePosition.y;

            //déplacement gauche
            if (mouseX <= (screenHeight - screenHeight + 20))
            {
                transform.Translate(-speed, 0, 0);
            }
            //déplacement droite
            if (mouseX >= (screenWidth - 20))
            {
                transform.Translate(speed, 0, 0);
            }
            //déplacement haut
            if (mouseY >= (screenHeight - 20))
            {
                transform.Translate(0, speed, 0);
            }
            //déplacements bas
            if (mouseY <= screenWidth - screenWidth + 20)
            {
                transform.Translate(0, -speed, 0);
            }
        }
    }
}
