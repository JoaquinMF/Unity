using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   

public class Disparo : MonoBehaviour
    {
        public GameObject capsule;
        
        private long momentoUltimoDisparo;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Si el click derechi esta pulsado, entonces.
            //GetMouseButtonDown detecta solo el instante
            //En que se hace click


            if (Input.GetMouseButtonDown(0))
            {
                this.momentoUltimoDisparo =
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
                //this.transform.LookAt(this.objetivoDisparo.transform.position);
                GameObject balaActual = Instantiate(capsule, this.transform.position + this.transform.forward * 1.2f, this.transform.rotation);
                balaActual.GetComponent<Rigidbody>().AddForce(balaActual.transform.forward * 3000);
            }
            //GetMouseButton se ejecuta continuamente mientras
            //El botón izquierdo esté pulstado
            
            if (Input.GetMouseButton(0))
            {
                //Instanciando objetos a una distancia (también se puede usar transform.forward, dependiendo de donde estén los ejes del arma.
                long momentoActual =
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
                this.transform.LookAt(this.objetivoDisparo.transform.position);
               
                if (momentoActual - momentoUltimoDisparo > 500)
                {
                    GameObject balaActual = Instantiate(capsule, this.transform.position + this.transform.forward * 1.2f, this.transform.rotation);
                    balaActual.GetComponent<Rigidbody>().AddForce(balaActual.transform.forward * 3000);
                    this.momentoUltimoDisparo = momentoActual;
                }
            }
        }
    }