using System;
using System.Globalization; //importando biblioteca globalização para trabalhar com invariantCulture.
using ExercicioEnumeracaoeComposicao.Entidades;//importando a pasta Entidades para utilizar as classes.
using ExercicioEnumeracaoeComposicao.Entidades.Enums; //importando a subpasta Enums para utilizar as classes.

namespace ExercicioEnumeracaoeComposicao {
    class Program {
        static void Main(string[] args) {
            //inserindo os dados do trabalhador 
            Console.Write("Digite o Nome do Departamento: ");
            string nomeDep = Console.ReadLine();
            Console.WriteLine("Entre com os dados do Trabalhador: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Qual o Nível do trabalhor, Junior/Pleno/Senior: ");
            //aqui precisamos converter Enum para string, usando os parametros do projeto tipo netcore.
            NivelTrabalhador nivel = Enum.Parse<NivelTrabalhador>(Console.ReadLine());
            //caso quisessemos converter pelo projeto do tipo netframework faziamos a opção abaixo:
            //NivelTrabalhador nivel2 = (NivelTrabalhador)Enum.Parse(typeof(NivelTrabalhador), Console.ReadLine());
            Console.Write("Base Salarial do Funcionário: ");
            double baseSalario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //instanciando as classes e inserindo os atributos que o usuário digitou
            Departamento dep = new Departamento(nomeDep);
            Trabalhador trab = new Trabalhador(nome, nivel, baseSalario, dep);

            //Fazendo os Contratos.
            Console.Write("Quantos Contratos para esse Trabalhador?  ");
            int qntContrato = int.Parse(Console.ReadLine());

            //fazendo um for de acordo com a quantidade de contratos
            for (int i = 1 ; i <= qntContrato; i++) {
                Console.WriteLine($"Entre com os dados do contrato número {i}: ");
                Console.Write($"Data do Contrato número {i} (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write($"Valor por Hora do Contrato número {i} (00.00): ");
                double valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write($"Duração em Horas do Contrato número {i} (00): ");
                int duracao = int.Parse(Console.ReadLine());
                //agora instanciaremos o contrato dentro do for passando os dados que foram inseridos acima
                HorasContratadas contrato = new HorasContratadas(data, valorHora, duracao);
                //agora iremos adicionar o contrato acima dentro do contrato do trabalhador.
                trab.AdicionarContrato(contrato);
            }
            Console.WriteLine();
            Console.Write("Entre com o mês e ano para calcular o Ganho (MM/YYYY): ");
            string mesEAno = Console.ReadLine();
            //agora iremos recortar o mes e o ano digitado acima.
            //utilizando o metodo Substring iremos pegar a string que começa no 0 e termina no 2, e converter em int
            int mes = int.Parse(mesEAno.Substring(0, 2));
            //e depois pegamos o ano que inicia no 3 e vai até o final da string, e converter em int também
            int ano = int.Parse(mesEAno.Substring(3));
            Console.WriteLine("Nome: " + trab.Nome);
            //repare que aqui estamos navegando entre os objetos para buscar o nome do departamento.
            Console.WriteLine("Nome: " + trab.Departamento.Nome);
            //aqui estamos navegando dentro do trab, e chamando o metodo Ganho, colocando como valor o mes e o ano.
            Console.WriteLine("Ganho no mês de " + mesEAno + ", é de : " + trab.Ganho(mes, ano));
        }
    }
}
