using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OTDS.Weapon.Interfaces;
using OTDS.Bullets.Interfaces;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OTDS.Weapon.Client.Showcase
{
    public class Local_IWeaponChange : MonoBehaviour, IWeaponChange
    {
        [SerializeField] private SO_Weapon[] avaiableWeapons;
        [SerializeField] private SO_Weapon selectedWeapon;

        [System.Serializable] public class UnityEvent_GameObject : UnityEvent<GameObject> { }
        [SerializeField] UnityEvent_GameObject SetBulletInClient;

        [Inject] private IBulletSpawner bulletSpawner;

        public void ChangeWeapon()
        {
            var visual = selectedWeapon.GunVisual;
            var bullet = selectedWeapon.Bullet;
            SetBulletInClient.Invoke(bullet.BulletVisualPrefab);
        }


#if UNITY_EDITOR
        [CustomEditor(typeof(Local_IWeaponChange))]
        public class Local_IWeaponChangeEditor : Editor
        {
            Local_IWeaponChange script;
            private void OnEnable()
            {
                script = (Local_IWeaponChange)target;
            }

            public override void OnInspectorGUI()
            {
                var disable = !Application.isPlaying;
                using (new EditorGUI.DisabledGroupScope(disable))
                {
                    // for (int i = 0; i < script.avaiableWeapons.Length; i++)
                    // {
                    //     var weapon = script.avaiableWeapons[i];
                    //     var weaponName = weapon.name;
                    //     if (GUILayout.Button(disable ? $"{weaponName} (OnlyPlayMode)" : $"{weaponName}"))
                    //     {
                    //         script.selectedWeapon = weapon;
                    //         script.ChangeWeapon();
                    //     }

                    // }
                }
                base.OnInspectorGUI();
            }
        }
#endif
    }

}
