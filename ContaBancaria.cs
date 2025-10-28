public abstract class ContaBancaria
{
    public int Id { get; set; }
    public string NumeroConta { get; private set; }
    public string Titular { get; set; }
    public decimal Saldo { get; protected set; }

    public ContaBancaria(string numeroConta, string titular)
    {
        NumeroConta = numeroConta;
        Titular = titular;
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"R${valor} depositados. Saldo atual é de R${Saldo}.");
        }
        else
        {
            Console.WriteLine("Valor incorreto. Tente novamente.");
        }

    }

    public virtual bool Sacar(decimal valor)
    {
        if (valor > 0 && valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque no valor de R${valor} feito. Saldo atual é de R${Saldo}");
            return true;
        }
        else if (valor <= 0)
        {
            Console.WriteLine("Saque não permitido. Valor de saque é zero ou um número negativo.");
            return false;
        }
        else
        {
            Console.WriteLine($"Tentativa de saque de R${valor:F2} falhou. Saldo insuficiente (R${Saldo:F2}).");
            return false;
        }
    }
}
