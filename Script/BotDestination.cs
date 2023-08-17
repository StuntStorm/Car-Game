using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDestination : MonoBehaviour
{
  public Transform destination;  // The destination point the bot should move towards
  public float moveSpeed = 5f;   // The speed at which the bot moves

  private Vector3 startingPosition; // The starting position of the bot

  private void Start()
  {
      startingPosition = transform.position;
      StartCoroutine(MoveToDestination());
  }

  private IEnumerator MoveToDestination()
  {
      // Move to the destination
      while (Vector3.Distance(transform.position, destination.position) > 0.1f)
      {
          Vector3 direction = (destination.position - transform.position).normalized;
          transform.position += direction * moveSpeed * Time.deltaTime;
          yield return null;
      }

      transform.position = destination.position;

      // Wait for a brief pause at the destination
      yield return new WaitForSeconds(1f);

      // Move back to the starting position
      while (Vector3.Distance(transform.position, startingPosition) > 0.1f)
      {
          Vector3 direction = (startingPosition - transform.position).normalized;
          transform.position += direction * moveSpeed * Time.deltaTime;
          yield return null;
      }

      transform.position = startingPosition;

      // The bot has returned to its starting position
      Debug.Log("Bot has returned to its starting position.");
  }
}
