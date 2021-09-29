using UnityEngine;

[RequireComponent(typeof(Interact))]
public class AbstractItem : MonoBehaviour {

    private Interact _interact;

    private void Awake() {
        _interact = GetComponent<Interact>();
    }

    private void Start() {
        _interact.OnInteracted += OnInteracted;
    }

    private void OnInteracted(object sender, AbstractPlayerEntity player) {
        print(gameObject.name + " - did action");
    }

}
