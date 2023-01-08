using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    public new Transform camera;
    public float moveSpeed;
    public Transform minPos, maxPos;
    public bool moveVertically, moveHorizontally;

    void Start()
    {
        AudioManager.instance.PlayLevelSelectMusic();
    }

    void Update()
    {
        Vector2 adjustedMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

        if (moveHorizontally)
        {
            if (adjustedMousePos.x > 0.75f)
            {
                if (adjustedMousePos.x > 0.9f)
                {
                    camera.position += camera.right * moveSpeed * Time.deltaTime;
                }
                else
                {
                    camera.position += camera.right * moveSpeed * Time.deltaTime * .5f;
                }
            }

            if (adjustedMousePos.x < .25f)
            {
                if (adjustedMousePos.x < 0.1f)
                {
                    camera.position -= camera.right * moveSpeed * Time.deltaTime;
                }
                else
                {
                    camera.position -= camera.right * moveSpeed * Time.deltaTime * .5f;
                }
            }
        }

        if (moveVertically)
        {
            if (adjustedMousePos.y > 0.75f)
            {
                if (adjustedMousePos.y > 0.9f)
                {
                    camera.position += camera.forward * moveSpeed * Time.deltaTime;
                }
                else
                {
                    camera.position += camera.forward * moveSpeed * Time.deltaTime * .5f;
                }
            }

            if (adjustedMousePos.y < .25f)
            {
                if (adjustedMousePos.y < 0.1f)
                {
                    camera.position -= camera.forward * moveSpeed * Time.deltaTime;
                }
                else
                {
                    camera.position -= camera.forward * moveSpeed * Time.deltaTime * .5f;
                }
            }
        }

        camera.position = new Vector3(Mathf.Clamp(camera.position.x, minPos.position.x, maxPos.position.x), camera.position.y, Mathf.Clamp(camera.position.z, minPos.position.z, maxPos.position.z));
    }
}
