using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n---------- Bem Vindo ao Software Livre de Cadastro de Funcionários - Versão Beta ----------\n");

            List<Funcionario> funcionarios = new List<Funcionario>();

            selecionarOpcao(funcionarios);

            static void selecionarOpcao(List<Funcionario> funcionarios)
            {
                Console.WriteLine("O que deseja fazer? Digite o valor da opção.");

                Console.WriteLine("1. Exibir lista de funcionários cadastrados.");
                Console.WriteLine("2. Cadastrar novo(s) funcionário(s).");
                Console.WriteLine("3. Descadastrar funcionário(s).");
                Console.WriteLine("4. Alterar dados cadastrais de um funcionário.");
                Console.WriteLine("5. Sair.");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\n------------------------------------------------\n");
                        exibirFuncionarios(funcionarios);
                        retornarAoMenuPrincipal(funcionarios);
                        break;
                    case 2:
                        Console.WriteLine("\n------ Você está na área de CADASTRAMENTO de novos funcionários -----\n");
                        cadastrarFuncionario(funcionarios);
                        break;
                    case 3:
                        Console.WriteLine("\n------ Você está na área de DESCADASTRAMENTO de funcionários -----\n");
                        descadastrarFuncionario(funcionarios);
                        break;
                    case 4:
                        Console.WriteLine("\n------ Você está na área de ALTERÇÃO DE DADOS CADASTRAIS -----\n");
                        alterarCadastro(funcionarios);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Erro. Por favor, selecione uma opção válida.");
                        selecionarOpcao(funcionarios);
                        break;
                }
            }


            static void cadastrarFuncionario(List<Funcionario> funcionarios)
            {
                Console.Write("Quantos funcionarios deseja registrar? ");
                int novos = int.Parse(Console.ReadLine());

                for (int i = 0; i < novos; i++)
                {
                    Funcionario c = new Funcionario();

                    int id = c.geradorDeId();

                    Console.Write("\nInsira o Nome do funcionário: ");
                    string nome = Console.ReadLine();
                    Console.Write("Informe o salário do funcionário: R$ ");
                    double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    c.Nome = nome;
                    c.Salario = salario;
                    funcionarios.Add(c);
                    Console.WriteLine("Novo funcionario ID#{0} gerado.", id);
                }
                Console.WriteLine("\nTodos os funcionário(s) foram cadastrado(s) com sucesso.");
                retornarAoMenuPrincipal(funcionarios);
            }

            static void descadastrarFuncionario(List<Funcionario> funcionarios)
            {
                exibirFuncionarios(funcionarios);
                Console.WriteLine("\n------------------------------------------------\n");

                Console.Write("Informe o ID do funcionário que você descadastrar: ");
                int buscaId = int.Parse(Console.ReadLine());

                funcionarios.RemoveAll(x => x.Id == buscaId);

                Console.WriteLine("\nFuncionário descadastrado com sucesso.");
                retornarAoMenuPrincipal(funcionarios);
            }

            static void alterarCadastro(List<Funcionario> funcionarios)
            {
                exibirFuncionarios(funcionarios);
                Console.WriteLine("\n------------------------------------------------\n");

                Console.Write("Informe o ID do funcionário que deseja alterar os dados cadastrais: ");
                int buscaId = int.Parse(Console.ReadLine());

                Funcionario func = funcionarios.Find(x => x.Id == buscaId);
                if (func != null)
                {
                    Console.WriteLine("\nVocê irá alterar os dados do funcionário a seguir:");
                    Console.WriteLine(func);

                    Console.Write("\nDeseja prosseguir? (s/n) ");
                    char selecao = char.Parse(Console.ReadLine());

                    if (selecao == 's' || selecao == 'S')
                    {
                        alteracaoValida(funcionarios, func);

                        static void alteracaoValida(List<Funcionario> funcionarios, Funcionario func)
                        {
                            Console.WriteLine("\nOk. Informe o campo cadastral voce deseja alterar:");
                            Console.WriteLine("1. Nome do funcionário.");
                            Console.WriteLine("2. Salário do funcionário.");
                            int opcao = int.Parse(Console.ReadLine());

                            switch (opcao)
                            {
                                case 1:
                                    Console.WriteLine("\nInsira o novo nome: ");
                                    string nome = Console.ReadLine();
                                    func.alterarNome(nome);
                                    Console.WriteLine("Nome alterado com sucesso.");
                                    retornarAoMenuPrincipal(funcionarios);
                                    break;
                                case 2:
                                    Console.WriteLine("\nQual tipo de modificação salarial será feita?");
                                    Console.WriteLine("1. Aumentar salário.");
                                    Console.WriteLine("2. Reduzir salário.");
                                    int opcao2 = int.Parse(Console.ReadLine());

                                    if (opcao2 == 1)
                                    {
                                        Console.Write("\nEntre com o percentual de aumento salarial: ");
                                        double percentual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        func.aumentarSalario(percentual);
                                        Console.WriteLine("Salário atualizado com sucesso.");
                                        Console.WriteLine(func);

                                        retornarAoMenuPrincipal(funcionarios);
                                    }
                                    else if (opcao2 == 2)
                                    {
                                        Console.Write("\nEntre com o percentual de redução salarial: ");
                                        double percentual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        func.reduzirSalario(percentual);
                                        Console.WriteLine("Salário atualizado com sucesso.");
                                        Console.WriteLine(func);

                                        retornarAoMenuPrincipal(funcionarios);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("\nErro. Por favor, selecione uma opção válida.");
                                    alteracaoValida(funcionarios, func);
                                    break;
                            }
                        }
                    }
                    else if (selecao == 'n' || selecao == 'N')
                    {
                        alterarCadastro(funcionarios);
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido! Tente novamente.");
                }
                retornarAoMenuPrincipal(funcionarios);
            }

            static void exibirFuncionarios(List<Funcionario> funcionarios)
            {
                if(funcionarios != null && funcionarios.Count()>0)
                {
                    Console.WriteLine("Lista de Funcionários atuais:");
                    foreach (Funcionario obj in funcionarios)
                    {
                        Console.WriteLine(obj);
                    }
                }
                else
                {
                    Console.WriteLine("Ainda não existem funcionários cadastrados no sistema.");
                }
            }

            static void retornarAoMenuPrincipal(List<Funcionario> funcionarios)
            {
                Console.WriteLine("\n------------------------------------------------\n");
                Console.WriteLine("\nAperte qualquer tecla para voltar ao Menu Principal, e em seguida, pressione ENTER.");
                string retornar = Console.ReadLine();
                if (retornar != null)
                {
                    Console.Clear();
                    selecionarOpcao(funcionarios);
                }
            }

        }
    }
}



