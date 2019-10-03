using System;

namespace ExercicioEnumeracaoeComposicao.Entidades {
    class HorasContratadas {
        //criando as propriedades autoimplementadas "digite prop + tab + tab"
        public DateTime Data { get; set; }
        public double ValorPorHora { get; set; }
        public int Horas { get; set; }

        //criando os contrutores
        //construtor padrão
        public HorasContratadas() {

        }
        //construtor que recebe alguns argumentos
        public HorasContratadas(DateTime data, double valorPorHora, int horas) {
            Data = data;
            ValorPorHora = valorPorHora;
            Horas = horas;
        }

        //criando metodo para calcular valor total de horas trabalhadas
        public double ValorTotal() {
            return Horas * ValorPorHora;

        }
    }
}
