namespace ContaCorrente.ConsoleApp;

internal class ContaCorrente
{
    public Cliente Titular;
    private double Saldo;
    public double Limite;
    public string NumeroAgencia;
    public string TipoPessoa;
    public Movimentacao[] movimentacoes;
    private int ContadorMovimentacoes = 0;

    public ContaCorrente(string nomePessoa, string sobrenomePessoa, string cpf, double saldo, double limite, string numeroAgencia, string tipoPessoa)
    {
        Titular = new Cliente(nomePessoa, sobrenomePessoa, cpf);
        Saldo = saldo;
        Limite = limite;
        NumeroAgencia = numeroAgencia;
        TipoPessoa = tipoPessoa;
        this.movimentacoes = new Movimentacao[20];
    }

    public void Depositar(double valorDeposito)
    {
        Saldo += valorDeposito;

        Movimentacao movimentacao = new Movimentacao(valorDeposito, "Depósito");

        movimentacoes[ContadorMovimentacoes] = movimentacao;
        ContadorMovimentacoes++;
    }

    public bool Sacar(double valorSaque)
    {
        if (valorSaque < Limite + Saldo)
        {
            Saldo -= valorSaque;
            Movimentacao movimentacao = new Movimentacao(valorSaque, "Saque");

            movimentacoes[ContadorMovimentacoes] = movimentacao;
            ContadorMovimentacoes++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public double VerSaldo()
    {
        return Saldo;
    }

    public bool Transferir(double valorTransferir, ContaCorrente conta)
    {
        if (valorTransferir < Limite + Saldo)
        {
            Saldo -= valorTransferir;
            conta.ReceberTransferencia(valorTransferir);
            Movimentacao movimentacao = new Movimentacao(valorTransferir, "Transferência");

            movimentacoes[ContadorMovimentacoes] = movimentacao;
            ContadorMovimentacoes++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ReceberTransferencia(double valorReceber)
    {
        if (valorReceber < Limite + Saldo)
        {
            Saldo += valorReceber;
            Movimentacao movimentacao = new Movimentacao(valorReceber, "Depósito");

            movimentacoes[ContadorMovimentacoes] = movimentacao;
            ContadorMovimentacoes++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Movimentacao[] Extrato()
    {
        return movimentacoes;
    }

    public override string ToString()
    {
        return "Nome: " + Titular.NomeCliente + " " + Titular.SobrenomeCliente + "\n" +
            "CPF: " + Titular.Cpf + "\n" +
            "Saldo: " + "R$" + Saldo.ToString("F2") + "\n" +
            "Limite: " + "R$" + Limite.ToString("F2") + "\n" +
            "Número da Agência: " + NumeroAgencia + "\n" +
            "Tipo Pessoa: " + TipoPessoa + "\n";
    }
}
