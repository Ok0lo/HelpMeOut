using System;
using UnityEngine;

public class AbstractPlayerEntity : MonoBehaviour {

    public event EventHandler<AbstractPlayerEntity> OnPlayerPressedInteractButton;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) OnPlayerPressedInteractButton?.Invoke(this, this);
    }

}
