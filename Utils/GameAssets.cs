using UnityEngine;

public class GameAssets : MonoBehaviour {

    private static GameAssets instance;
    
    public static GameAssets Singleton { 
        get {
            if(instance == null) instance = Resources.Load<GameAssets>("GameAssets");
            return instance;
        }
    }

    // For -> OfferEffect
    public Transform pfInteractOffer, pfDialogueOffer, pfFightOffer;

}
