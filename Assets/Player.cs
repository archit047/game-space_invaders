using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    [SerializeField] GameObject[] guns;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionyawFactor = -5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlRollFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;
    private bool isActive;



    // Use this for initialization
    void Start () {
		
	}

    

 

    // Update is called once per frame
    void Update()
    {
        // for horizonatal direction

        if (isControlEnabled)
        {
            processTranslation();
            processRotation();
            ProcessFiring();
        }
    }

    void OnPlayerDeath()  // called by string reference
    {
        isControlEnabled = false;
    }

    private   void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow =  yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;


        float yaw = transform.localPosition.x * positionyawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void processTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawNextXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNextXPos, -xRange, +xRange);


        // for vertical direction
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffset = yThrow * speed * Time.deltaTime;
        float rawNextyPos = transform.localPosition.y + yoffset;
        float clampedYpos = Mathf.Clamp(rawNextyPos, -yRange, +yRange);


        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
           ActivateGuns(true);
        }
        else
        {
            DeactivateGuns();
        }
    }

    /*private void SetGunsActive( bool isActive)
    {
        foreach(GameObject gun in guns)  // care may effect death FX
            {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = isActive;
        }
    } */

   private void ActivateGuns(bool isActive)
    {
       foreach (GameObject gun in guns)
        {
             gun.SetActive(true);
           /* var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled= isActive; */
 
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    } 

    
}
       
      
  
