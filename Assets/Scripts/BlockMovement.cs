//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class BlockMovement : MonoBehaviour
//{
//    public Material mat;


//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        TestRay();
//    }

//    //TODO: Make the ray prioritize areas with lowest altitude and ignore areas with cubes in them.
//    void TestRay()
//    {
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

//        RaycastHit[] hits = Physics.RaycastAll(ray, 1000);

//        //for (int i = 0; i < hits.Length; i++)
//        //{
//        //    RaycastHit hit = hits[i];
//        //    Renderer rend = hit.transform.GetComponent<Renderer>();

//        //    if (rend)
//        //    {
//        //        rend.material.shader = Shader.Find("Transparent/Diffuse");
//        //        Color tempColor = rend.material.color;
//        //        tempColor.a = 0.3F;
//        //        rend.material.color = tempColor;
//        //    }
//        //}

//        if (Input.GetMouseButtonUp(0) && hits.Length > 0)
//        {
//            var bestCube = hits.FirstOrDefault(t => t.distance == hits.Max(c => c.distance));
//            Renderer rend = bestCube.transform.GetComponent<Renderer>();

//            if (rend)
//            {
//                rend.material = mat;
//            }
//        }
//    }
//}
