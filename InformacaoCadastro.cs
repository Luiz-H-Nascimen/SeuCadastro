﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Threading.Channels;
using System.Text.RegularExpressions;

namespace SeuCadastro
{
    public class Informacoes
    {
        private List<Candidatos> ListaDeCandidatos { get; set; }
        public Informacoes()
        {
            this.ListaDeCandidatos = new List<Candidatos>();
            try
            {
                string caminho = "Candidatos.txt";
                string[] colaboradoresDb = File.ReadAllLines(caminho);

                foreach (var cadidatoDb in colaboradoresDb)
                {
                    var propArray = cadidatoDb.Split(',');
                    var cadidato = new Candidatos
                    {
                        Id = Convert.ToInt32(propArray[0]),
                        Nome = propArray[1],
                        Telefone = propArray[2],
                        Salario = Convert.ToDouble(propArray[3]),
                        Email = propArray[4],
                        Profissoes = propArray[5],
                        Idade = Convert.ToInt32(propArray[6])
                    };
                    ListaDeCandidatos.Add(cadidato);
                }

            }
            catch (Exception)
            {
                ListaDeCandidatos = new List<Candidatos>();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Digitou |2|");
            Console.ResetColor();
        }
        public void InformacaoDeCadastro()
        {
            Console.WriteLine("Candidatos Cadastrados;");
            Console.WriteLine();

            foreach (var c in ListaDeCandidatos)
            {
                Console.Write("    Id: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(c.Id);
                Console.ResetColor();
                Console.Write("    Nome: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(c.Nome);
                Console.ResetColor();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
            }

            if (ListaDeCandidatos.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum registro encontrado");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("<|Enter| Retorna ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Digite o - Id - do Candidato pra mais detalhes.");
                Console.ResetColor();
                Console.WriteLine("<|Enter| Retorna ");
                Console.WriteLine();
            }

            try
            {
                string imput = Console.ReadLine();
                int opicao = string.IsNullOrWhiteSpace(imput) ? 0 : int.Parse(imput);
                Console.Clear();
                if (opicao == 0)
                    new Menus().MenuInicial();

                var candidatoalterado = ListaDeCandidatos.Where(c => c.Id == opicao).FirstOrDefault();

                if (candidatoalterado == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Id não estar CADASTRADO, tente novamente.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("<|Enter| Retorna ");
                    Console.ReadLine();
                    Console.Clear();
                    InformacaoDeCadastro();
                }

                Console.Clear();
                Console.WriteLine();
                Console.Write("Id: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Id);
                Console.ResetColor();

                Console.Write("Nome: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Nome);
                Console.ResetColor();

                Console.Write("Idade: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Idade);
                Console.ResetColor();

                Console.Write("Telefone: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Telefone);
                Console.ResetColor();

                Console.Write("E-mail: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Email);
                Console.ResetColor();

                Console.Write("Profissão: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Profissoes);
                Console.ResetColor();

                Console.Write("Salario: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(candidatoalterado.Salario);
                Console.ResetColor();

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("<|Enter| Retorna ");
                Console.ReadLine();
                Console.Clear();

                InformacaoDeCadastro();
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Opção invalida, Tente novamente digitando apenas NUMEROS");
                Console.ReadLine();
                Console.Clear();
                InformacaoDeCadastro();
            }
        }
    }
}
