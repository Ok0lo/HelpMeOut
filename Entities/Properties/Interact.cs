using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The "abstract player entity" can interact with the object if it's in the observed area
/// </summary>
[RequireComponent(typeof(OfferEffect))]
public class Interact : MonoBehaviour {
    
    // eventArgs -> AbstractPlayerEntity, for Multiplayer
    public event EventHandler<AbstractPlayerEntity> OnInteracted;

    [SerializeField] private float observeRadius;
    [SerializeField] private OfferEffect.Type offerEffectType;
    
    private OfferEffect _offerEffect;
    private SphereCollider _observeSphere;

    private void Awake() {
        _offerEffect = GetComponent<OfferEffect>(); // Check: OfferEffect class
        _offerEffect.Initialization(offerEffectType);
        
        _observeSphere = ColliderCreator.CreateSphereColliderOnGameObject(gameObject, observeRadius, true);
    }

    private void OnPlayerInteract(object sender, AbstractPlayerEntity player) {
        if(IsClosestInteractToPlayer(player) == true) OnInteracted?.Invoke(this, player);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out AbstractPlayerEntity player) == false) return;

        player.OnPlayerPressedInteractButton += OnPlayerInteract;
        _offerEffect.ShowOffer();
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.TryGetComponent(out AbstractPlayerEntity player) == false) return;

        player.OnPlayerPressedInteractButton -= OnPlayerInteract;
        _offerEffect.HideOffer();
    }

    // How to make this method easier?
    private bool IsClosestInteractToPlayer(AbstractPlayerEntity player) { 
        List<Vector3> interactObjectList = new List<Vector3>();
        
        Collider[] colliderArray = (Collider[]) Physics.OverlapSphere(transform.position, observeRadius).Except(new[] { _observeSphere } );
        
        foreach (Collider candidate in colliderArray)
            if (candidate.gameObject.TryGetComponent(out Interact interact)) interactObjectList.Add(candidate.transform.position);
        
        // Check: Dotting class
        return Dotting.IsClosestPositionTo(interactObjectList, transform.position, player.transform.position);
    }

}
