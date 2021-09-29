using UnityEngine;

/// <summary>
/// Sign above the body 
/// </summary>
public class OfferEffect : MonoBehaviour {
        
    public enum Type {
        interact,
        dialogue,
        fight
    }
    
    [SerializeField] private float offsetUp;
    
    private Transform _offerEffectTransform;

    public void Initialization(Type offerType, float specialOffsetUp = 1) {
        Vector3 offsetUpVector = transform.up * offsetUp * specialOffsetUp;
        _offerEffectTransform = Instantiate(GetTransformByOfferType(offerType), transform.position + offsetUpVector, transform.rotation, transform);
        
        HideOffer();
    }
    
    public void ShowOffer() => _offerEffectTransform.gameObject.SetActive(true);
    public void HideOffer() => _offerEffectTransform.gameObject.SetActive(false);

    // Help me out
    private Transform GetTransformByOfferType(Type offerType) {
        Transform offerTransform;
        
        switch (offerType) { 
            default:
                offerTransform = GameAssets.Singleton.pfInteractOffer;
                break;
            
            case Type.dialogue:
                offerTransform = GameAssets.Singleton.pfDialogueOffer;
                break;
            case Type.fight:
                offerTransform = GameAssets.Singleton.pfFightOffer;
                break;
        }

        return offerTransform;
    }

}
