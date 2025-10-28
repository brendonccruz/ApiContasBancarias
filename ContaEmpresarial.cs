using System.Security.Cryptography.X509Certificates;

public class ContaEmpresarial : ContaBancaria, IAuditavel
{
    public decimal LimiteEmprestimo { get; set; }
    public ContaEmpresarial(string numeroConta, string titular, decimal limiteEmprestimo) : base(numeroConta, titular)
    {
        LimiteEmprestimo = limiteEmprestimo;
    }

    public void FazerEmprestimo(decimal valor)
    {
        if (valor > 0 && valor <= LimiteEmprestimo)
        {
            Saldo += valor;
            Console.WriteLine($"Empréstimo aprovado. O valor de R${valor} foi adicionado ao seu saldo.");
        }
        else
        {
            Console.WriteLine($"Empréstimo negado. Valor acima do limite permitido. Seu limite é de R${LimiteEmprestimo}");
        }
    }

    public override bool Sacar(decimal valor)
    {

        if (valor > 0 && valor <= Saldo + LimiteEmprestimo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R${valor} feito com sucesso. Saldo atual é de {Saldo}");
            return true;
        }
        else
        {
            Console.WriteLine("Valor de saque não permitido. Tente novamente.");
            return false;
        }
    }
    
    public string GerarLog()
    {
        return $"[LOG] Conta Empresarial: {NumeroConta} | Titular: {Titular} | Saldo: R${Saldo:F2} | Limite de Empréstimo: R${LimiteEmprestimo:F2}";
    }
}