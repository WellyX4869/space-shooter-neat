using UnityEngine;

public enum ModType
{
    AttackUp,
    AttackSpeedUp,
    CriticalStrike,
    CriticalDamage,
    Overheat,
    BulletUp,
    BulletSpeed,
    SingleStrike,
    DoublePattern,
    SplitterPattern,
    XFactor,
    GatlingPatern,
    HPUp,
    MoreHealing,
    LifeLeech,
    ProtectShield,
    Turret
}

namespace NaughtyAttributes
{
    [CreateAssetMenu(menuName = "Mod")]
    public class Mod : ScriptableObject
    {
        public string name;
        public string description;
        public ModType modType;

        [ShowIf("modType", ModType.AttackUp)]       public float damagePercentageIncrease;

        [ShowIf("modType", ModType.AttackSpeedUp)]  public float attackCooldownPercentageDecrease;

        [ShowIf("modType", ModType.CriticalStrike)] public float criticalChancePercentageIncrease;

        [ShowIf("modType", ModType.CriticalDamage)] public float criticalDamagePercentageIncrease;

        [ShowIf("modType", ModType.Overheat)]       public float overheatDamagePercentageIncrease;

        [ShowIf("modType", ModType.BulletUp)]       public int bulletsIncrease;

        [ShowIf("modType", ModType.BulletSpeed)]    public float bulletSpeedPercentageIncrease;

        [ShowIf("modType", ModType.SingleStrike)]   public float singleStrikePercentageIncrease;

        [ShowIf("modType", ModType.DoublePattern)]  public float damagePercentageDoublePatternDecrease;

        [ShowIf("modType", ModType.SplitterPattern)] public float damagePercentageSplitterPatternDecrease;

        [ShowIf("modType", ModType.XFactor)]        public float damagePercentageXFactorDecrease;

        [ShowIf("modType", ModType.GatlingPatern)]  public float damagePercentageGatlingPatternDecrease;

        [ShowIf("modType", ModType.HPUp)]           public float healthUpPercentageIncrease;
        [ShowIf("modType", ModType.HPUp)]           public float healthUpRecoverPercentageIncrease;

        [ShowIf("modType", ModType.MoreHealing)]    public float offerHealthRecoverPercentageIncrease;

        [ShowIf("modType", ModType.LifeLeech)]      public float lifeLeechPercentageIncrease;

        [ShowIf("modType", ModType.ProtectShield)]  public float protectShieldCooldown;
        [ShowIf("modType", ModType.ProtectShield)] public float protectShieldDuration;

        [ShowIf("modType", ModType.Turret)] public int turretsAmountIncrease;
        [ShowIf("modType", ModType.Turret)] public int turretsHitPoint;
        [ShowIf("modType", ModType.Turret)] public int turretsRespawnDuration;
    }
}
