using System;
using System.Collections;
using System.Collections.Generic;
using OTDS.Weapons.Data;
using UnityEngine;
using Zenject;

namespace OTDS.Weapons.Showcase
{

    public class Local_IKnifeAttack : MonoBehaviour, Interfaces.IKnifeAttack
    {
        private bool canAttack = true;
        private KnifeData knifeData;
        private Action endAction;

        public void SingleAttack(KnifeData data, Action Start, Action End)
        {
            knifeData = data;
            if (canAttack)
            {
                StartCoroutine("AttackGate");
                endAction = End;
                Start.Invoke();
            }
        }

        private IEnumerator AttackGate()
        {
            canAttack = false;
            yield return new WaitForSeconds(knifeData.TimeVisible);
            endAction.Invoke();
            yield return new WaitForSeconds(knifeData.RecoverTime);
            canAttack = true;
        }
    }

}