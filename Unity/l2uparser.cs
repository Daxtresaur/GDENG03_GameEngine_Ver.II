using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class l2uparser : MonoBehaviour
{
   [SerializeField] string loadPath = "Assets/test.iet";



    public void Spawn()
    {
        string file; 
        StreamReader reader = new StreamReader(loadPath);
        file = reader.ReadToEnd();
        if (file.Length > 0) Debug.Log("Read the file successfully.");
        reader.Close();

        string[] lines = file.Split('\n');

        Debug.Log(lines.Length);

       

        string objectName = "";
		int objectType = 0;
		Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;
		Vector3 scale = Vector3.one;
		string isActive = "";
		string hasPhysics = "";
		string isPhysicsActive = "";
		string isStatic = "" ;
		string isGravityActive = "" ;
		float mass = 0;

		int current_pos = 0;

		for (int i =0; i< lines.Length; i++)
		{
			if(current_pos == 0)
			{
				objectName = lines[i];
				current_pos++;
			}
			else if(current_pos == 1)
			{
				string[] temp = lines[i].Split(" ");
				objectType = int.Parse(temp[1]);
				Debug.Log(objectType);
                current_pos++;
            }
            else if (current_pos == 2)
            {
                string[] temp = lines[i].Split(" ");
                pos.x = float.Parse(temp[1]);
                pos.y = float.Parse(temp[2]);
                pos.z = float.Parse(temp[3]);
                current_pos++;

            }
            else if (current_pos == 3)
            {
                string[] temp = lines[i].Split(" ");
				rot = Quaternion.Euler(float.Parse(temp[1]) * 180 / Mathf.PI, float.Parse(temp[2]) * 180 / Mathf.PI, float.Parse(temp[3]) * 180 / Mathf.PI);
                current_pos++;
            }
            else if (current_pos == 4)
            {
                string[] temp = lines[i].Split(" ");
                scale.x = float.Parse(temp[1]);
                scale.y = float.Parse(temp[2]);
                scale.z = float.Parse(temp[3]);
                current_pos++;

            }
            else if (current_pos == 5)
            {
                string[] temp = lines[i].Split(" ");
                isActive = temp[1];
                current_pos++;
            }
            else if (current_pos == 6)
            {
                string[] temp = lines[i].Split(" ");
                hasPhysics = temp[1];
                current_pos++;
            }
            else if (current_pos == 7)
            {
                string[] temp = lines[i].Split(" ");
                isPhysicsActive = temp[1];
                current_pos++;
            }
            else if (current_pos == 8)
            {
                string[] temp = lines[i].Split(" ");
                isStatic = temp[1];
                current_pos++;
            }
            else if (current_pos == 9)
            {
                string[] temp = lines[i].Split(" ");
                isGravityActive = temp[1];
                current_pos++;
            }
            else if (current_pos == 10)
            {
                string[] temp = lines[i].Split(" ");
                mass = float.Parse(temp[1]);
                current_pos = 0;



                if (objectType == 1)
                {
                    bool cubeActive = false;
                    if (int.Parse(isActive) == 1)
                        cubeActive = true;
                    else if (int.Parse(isActive) == 0)
                        cubeActive = false;

                    //type = PrimitiveType.Cube;
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = objectName;
                    cube.SetActive(cubeActive);
                    cube.transform.position = pos;
                    cube.transform.rotation = rot;
                    cube.transform.localScale = scale;

                    if (bool.Parse(hasPhysics))
                    {
                     


                        cube.AddComponent<Rigidbody>();
                        Rigidbody component = cube.GetComponent<Rigidbody>();
                        component.mass = mass;

                        bool cubeKinematicActive = bool.Parse(isPhysicsActive);
                        bool cubeGravityActive = bool.Parse(isGravityActive);


                        component.isKinematic = cubeKinematicActive;
                        component.useGravity = cubeGravityActive;
                    }

                }
                
                else if (objectType == 2)
                {
                    bool planeActive = false;
                    if (int.Parse(isActive) == 1)
                        planeActive = true;
                    else if (int.Parse(isActive) == 0)
                        planeActive = false;

                    //type = PrimitiveType.Plane;
                    GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    plane.name = objectName;
                    plane.SetActive(planeActive);
                    plane.transform.position = pos;
                    plane.transform.rotation = rot;

                    scale.x *= 0.1f;
                    scale.z *= 0.1f;
                    plane.transform.localScale = scale;

                    if (bool.Parse(hasPhysics))
                    {
                        plane.AddComponent<Rigidbody>();
                        Rigidbody component = plane.GetComponent<Rigidbody>();
                        component.mass = mass;

                        bool planeKinematicActive = bool.Parse(isPhysicsActive);
                        bool planeGravityActive = bool.Parse(isGravityActive);


                        component.isKinematic = planeKinematicActive;
                        component.useGravity = planeGravityActive;
                    }

                }

                

            }
            



        }
        
    }


}
