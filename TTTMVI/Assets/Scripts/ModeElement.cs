using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeElement : MonoBehaviour
{
    [SerializeField] private Sprite modeImg1;
    [SerializeField] private Sprite modeImg2;
    [SerializeField] private Image img;
    [SerializeField] private FieldController field;

    void Update() {
        //change sprite accordingly to a game mode
        if (field.gameMode == 1) {
            img.sprite = modeImg1;
        } else {
            img.sprite = modeImg2;
        } 
    }
}
