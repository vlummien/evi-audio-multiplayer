using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
https://answers.unity.com/questions/548794/how-to-move-a-camera-only-using-the-arrow-keys.html
*/
public class MoveClass : MonoBehaviour {


    public float speed = 0.1f;
     
     public void FixedUpdate()
     {
         if(Input.GetKey(KeyCode.RightArrow))
         {
             transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
	     Debug.Log("Dreta");
         }
         if(Input.GetKey(KeyCode.LeftArrow))
         {
             transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
         }

// Up & Down --> Y (puja i baixa) el canvie a Z (entra i eix)
	 if(Input.GetKey(KeyCode.DownArrow))
         {
//             transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
             transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);	     
         }
         if(Input.GetKey(KeyCode.UpArrow))
         {
//             transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
             transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);	     
         }
     } // FixedUpdate


/*
       https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update () {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

// Però si rote en el ratolí, ja no està acord els moiments en el teclat, que segueixen sent absoluts.
*/

/*
https://answers.unity.com/questions/1344322/free-mouse-rotating-camera.html?childToView=1345542


     public float sensitivity = 10f;
     void Update ()
     {
         var c = Camera.main.transform;
         c.Rotate(0, Input.GetAxis("Mouse X")* sensitivity, 0);
         c.Rotate(-Input.GetAxis("Mouse Y")* sensitivity, 0, 0);
         c.Rotate(0, 0, -Input.GetAxis("QandE")*90 * Time.deltaTime);
         if (Input.GetMouseButtonDown(0))
             Cursor.lockState = CursorLockMode.Locked;
     }

       
/*
https://answers.unity.com/questions/1349498/rotate-camera-up-and-down-with-mouse-input-with-to.html

*/


/*     
       https://answers.unity.com/questions/1189946/click-and-drag-to-rotate-camera-like-a-pan.html
*/
       //       public float speed = 3.5f;
     private float X;
     private float Y;
 
     void Update() {
         if(Input.GetMouseButton(0)) {
             transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
	     //https://docs.unity3d.com/ScriptReference/Transform.Rotate.html?_ga=2.208232727.480724367.1542642501-1610484219.1475654610
	     //,Space.World  );
             X = transform.rotation.eulerAngles.x;
             Y = transform.rotation.eulerAngles.y;
             transform.rotation = Quaternion.Euler(X, Y, 0);
         }
     }    



/*
https://answers.unity.com/questions/1189946/click-and-drag-to-rotate-camera-like-a-pan.html
     public float rotateSpeed = 3.5f;     
 
     void Update() {
         if(Input.GetMouseButton(0)) {
	     transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*rotateSpeed, 0), Space.World); 
         }
     }    
*/

     
 }
 
