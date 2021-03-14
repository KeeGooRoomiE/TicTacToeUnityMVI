using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideController : MonoBehaviour
{
    [SerializeField] private FieldController field;
    [SerializeField] private int number;
    [SerializeField] private Image img;
    [SerializeField] private Color tc;              //--target colour
    [SerializeField] private Color sc;              //--source colour

    void Start() {
        img = gameObject.GetComponent<Image>();
        img.color = tc;
    }
    #region //--show proper colour depending on player side
    void Update() {
        if (number == 0) {
            //if blue move is right now
            if (field.isXTurn) {
                img.color = tc;
            } else {
                img.color = sc;
            }
        } else {
            //if red move is right now
            if (field.isXTurn) {
                img.color = sc;
            } else {
                img.color = tc;
            }
        }
    }
    #endregion
}
