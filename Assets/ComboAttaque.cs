using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttaque : MonoBehaviour
{
    int comboStep;
    bool comboPossible;
    public Animator playerAnim;

   
    
        public void Attaque()
        {
            if (comboStep == 0)
            {
                playerAnim.Play("AttaqueA");
                comboStep = 1;
            }

            else if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }

        }

        public void ComboPossible()
        {
            comboPossible = true;
        }
        public void Combo()
        {
            if (comboStep == 2)
            {
                playerAnim.Play("AttaqueB");
            }
            if (comboStep == 3)
            {
                playerAnim.Play("AttaqueC");
            }
        }
        public void ComboReset()
        {
            comboPossible = false;
            comboStep = 0;
        }
 }
   

