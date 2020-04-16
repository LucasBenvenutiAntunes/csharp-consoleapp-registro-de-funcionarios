using System;
using System.Collections.Generic;
using System.Text;

namespace Listas
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public int Id { get; private set; }
        public double Salario { get; set; }

        public void alterarNome(string nome)
        {
            Nome = nome;
        }
        public void aumentarSalario(double percentual)
        {
            Salario += (Salario * percentual) / 100;
        }
        public void reduzirSalario(double percentual)
        {
            Salario -= (Salario * percentual) / 100;
        }

        public int geradorDeId()
        {
            var rand = new Random();

            this.Id = rand.Next(101); //Gera um número aleatorio de 0 a 100.
            return Id;
        }

        public override string ToString()
        {
            return "\nFuncionário ID#"
                    + Id
                    + "\nNome: "
                    + Nome
                    + "\nSalário: R$ "
                    + Salario;
        }
    }
}
