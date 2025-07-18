﻿using UnityEngine;

namespace Yuumix.OdinToolkits.Examples.CustomExtensions.InterfaceReferenceExample
{
    // [CreateAssetMenu(fileName = "DamageableAsset", menuName = "SerializeInterface/Example/IDamageable", order = 0)]
    public class DamageableAsset : ScriptableObject, IDamageable
    {
        public void Damage(int damage)
        {
            Debug.Log($"DamageableAsset took damage: {damage}");
        }
    }
}