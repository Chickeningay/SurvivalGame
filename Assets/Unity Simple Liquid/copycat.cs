using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnitySimpleLiquid
{
    public class copycat : MonoBehaviour
    {
        public GameObject copysubject;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gameObject.GetComponent<LiquidContainer>().FillAmountPercent = copysubject.GetComponent<LiquidContainer>().FillAmountPercent;
            gameObject.GetComponent<LiquidContainer>().LiquidColor = copysubject.GetComponent<LiquidContainer>().LiquidColor;
        }
    }
}