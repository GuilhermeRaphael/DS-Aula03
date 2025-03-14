using System;
using System.Linq;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {
        //Declarar a criação de uma lista
        static List<Funcionario> lista = new List<Funcionario>();
        static void Main(string[] args)
        {
            ExemplosListasColecoes();
            //ExibirLista();
            //ObterPorId();
        }

        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("==================================================");
            CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("1 - Obter Por Id");
                Console.WriteLine("2 - Adicionar Funcionário");
                Console.WriteLine("3 - Obter por Id digitado");
                Console.WriteLine("4 - Obter por salário digitado");
                Console.WriteLine("5 - Obter funcionario por nome");
                Console.WriteLine("6 - Obter os funcionario recentes");
                Console.WriteLine("7 - Obter estatisticas dos funcionarios");
                Console.WriteLine("8 - Validar salario da admissão");
                Console.WriteLine("9 - Validar nome do funcionario");
                Console.WriteLine("10 - Obter funcionario por tipo");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("=================================================="); opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                    case 1:
                        ObterPorId();
                        break;
                    case 2:
                        AdicionarFuncionario();
                        break;
                    case 3:
                        Console.WriteLine("Digite o Id do funcionario que você deseja buscar: ");
                        int id = int.Parse(Console.ReadLine());
                        ObterPorIdDigitado(id);
                        break;
                    case 4:
                        Console.WriteLine("Digite o salario para obter todos acima do valor indicado: ");
                        decimal salario = decimal.Parse(Console.ReadLine());
                        ObterPorSalario(salario);
                        break;
                    case 5:
                        Console.WriteLine("Digite o nome do funcionario que deseja buscar: ");
                        string nomeFuncionario = Console.ReadLine();
                        ObterPorNome(nomeFuncionario);
                        break;
                    case 6:
                        ObterFuncionarioRecentes();
                        break;
                    case 7:
                        ObterEstatisticas();
                        break;
                    case 8:
                        Console.WriteLine("Digite o salario do funcionario: ");
                        decimal Salario =Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Digite a data de admissão do funcionario (DD-MM-AAAA): ");
                        DateTime dataAdmissao = DateTime.Parse(Console.ReadLine());
                        Funcionario novoFuncionario = new Funcionario{
                            Salario = Salario,
                            DataAdmissao = dataAdmissao
                        };
                        ValidarAdmissaoFuncionario(novoFuncionario);
                        break;
                    case 9:
                        Console.WriteLine("Digite o nome do funcionario que sera validado: ");
                        string nomeValidar = Console.ReadLine();
                        ValidarNome(nomeValidar);
                        break;
                    case 10:
                        ObterPorTipo();
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }

        //METODO DE FILTRAGEM
        public static void ObterPorId()
        {
            //Busca na lista e dps exibe na tela
            // lista = lista.FindAll(x => x.Id == 1);
            lista = lista.FindAll(x => x.Id > 4);

            ExibirLista();
        }

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);
        }

        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 150.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Rodrigo Garro";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

        public static void AdicionarFuncionario(){
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o salario: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissao: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            }
            else if(f.Salario <= 0)
            {
                Console.WriteLine("Funcionario nao pode ser adicionado");
            }
            else
            {
                lista.Add(f);
                ExibirLista();
            }
            

        }

        public static void ObterPorIdDigitado(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);

            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
        }

        public static void ObterPorSalario(decimal valor)
        {
            lista = lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
        }

        public static void ObterPorNome(string nomeFuncionario)
        {
            Funcionario  fBuscar = lista.Find(x => x.Nome.Contains(nomeFuncionario));
            if (fBuscar != null) {
                Console.WriteLine($"Seu funcionario é {fBuscar.Nome}");
            }
            else
            {
            Console.WriteLine("Não foi possível encontrar o funcionário.");
            }
        }
    
        public static void ObterFuncionarioRecentes()
        {
            lista.RemoveAll(x => x.Id < 4);
            lista = lista.OrderByDescending(x => x.Salario).ToList();
            ExibirLista();
        }

        public static void ObterEstatisticas()
        {
            int qtd = lista.Count();
            Console.WriteLine($"Existem {qtd} funcionários.");
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é  {0:c2}.", somatorio));
        }

        public static void ValidarAdmissaoFuncionario(Funcionario funcionario)
        {
            if(funcionario.Salario<=0){
                Console.WriteLine("Salario deve ser maior que 0");
                return;
            }
            if (funcionario.DataAdmissao < DateTime.Now){
                Console.WriteLine("A data de admissão não pode ser anterior à data atual");
                return;
            }
            else{
                Console.WriteLine("Funcionario valido");
            }
        }

        public static void ValidarNome(string Nome)
        {
            if(Nome.Length<2){
                Console.WriteLine("O nome do funcionario deve pelo menos 2 letras");
            }
            else{
                Console.WriteLine("Nome valido");
            }
        }
        
        public static void ObterPorTipo()
        {
            Console.WriteLine("Digite o número do tipo de funcionário (1 - CLT || 2 - Aprendiz)");
            int tipo = int.Parse(Console.ReadLine());
            var resultado = lista.Where(f => (int)f.TipoFuncionario == tipo).ToList();
            if (resultado.Count > 0)
            {
                resultado.ForEach(f => Console.WriteLine($"ID: {f.Id}, Nome: {f.Nome}"));
            }
            else
            {
                Console.WriteLine("Nenhum funcionário encontrado.");
            }       
        }



    }
}

