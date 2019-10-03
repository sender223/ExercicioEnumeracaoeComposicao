using System;
using System.Collections.Generic;//importando biblioteca para usarmos a Lista.
using ExercicioEnumeracaoeComposicao.Entidades.Enums; //importando a subpasta enum para utilizar as classes.

namespace ExercicioEnumeracaoeComposicao.Entidades {
    class Trabalhador {
        //criando propriedades autoimplementadas (quando usamos get;set inicialmente)
        public string Nome { get; set; }
        public NivelTrabalhador Nivel { get; set; }
        public double BaseSalarial { get; set; }
        //agora preciso declarar uma outra propriedade do tipo "Departamento"
        //para isso podemos ver na notação UML que existe uma composição de objetos
        //então chamamos essa composição dessa maneira, Propriedade Departamento do tipo "Departamento"
        public Departamento Departamento { get; set; }
        //agora iremos implementar a classe HorasContratadas para dentro dessa classe usando composição
        //mas como são varios contratos iremos implementar uma lista de contratos usando composição
        //propriedade do tipo List<HorasContratadas> que recebe o nome Contratos de acordo com o UML
        //alem disso iremos instanciar a lista para que ela não receba valor nulo
        public List<HorasContratadas> Contratos { get; set; } = new List<HorasContratadas>();

        //criando os contrutores
        //construtor padrão
        public Trabalhador() {

        }
        //construtor com argumentos, lembrando que não podemos adicionar lista aos argumentos. ela começa vazia
        //depois que irá adicionar os dados a ela, então por via de regra, não é usual. 
        public Trabalhador(string nome, NivelTrabalhador nivel, double basesalarial, Departamento departamento) {
            Nome = nome;
            Nivel = nivel;
            BaseSalarial = basesalarial;
            Departamento = departamento;
        }
        //criando um metodo para adicionar um contrato.
        //ele irá receber um contrato como paramentro de entrada do tipo HorasContratadas,
        //terá as propriedades que estão dentro da classe HorasContratadas, que serão preenchidas
        //e depois irá adicionar esse contrato a lista de contratos.
        public void AdicionarContrato(HorasContratadas contrato) {
            //lista "Contratos" irá adicionar o contrato com o metodo ADD
            Contratos.Add(contrato);                    
        }
        //criando um metodo para remover um contrato usando a mesma ideologia do metodo acima.
        public void RemoverContrato(HorasContratadas contrato) {
            Contratos.Remove(contrato);
        }
        //esses metodos são bastante utilizados quando se fa associação entre objetos, quando se tem
        //um pra muitos, ex: listas e coleções.

        //criando um metodo para adiconar o ganho do contrato.
        //tipo double porque a resposta será um double, recebendo int ano, e int mes.
        public double Ganho(int mes, int ano) {
            //variavel soma que recebe a base salarial, 
            //mesmo não tendo contratos ele irá receber o salario base.
            double soma = BaseSalarial;
            //agora criaremos um foreach para percorrer cada contrato na lista de contratos.
            //para cada contrato do tipo "HorasContratadas" dentro da lista de "Contratos" faça
            foreach(HorasContratadas contrato in Contratos) {
                //se o ano e o mes do contrato for igual ao declarado dentro dos atributos do Ganho
                if (contrato.Data.Year == ano && contrato.Data.Month == mes) {
                    //então faça a soma do "soma" mais trazemos o resultado do Metodo ValorTotal do contrato.
                    soma = soma + contrato.ValorTotal();
                }
            }
            //após isso retorne a soma de tudo. 
            return soma;
        }
    }
}
