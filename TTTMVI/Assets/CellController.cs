using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    [SerializeField] public int state;
    [SerializeField] public int cellNum;
    [SerializeField] public GameObject stateX;
    [SerializeField] public GameObject stateO;
    [SerializeField] private Button interaction;
    [SerializeField] private FieldController field;

    // Start is called before the first frame update
    void Start() {
        //state = 0;
        interaction = gameObject.GetComponent<Button>();
    }

    #region //--set state of the cell
    public void UpdateCellState() {
        interaction.interactable = false;
        if (field.isXTurn) {
            state = 1;
            //stateX.SetActive(true);
        } else {
            state = 2;
            //stateO.SetActive(true);
        }
    }
    #endregion

    #region //--update without function
    void Update() {
        if (state != 0) {
            interaction.interactable = false;
            if (state == 1) {
                stateX.SetActive(true);
            }
            if (state == 2) {
                stateO.SetActive(true);
            }
        }
    }
    #endregion

    #region //--reset state of the cell
    public void ResetCellState() {
        state = 0;
        stateX.SetActive(false);
        stateO.SetActive(false);
        interaction.interactable = true;
    }
    #endregion

}
