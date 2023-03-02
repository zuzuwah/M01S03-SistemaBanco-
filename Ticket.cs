using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M01S03
{
    public class Ticket
    {
        public DateTime Entrada { get; set; }

        public DateTime Saida { get; set; }

        public bool Ativo { get; set; }

        public Ticket(){}

        public Ticket (DateTime entrada, DateTime saida, bool ativo){
            this.Entrada = entrada;
            this.Saida = saida;
            this.Ativo = ativo;
        }

      

        private double CalcularTempo()
         {
           TimeSpan tempo;
            tempo = Saida - Entrada;
            return tempo.TotalMinutes;

         }

         public double CalcularValor(){
            double valor = CalcularTempo() * 0.9;
            return valor;
         }
            
    }

}
