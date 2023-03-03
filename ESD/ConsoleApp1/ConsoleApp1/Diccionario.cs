using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Diccionario
    {
        private Hashtable ht = new Hashtable();
        public Diccionario() { }
        
        public void GenerarDiccionario()
        {
            ht.Add("Arquitectura", "Arte de construir edificios");
            ht.Add("Baraja", "Conjunto de cartas del juego de naipes");
            ht.Add("Cementerio", "Lugar destino para enterrar cadáveres");
            ht.Add("Dedicatoria", "Carta o nota dirigida a quien se dedica una obra");
            ht.Add("Espejismo", "Ilusión optica");
            ht.Add("Fineza", "Regalo pequeño y de cariño");
            ht.Add("Gratificar","Recompesar un servicio extraordinario");
            ht.Add("Honor", "Cualidad moral que nos lleva a cumplir con el deber");
            ht.Add("Insociable", "Intratable, huraño");
            ht.Add("Jugo", "Liquido contenido en ciertas sustancias animales o vegetales, que puede extraerse por presión, cocción, etc.");
            ht.Add("Koala", "Mamífero marsupial que vive la mayor parte de su vida en los árboles de los bosques australianos");
            ht.Add("Lanoso", "Que abunda en lana o vello");
            ht.Add("Milagro", "Hecho sensible del poder divino, superior al orden natural");
            ht.Add("Nadar", "Mantenerse una persona o un animal sobre el agua, o ir por ella sin tocar el fondo");
            ht.Add("Ñandú", "Avestruz americano algo menor que el de África y de plumaje gris poco fino");
            ht.Add("Objetivo", "Relativo al obejto en sí  no al modo personal de pensar");
            ht.Add("Pudor", "Honestidad, recato, modestia");
            ht.Add("Quilate", "Unidad de peso para las perlas y piedras finas equivalente a 205 miligramos");
            ht.Add("Rama", "Cada una de las partes que nacen del tronco o tallo principal de una planta y en las cuales brotan hojas, flores y frutos");
            ht.Add("Saldo", "Resto de mercancías que se venden a bajo valor");
            ht.Add("Talonario", "Se dice del documento que se corta de un libro, quedando en él una parte de cada hoja para acreditar con ella su legitimidad");
            ht.Add("Umbral", "Parte inferior en la puerta");
            ht.Add("Vadear", "Pasar una corriente de agua por un sitio donde se puede hacer pie");
            ht.Add("Wagón", "Vagón");
            ht.Add("Xenofobia", "Odio u hostilidad hacia los extranjeros");
            ht.Add("Yacer", "Estar hechada una persona, Estar un cadáver en la sepultura");
            ht.Add("Zafra", "Vasija metálica de gran tamaño, propia para guardar el aceite");
        }
        public Hashtable getHt()
        {
            return ht;
        }
    }
}
