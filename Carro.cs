using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M01S03
{
    public class Carro
    {
        public string Placa { get; set; }

        public string Modelo { get; set; }
 
        public string Cor { get; set; }

        public string Marca { get; set; }

        public List<Ticket> extratoTickets { get; set; }

        public Carro() {
            extratoTickets = new List<Ticket>();
        }

        public Carro(string placa, string modelo, string cor, string marca)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Marca = marca;
        }   

    }

}

