using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelector : MonoBehaviour
{
    [SerializeField] private FieldController field;

    //close element
    void Update()
    {
        if (field.modeSelected) {
            gameObject.SetActive(false);
        }
    }

    //load state
    void Awake() {
        field.LoadState();
    }
}
