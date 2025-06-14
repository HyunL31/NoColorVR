using UnityEngine;

namespace MimicSpace
{
    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] Movement movementScript;
        [SerializeField] float damageCooldown = 2f;

        [SerializeField] Material material; // Material to change color for status effects

        private bool canDealDamage = true;
        private float damageTimer = 0f;

        private bool slowApplied = false;
        private bool confuseApplied = false;
        private bool stunApplied = false;
        private bool trapApplied = false;

        private void Update()
        {
            if (!canDealDamage)
            {
                damageTimer += Time.deltaTime;
                if (damageTimer >= damageCooldown)
                {
                    canDealDamage = true;
                    damageTimer = 0f;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject hitObject = other.gameObject;

            // Player attacks hit on trigger enter: apply status effects
            // This is temp Tag!!
            if (hitObject.CompareTag("SlowAttack"))
            {
                ApplySlowAttack();
            }
            else if (hitObject.CompareTag("ConfuseAttack"))
            {
                ApplyConfuseAttack();
            }
            else if (hitObject.CompareTag("StunAttack"))
            {
                ApplyStunAttack();
            }
            else if (hitObject.CompareTag("TrapAttack"))
            {
                ApplyTrapAttack();
            }

            // Enemy touches player: try to damage
            if (hitObject.CompareTag("Player"))
            {
                TryDamagePlayer(hitObject);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            GameObject hitObject = other.gameObject;

            // While player stays in collider, repeatedly try to damage player if cooldown over
            if (hitObject.CompareTag("Player"))
            {
                TryDamagePlayer(hitObject);
            }
        }

        // Apply slow effect, and change color: red
        public void ApplySlowAttack()
        {
            if (slowApplied) return;

            slowApplied = true;
            float time = movementScript.ApplySlow();
            ChangeColor(Color.red);
            Debug.Log("Hit Slow");
            Invoke("ResetStatusEffects", time);
        }

        // Apply confuse effect, and change color: yellow
        public void ApplyConfuseAttack()
        {
            if (confuseApplied) return;

            confuseApplied = true;
            float time = movementScript.ApplyConfuse();
            ChangeColor(Color.yellow);
            Debug.Log("Hit Confuse");
            Invoke("ResetStatusEffects", time);
        }

        // Apply stun effect, and change color: green
        public void ApplyStunAttack()
        {
            if (stunApplied) return;

            stunApplied = true;
            float time = movementScript.ApplyStun();
            ChangeColor(Color.green);
            Debug.Log("Hit Stun");
            Invoke("ResetStatusEffects", time);
        }

        // Apply trap(=stun) effect, and change color: green
        public void ApplyTrapAttack()
        {
            if (trapApplied) return;

            trapApplied = true;
            float time = movementScript.ApplyTrap();
            ChangeColor(Color.blue);
            Debug.Log("Hit Trap");
            Invoke("ResetStatusEffects", time);
        }

        public void TryDamagePlayer(GameObject playerObj)
        {
            if (!canDealDamage) return;

            canDealDamage = false;
            damageTimer = 0f;
            Debug.Log("Damage"); // Need to add logic
        }


        private void ChangeColor(Color newColor)
        {
            if (material != null)
            {
                material.color = newColor;
            }
        }

        private void ResetStatusEffects()
        {
            slowApplied = false;
            confuseApplied = false;
            stunApplied = false;
            trapApplied = false;

            ChangeColor(Color.black);
            Debug.Log("Status effects reset");
        }
    }
}