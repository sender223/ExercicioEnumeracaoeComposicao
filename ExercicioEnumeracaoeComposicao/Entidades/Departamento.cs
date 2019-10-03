namespace ExercicioEnumeracaoeComposicao.Entidades {
    class Departamento {
        //criando a propriedade autoimplementada "Nome"
        public string Nome { get; set; }

        //criando os contrutores
        //contrutor padrão
        public Departamento() {

        }
        //contrutor que recebe o nome como argumento.
        public Departamento(string nome) {
            Nome = nome;
        }
    }
}
