using UnityEngine;

public enum OfferType
{
    AttackUp,
    AttackSpeedUp,
    CriticalStrike,
    Heal
}

namespace NaughtyAttributes
{
    [CreateAssetMenu(menuName = "Offer")]
    public class Offer : ScriptableObject
    {
        public string name;
        public string description;

        public OfferType offerType;

        [ShowIf("offerType", OfferType.AttackUp)] public float damagePercentageIncrease;

        [ShowIf("offerType", OfferType.AttackSpeedUp)] public float attackCooldownDecrease;

        [ShowIf("offerType", OfferType.CriticalStrike)] public float criticalChancePercentageIncrease;

        [ShowIf("offerType", OfferType.Heal)] public float healthRecoverPercentageIncrease;

    }
}
