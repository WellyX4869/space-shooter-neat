using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityHolder : MonoBehaviour
{
    public static AbilityHolder instance;
    public List<NaughtyAttributes.Mod> pickedMods = new List<NaughtyAttributes.Mod>();
    public List<NaughtyAttributes.Offer> pickedOffers = new List<NaughtyAttributes.Offer>();

    private void Awake()
    {
        instance = this;
        pickedMods.Clear();
        pickedOffers.Clear();
    }

    #region MOD
    public void PickThisMod(NaughtyAttributes.Mod mod)
    {
        ActivateThisMod(mod);
        pickedMods.Add(mod);
    }

    private void ActivateThisMod(NaughtyAttributes.Mod mod)
    {
        switch (mod.modType)
        {
            case ModType.AttackUp:
                ActivateModAttackUp(mod);
                break;
            case ModType.AttackSpeedUp:
                ActivateModAttackSpeedUp(mod);
                break;
            case ModType.CriticalStrike:
                ActivateModCriticalStrike(mod);
                break;
            case ModType.CriticalDamage:
                ActivateModCriticalDamage(mod);
                break;
            case ModType.Overheat:
                ActivateModOverheat(mod);
                break;
            case ModType.BulletUp:
                ActivateModBulletUp(mod);
                break;
            case ModType.BulletSpeed:
                ActivateModBulletSpeed(mod);
                break;
            case ModType.SingleStrike:
                ActivateModSingleStrike(mod);
                break;
            case ModType.DoublePattern:
                ActivateModDoublePattern(mod);
                break;
            case ModType.SplitterPattern:
                ActivateModSplitterPattern(mod);
                break;
            case ModType.XFactor:
                ActivateModXFactor(mod);
                break;
            case ModType.GatlingPatern:
                ActivateModGatlingPattern(mod);
                break;
            case ModType.HPUp:
                ActivateModHPUp(mod);
                break;
            case ModType.MoreHealing:
                ActivateModMoreHealing(mod);
                break;
            case ModType.LifeLeech:
                ActivateModLifeLeech(mod);
                break;
            case ModType.ProtectShield:
                ActivateModProtectShield(mod);
                break;
            case ModType.Turret:
                ActivateModTurret(mod);
                break;
        }
    }

    private void ActivateModAttackUp(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModAttackSpeedUp(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModCriticalStrike(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModCriticalDamage(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModOverheat(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModBulletUp(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModBulletSpeed(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModSingleStrike(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModDoublePattern(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModSplitterPattern(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModXFactor(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModGatlingPattern(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModHPUp(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModMoreHealing(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModLifeLeech(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModProtectShield(NaughtyAttributes.Mod mod)
    {

    }

    private void ActivateModTurret(NaughtyAttributes.Mod mod)
    {

    }
    #endregion

    #region OFFER
    public void PickThisOffer(NaughtyAttributes.Offer offer)
    {
        ActivateThisOffer(offer);
        pickedOffers.Add(offer);
    }

    private void ActivateThisOffer(NaughtyAttributes.Offer offer)
    {
        switch (offer.offerType)
        {
            case OfferType.AttackUp:
                ActivateOfferAttackUp(offer);
                break;
            case OfferType.AttackSpeedUp:
                ActivateOfferAttackSpeedUp(offer);
                break;
            case OfferType.CriticalStrike:
                ActivateOfferCriticalStrike(offer);
                break;
            case OfferType.Heal:
                ActivateOfferHeal(offer);
                break;
        }
    }

    private void ActivateOfferAttackUp(NaughtyAttributes.Offer offer)
    {
        
    }

    private void ActivateOfferAttackSpeedUp(NaughtyAttributes.Offer offer)
    {

    }

    private void ActivateOfferCriticalStrike(NaughtyAttributes.Offer offer)
    {

    }

    private void ActivateOfferHeal(NaughtyAttributes.Offer offer)
    {

    }
    #endregion
}
