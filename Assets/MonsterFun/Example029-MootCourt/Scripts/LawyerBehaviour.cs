using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// As a lawyer, the user must complete a number of activities:
// - move to seat. Until judge ready.
// - move to lectern, present. Until complete.
// - move to evidence table, present evidence. Until complete.
// - move to jury, address jury. Until complete.
// - move to seat. Until verdict delivered.
// - task complete.

public class LawyerBehaviour : MonoBehaviour {

  // States of the lawyer.
  enum LawyerState { NoStateSet, Starting, InSeatGettingReady, ReadyToPresent, PresentingAtLectern, ReadyForEvidence, Evidence, MoveToJury, AddressJury, JuryAddressOver, WaitingVerdict, AllDone };

  // Current state in the state transition graph.
  private LawyerState state = LawyerState.NoStateSet;

  // An object used to visually show the next point that has to be visited.
  private GameObject targetPoint;

  // External values required.
  // A text object to hold instructions being provided to the user.
  public Text instructionText;

  // A prefab object to represent points of interest.
  public GameObject targetPointMarkerPrefab;

  // Positions of key elements to be visited.
  public GameObject chairPosition;
  public GameObject lecternPosition;
  public GameObject evidenceTablePosition;
  public GameObject juryPosition;

  // The movie texture to be played when presenting evidence.
  public GameObject screenMovie;

  // The sound clips for the various states.
  public AudioSource judgeInstructions;
  public AudioSource legalArgument;
  public AudioSource juryPresentation;
  public AudioSource judgeVerdict;

  private float speedWhenAutonomous = 1.0f;

  // This function updates the lawyer simulation according to the state involved.
  void setState (LawyerState newState)
  {
      if (state == newState)
      {
          return; // nothing changed.
      }
      
      LawyerState oldState = state;
      state = newState;

      handleStateChangedEvent (oldState, newState);
  }
  
  // Make any changes to the scene corresponding to arriving in the given state.
  // The previous state is provided, but usually not required.
  void handleStateChangedEvent (LawyerState oldState, LawyerState state)
  {
      if (state == LawyerState.Starting)
      {
          targetPoint.transform.position = chairPosition.transform.position;
          targetPoint.SetActive (true);
          instructionText.text = "Make your way to your chair.";
      }
      else if (state == LawyerState.InSeatGettingReady)
      {
          targetPoint.SetActive (false);
          instructionText.text = "Wait until the judge is ready, and has provided instructions.";
          StartCoroutine (giveInstructions (judgeInstructions, LawyerState.ReadyToPresent));
      }
      else if (state == LawyerState.ReadyToPresent)
      {
          targetPoint.transform.position = lecternPosition.transform.position;
          targetPoint.SetActive (true);
          instructionText.text = "Move to the lectern.";
      }
      else if (state == LawyerState.PresentingAtLectern)
      {
          targetPoint.SetActive (false);
          instructionText.text = "Give a strongly worded, factual and coherent argument in support of your legal position.";
          StartCoroutine (giveInstructions (legalArgument, LawyerState.ReadyForEvidence));
      }
      else if (state == LawyerState.ReadyForEvidence)
      {
          targetPoint.transform.position = evidenceTablePosition.transform.position;
          targetPoint.SetActive (true);
          instructionText.text = "Move to the evidence table.";
      }
      else if (state == LawyerState.Evidence)
      {
          targetPoint.SetActive (false);
          instructionText.text = "Show off the evidence relevant to this case.";
          StartCoroutine (showMovie (screenMovie, LawyerState.MoveToJury));
      }
      else if (state == LawyerState.MoveToJury)
      {
          targetPoint.transform.position = juryPosition.transform.position;
          instructionText.text = "Find a vantage point from which to address the jury.";
          targetPoint.SetActive (true);
      }
      else if (state == LawyerState.AddressJury)
      {
          targetPoint.SetActive (false);
          instructionText.text = "Summarize your case, convincing the jury of the merits of your presentation.";
          StartCoroutine (giveInstructions (juryPresentation, LawyerState.JuryAddressOver));
      }
      else if (state == LawyerState.JuryAddressOver)
      {
          targetPoint.transform.position = chairPosition.transform.position;
          instructionText.text = "Return to your chair to await the judge's decision.";
          targetPoint.SetActive (true);
      }
      else if (state == LawyerState.WaitingVerdict)
      {
          targetPoint.SetActive (false);
          instructionText.text = "Listen while the judge presents his/her findings.";
          StartCoroutine (giveInstructions (judgeVerdict, LawyerState.AllDone));
      }
      else if (state == LawyerState.AllDone)
      {
          targetPoint.SetActive (false);
          instructionText.text = "The trial is now over.";
      }
  }

  // All event changes resulting from collisions. This is the collisionEventHandler function.
  void OnTriggerEnter (Collider other) 
  {
      if (other.tag == "TargetPoint")
      {
        if (state == LawyerState.Starting)
        {
            // in seat.
            setState (LawyerState.InSeatGettingReady);
        }
        else if (state == LawyerState.ReadyToPresent)
        {
            // at lectern.
            setState (LawyerState.PresentingAtLectern);
        }
        else if (state == LawyerState.ReadyForEvidence)
        {
            // at evidence table.
            setState (LawyerState.Evidence);
        }
        else if (state == LawyerState.MoveToJury)
        {
            // at jury.
            setState (LawyerState.AddressJury);
        }
        else if (state == LawyerState.JuryAddressOver)
        {
            // back at chair.
            setState (LawyerState.WaitingVerdict);
        }
      }
  }

  // Play an audio file, and produce an event to change to the particular state once complete.
  // This combines generating the audioComplete event and responding to it by setting the 
  // target state.
  IEnumerator giveInstructions (AudioSource message, LawyerState finalState)
  {
      message.Play ();
      while (message.isPlaying)
      {
        yield return new WaitForSeconds (1); 
      }
      // End of audio presentation occurs here.
      setState (finalState);
  }

  // Play an movie file, and produce an event to change to the particular state once complete.
  // This combines generating the videoComplete event and responding to it by setting the 
  // target state.
  IEnumerator showMovie (GameObject movieObject, LawyerState finalState)
  {
      MovieTexture movieTex = movieObject.GetComponent <Renderer> ().material.mainTexture as MovieTexture;
      movieTex.Play ();
      while (movieTex.isPlaying)
      {
        yield return new WaitForSeconds (1); 
      }
      // End of presentation event occurs here.
      setState (finalState);
  }  
  
  void Start () {
    targetPoint = Instantiate (targetPointMarkerPrefab);
    targetPoint.SetActive (false);
    
    setState (LawyerState.Starting);
  }
  
  void Update () {
  
    // handle any updates specific to the current state.
    switch (state)
    {
      // do this for all states.
      default:
      {
        Vector3 dir = targetPoint.transform.position - transform.position;
        if (dir.magnitude >= 1)
        {
          dir = dir / dir.magnitude;
        }
        transform.position += Time.deltaTime * speedWhenAutonomous * dir; 
        transform.forward = dir;
      }
      break;
    }
  }
}

