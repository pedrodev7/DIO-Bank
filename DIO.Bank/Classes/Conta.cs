using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Bank
{
    class Conta
    {
        private string Nome { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
            this.TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            if (this.TipoConta == (TipoConta)2)
            {
                this.Saldo -= (valorSaque + (valorSaque * 0.05));
                Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
                return true;
            }
            else {
                this.Saldo -= valorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
                return true;
            }

            
        }

        public void Depositar(double valorDeposito) 
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }


        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia);

            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo De Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }

    }
}
