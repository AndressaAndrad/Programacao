using Cap202204ConsoleApp.FakeDB;
using Cap202204ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap202204ConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 44 - Utilizando o FakeDB de Pessoa, desenvolva uma classe que:
    ///1 - crie uma lista paralela com todos do sexo masculino.
    ///2 - crie uma lista paralela com todos do sexo feminino.
    ///3 - crie uma lista paralela com todos nascidos antes de 1970.
    ///4 - com a lista 1, exibir quem nasceu primeiro.
    ///5 - com a lista 2, exibir quem nasceu mais recentemente.
    ///6 - com a lista 3, selecionar alguns, solicitar peso e altura, e calcular o IMC.
    /// </summary>
    public class Desafio044
    {
        private List<Pessoa> listaMasculina;

        private List<Pessoa> listaFeminina;

        private List<Pessoa> listaNascidosAntes1970;
        private List<Pessoa> listaCalculoIMC;

        public Desafio044()
        {
            this.listaMasculina = new List<Pessoa>();
            this.listaFeminina = new List<Pessoa>();
            this.listaNascidosAntes1970 = new List<Pessoa>();
            this.listaCalculoIMC = new List<Pessoa>();
        }

        public void Executar()
        {
            //this.PreencherListaMasculina();
            //this.PreencherListaFeminina();
            this.PreencherListaNascidosAntes1970();

            //this.ExibirQuemNasceuPrimeiro();
            //this.ExibirQuemNasceuPorUltimo();
            this.CalcularIMC();
        }

        /// <summary>
        /// 1 - crie uma lista paralela com todos do sexo masculino.
        /// </summary>
        private void PreencherListaMasculina()
        {
            this.listaMasculina = PessoaFakeDB.Pessoas.Where(pes => pes.Sexo == "M").ToList();
            Console.WriteLine("- Lista Masculina -");
            Console.WriteLine("Qtde de Pessoas: {0}", this.listaMasculina.Count());
            Console.WriteLine();
        }

        /// <summary>
        /// 2 - crie uma lista paralela com todos do sexo feminino.
        /// </summary>
        private void PreencherListaFeminina()
        {
            this.listaFeminina = PessoaFakeDB.Pessoas.Where(pes => pes.Sexo == "F").ToList();
            Console.WriteLine("- Lista Feminina -");
            Console.WriteLine("Qtde de Pessoas: {0}", this.listaFeminina.Count());
            Console.WriteLine();

        }

        /// <summary>
        /// 3 - crie uma lista paralela com todos nascidos antes de 1970.
        /// </summary>
        private void PreencherListaNascidosAntes1970()
        {
            DateTime data = Convert.ToDateTime("01-01-1970");
            this.listaNascidosAntes1970 = PessoaFakeDB.Pessoas.Where(pes => pes.DtNascimento < data).ToList();
        }

        /// <summary>
        /// 4 - com a lista 1, exibir quem nasceu primeiro.
        /// </summary>
        private void ExibirQuemNasceuPrimeiro()
        {
            Pessoa nascidoPrimeiro = this.listaMasculina.OrderBy(pe => pe.DtNascimento).FirstOrDefault();
            Console.WriteLine("- Nasceu primeiro - ");
            Console.WriteLine("Codigo: {0} | Nome Completo: {1} {2} | Sexo: {3} | Dt Nascimento: {4}",
                nascidoPrimeiro.Codigo,
                nascidoPrimeiro.Nome,
                nascidoPrimeiro.SobreNome,
                nascidoPrimeiro.Sexo,
                nascidoPrimeiro.DtNascimento);
            Console.WriteLine();
        }

        /// <summary>
        /// 5 - com a lista 2, exibir quem nasceu mais recentemente.
        /// </summary>
        private void ExibirQuemNasceuPorUltimo()
        {
            Pessoa nascidaPorUltimo = this.listaFeminina.OrderByDescending(pe => pe.DtNascimento).FirstOrDefault();
            Console.WriteLine("- Nasceu por último - ");
            Console.WriteLine("Codigo: {0} | Nome Completo: {1} {2} | Sexo: {3} | Dt Nascimento: {4}",
                nascidaPorUltimo.Codigo,
                nascidaPorUltimo.Nome,
                nascidaPorUltimo.SobreNome,
                nascidaPorUltimo.Sexo,
                nascidaPorUltimo.DtNascimento);
            Console.WriteLine();
        }

        private void CalcularIMC()
        {
            while (true)
            {
                foreach (Pessoa item in this.listaNascidosAntes1970)
                {
                    Console.WriteLine("Código: {0} | Nome Completo: {1} {2}| Data de Nascimento: {3} .",item.Codigo, item.Nome, item.SobreNome,item.DtNascimento);
                }

                Console.Write("Digite um Código: ");
                    int opcao = 0;
                    string s = Console.ReadLine();
                if (int.TryParse(s, out opcao))
                {
                    Pessoa achado = this.listaNascidosAntes1970.SingleOrDefault(pes => pes.Codigo == opcao);
                    if (achado != null)
                    {
                        Console.Write("Informe o peso: ");
                        achado.Peso = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Informe a altura: ");
                        achado.Altura = Convert.ToDouble(Console.ReadLine());

                        double altura2 = achado.Altura * achado.Altura;
                        double imc = achado.Peso/ altura2;

                        this.listaCalculoIMC.Add(achado);
                        this.listaNascidosAntes1970.Remove(achado);

                        Console.Write("Nome: {0}, seu IMC é: {1}", achado.Nome, imc);
                        Console.ReadLine();

                    }

                }
             
            }
           
         
        }
    }
}
