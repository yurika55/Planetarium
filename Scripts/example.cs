using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class example : MonoBehaviour
{
    [SerializeField]
    private fade m_fade = null;

    // Start is called before the first frame update
    void Start()
    {
        Action on_completed = () => 
        {
            StartCoroutine( Wait3SecondsAndFadeOut() );
        };
        m_fade.FadeIn( 2.0f, on_completed );
    }

    private IEnumerator Wait3SecondsAndFadeOut() 
    {
        yield return new WaitForSeconds( 3.0f );
        m_fade.FadeOut( 2.0f );
    }
}
