using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public int health;
    public int damage;
    public float attackSpeed;
    public float movementSpeed;
    public float attackCooldown;
}
