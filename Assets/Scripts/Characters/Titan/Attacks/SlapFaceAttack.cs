﻿using UnityEngine;

namespace Assets.Scripts.Characters.Titan.Attacks
{
    public class SlapFaceAttack : BoomAttack
    {
        public SlapFaceAttack()
        {
            BodyParts = new[] { BodyPart.ArmRight };
        }
        protected override string Effect { get; set; } = "FX/boom3";
        protected override float BoomTimer { get; set; } = 0.66f;

        public override bool CanAttack()
        {
            if (Titan.TargetDistance >= Titan.AttackDistance * 2) return false;
            if (IsDisabled()) return false;
            if (Titan.Target.transform.position.y <= Titan.TitanBody.Neck.position.y - 3f * Titan.Size
                || Titan.TargetDistance >= Titan.AttackDistance * 0.5f) return false;

            Vector3 vector18 = Titan.Target.transform.position - Titan.transform.position;
            var angle = -Mathf.Atan2(vector18.z, vector18.x) * 57.29578f;
            var between = -Mathf.DeltaAngle(angle, Titan.gameObject.transform.rotation.eulerAngles.y - 90f);

            if (Mathf.Abs(between) < 30f)
            {
                if (Vector3.Distance(Titan.Target.transform.position, Titan.TitanBody.CheckFront.position) < (2.5f * Titan.Size))
                {
                    AttackAnimation = "attack_slap_face";
                    TitanBodyPart = Titan.TitanBody.AttackSlapFace;
                    return true;
                }
            }
            else if (between > 0f)
            {
                if (Vector3.Distance(Titan.Target.transform.position, Titan.TitanBody.CheckBackRight.position) < (2.8f * Titan.Size))
                {
                    AttackAnimation = "attack_slap_back";
                    TitanBodyPart = Titan.TitanBody.AttackSlapBack;
                    return true;
                }
            }
            else if (Vector3.Distance(Titan.Target.transform.position, Titan.TitanBody.CheckBackLeft.position) < (2.8f * Titan.Size))
            {
                AttackAnimation = "attack_slap_back";
                TitanBodyPart = Titan.TitanBody.AttackSlapBack;
                return true;
            }
            return false;
        }
    }
}
