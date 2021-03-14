using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject button;
    [SerializeField] private Image btnImg;
    [SerializeField] private Image img;
    [SerializeField] private float alpha;
    [SerializeField] private Color blue;
    [SerializeField] private Color red;
    [SerializeField] private Color white;
    [SerializeField] private FieldController field;

    #region //--init objects in screen
    void Start()
    {
        button.SetActive(false);
        img = GetComponent<Image>();

        var col = img.color;
        alpha = 0f;
        col.a = alpha;
        img.color = col;
    }
    #endregion

    #region //--show screen with match
    public void MakeMatch() {
        var col = img.color;
        alpha = 1f;
        col.a = alpha;
        img.color = col;

        button.SetActive(true);
        btnImg.color = white;
        field.ResetMoves();
        field.ClearState();
    }
    #endregion

    #region //--show screen with tie
    public void MakeTie() {
        var col = img.color;
        alpha = 1f;
        col.a = alpha;
        img.color = col;

        button.SetActive(true);
        field.ResetMoves();
        btnImg.color = white;
        field.ClearState();
    }
    #endregion

    #region //--close all elements
    public void ResetMatch() {
        button.SetActive(false);
        var col = img.color;
        alpha = 0f;
        col.a = alpha;
        img.color = col;
        field.ResetMoves();
    }
    #endregion
}
