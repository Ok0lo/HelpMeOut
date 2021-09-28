using UnityEngine;

public class OfferEffect : MonoBehaviour {
        
    // How to do better? 
    public enum Type {
        interact,
        dialogue,
        fight
    }
    
    [SerializeField] private float offsetUp;
    
    private Transform _offerEffectTransform;

    public void Initialization(Type offerType) {
        Transform offerTransform; 
        switch (offerType) { // Help me out
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
        
        _offerEffectTransform = Instantiate(offerTransform, transform.position + transform.up * offsetUp, transform.rotation, transform);
        HideOffer();
    }
    
    public void ShowOffer() => _offerEffectTransform.gameObject.SetActive(true);
    public void HideOffer() => _offerEffectTransform.gameObject.SetActive(false);

}
