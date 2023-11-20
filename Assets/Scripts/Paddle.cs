using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    SpriteRenderer playerSpriteRender;
    //The Color to be assigned to the Renderer’s Material

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        playerSpriteRender = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        /*Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(mousePos.y, -3.8f, 3.8f), transform.position.z);*/

        Vector2 mousePos2d = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(mousePos2d.y, LimitDown(), LimitUp()));

        float LimitDown()
        {
            return -CameraBounds().y + playerSpriteRender.bounds.extents.y - 0.2f;
        }

        float LimitUp()
        {
            return CameraBounds().y - playerSpriteRender.bounds.extents.y + 0.2f;
        }

        Vector2 CameraBounds()
        {
            return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        /*float LimitDown()
        {
            return CameraOrigin().y + playerSpriteRender.bounds.extents.y;
        }

        float LimitUp()
        {
            return CameraBounds().y - playerSpriteRender.bounds.extents.y;
        }

        Vector2 CameraBounds()
        {
            return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        Vector2 CameraOrigin()
        {
            return Camera.main.ScreenToWorldPoint(Vector2.zero);
        }*/
    }

    /*static void setToMousePosition(Transform transform, float minX = 0, float maxX = 0, float minY = 0, float maxY = 0) {
        var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (minX != 0 || maxX != 0) {
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        }
        if (minY != 0 || maxY != 0) {
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        }
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    public static void moveSpriteIntoWorldLimits(SpriteRenderer sprite) {
        var topLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var worldSize = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        var width = sprite.bounds.size.x;
        var height = sprite.bounds.size.y;
        
        setToMousePosition(
            sprite.transform, 
            topLeftCorner.x + width/2,
            worldSize.x - width/2,
            topLeftCorner.y,
            worldSize.y - height
        );
    }*/
}
