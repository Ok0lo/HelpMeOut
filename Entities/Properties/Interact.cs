using System;
using System.Collections.Generic;
using UnityEngine;

// "Abstract Player Entity" can interact to object, trough this class
[RequireComponent(typeof(OfferEffect))]
public class Interact : MonoBehaviour {

    public event EventHandler<OnInteractedEventArgs> OnCanInteract; // How make this :/
    public event EventHandler<OnInteractedEventArgs> OnInteracted;

    // Need Player for Multiplayer
    public class InteractEventArgs : EventArgs {
        public AbstractPlayerEntity player;
    }
    
    [SerializeField] private float observeRadius;
    [SerializeField] private OfferEffect.Type offerEffectType;

    private bool _isActive; // Hell is a _isActive, how make this better?
    private OfferEffect _offerEffect;
    private SphereCollider _observeSphere;
    private AbstractPlayerEntity _activePlayer;

    private void Awake() {
        _offerEffect = GetComponent<OfferEffect>(); // Check: OfferEffect class
        _observeSphere = ColliderCreator.CreateSphereColliderOnGameObject(gameObject, observeRadius, true);
    }

    private void Update() {
        if (_isActive == false) return; // Help me out
        
        if (Input.GetKeyDown(KeyCode.E) && IsClosestInteractToPlayer()) {
            OnInteracted?.Invoke(this, 
            new InteractEventArgs { player = _activePlayer}
            );
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out AbstractPlayerEntity player)) {
            _isActive = true;
            _activePlayer = player;
            _offerEffect.ShowOffer();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.TryGetComponent(out AbstractPlayerEntity player)) {
            _isActive = false;
            _activePlayer = null;
            _offerEffect.HideOffer();
        }
    }

    // How to make this method easier?
    private bool IsClosestInteractToPlayer() { 
        List<Vector3> interactObjectList = new List<Vector3>();
        
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, observeRadius);
        foreach (Collider candidate in colliderArray) {
            if (candidate.gameObject.TryGetComponent(out Interact interact)) {
                Vector3 candidatePosition = candidate.transform.position;
                if(candidatePosition == transform.position) continue; // How skip self?

                interactObjectList.Add(candidatePosition);   
            }
        }

        // Check: Dotting class
        return Dotting.IsClosestPositionTo(interactObjectList, transform.position, _activePlayer.transform.position);
    }

}
