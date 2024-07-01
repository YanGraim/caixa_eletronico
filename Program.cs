// Faça um programa estilo caixa eletrônico,
// que o usuário consiga ver o saldo, depositar e sacar dinheiro.
// Obs: Usar métodos no desenvolvimento

decimal saldo = 0;

Console.Clear();
Console.WriteLine("Bem Vindo ao banco CSharp\n");
Console.WriteLine("Qual o seu nome?");
string nome = Console.ReadLine();
while (string.IsNullOrWhiteSpace(nome))
{
    Console.WriteLine("Favor preencher o seu nome");
    nome = Console.ReadLine();
}

Console.Clear();

Console.WriteLine($"Seja muito bem vindo, {nome}!\n\nPara iniciarmos vamos gerar um número de conta aleatoria:\n");
int conta = CriarConta();

Console.WriteLine("Agora crie uma senha de 4 digitos:");
string senha = CriarSenha();
Console.Clear();

Console.WriteLine("Conta gerada e senha criada com sucesso!\n");
Console.WriteLine("Para fazer as operações informe sua conta:");
int contaCriada = int.Parse(Console.ReadLine());


Console.WriteLine("Informe sua senha:");
string senhaCriada = Console.ReadLine();
Console.Clear();

int tentativasRestantes = 3;
while ((senha != senhaCriada || conta != contaCriada) && tentativasRestantes > 1)
{
    tentativasRestantes--;
    Console.WriteLine($"Conta ou senha incorretos, você tem {tentativasRestantes} tentativas restantes. Informe conta e senha criada!\n");

    Console.WriteLine("Informe sua conta:");
    contaCriada = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.Clear();

    Console.WriteLine("Informe sua senha:");
    senhaCriada = Console.ReadLine();
    Console.WriteLine();
    Console.Clear();
}

if (senha == senhaCriada && conta == contaCriada)
{
    Console.WriteLine("Login efetuado com sucesso!\n******* Bem vindo! ******* \n");

    int opcoes = 0;
    while (opcoes != 4)
    {
        opcoes = Menu();
        Console.Clear();
        switch (opcoes)
        {
            case 1:
                MostrarSaldo();
                break;
            case 2:
                Depositar();
                break;
            case 3:
                Sacar();
                break;
            case 4:
                Console.WriteLine("Obrigado por escolher o Banco CSharp!\n\nVolte Sempre!!!");
                break;
            default:
                Console.WriteLine("Digite uma opção válida\n\n");
                break;
        }
    }
    Console.ReadLine();
}

else
{
    Console.Clear();
    Console.WriteLine("\nVocê excedeu o número máximo de tentativas.\nAcesso negado");
    Console.ReadLine();
}


void MostrarSaldo()
{
    Console.Clear();
    if (saldo == 0)
    {
        Console.WriteLine($"O valor do Seu saldo atual é: R${saldo:f2}.\n\nDeposite algum valor para fazer as outras operações\n");
    }
    else
    {
        Console.WriteLine($"O valor do Seu saldo atual é: R${saldo:f2}.\n\n");
    }

}


void Sacar()
{
    Console.Clear();
    Console.WriteLine("Qual valor você quer sacar?");
    decimal valor = decimal.Parse(Console.ReadLine());
    Thread.Sleep(800);
    Console.Clear();

    if (valor <= 0)
    {
        Erro();
    }
    else if (saldo >= valor)
    {
        saldo -= valor;
        Sucesso();
        Console.WriteLine($"Saque realizado com sucesso! Seu saldo atual é de R${saldo:f2}.\n\n");

    }
    else
    {
        Console.WriteLine($"Seu saldo é insuficiente para saque! Seu saldo atual é de R${saldo:f2}.\n\nTente novamente!\n");
    }

}


void Depositar()
{
    Console.Clear();
    Console.WriteLine("Qual valor você deseja depositar?");
    decimal deposito = decimal.Parse(Console.ReadLine());
    Thread.Sleep(800);
    Console.Clear();
    if (deposito <= 0)
    {
        Erro();
    }
    else
    {
        saldo += deposito;
        Sucesso();
        Console.WriteLine($"Depósito de R${deposito:f2} reais realizado com sucesso.\n\nSeu saldo atual é de {saldo:f2} reais\n\n");
    }
}

static int Menu()
{
    Console.WriteLine("===================");
    Console.WriteLine("  MENU DE OPÇÕES  ");
    Console.WriteLine("===================");
    Console.WriteLine("[1] Mostrar Saldo");
    Console.WriteLine("[2] Depositar");
    Console.WriteLine("[3] Sacar Dinheiro");
    Console.WriteLine("[4] Sair");
    int opcoes = int.Parse(Console.ReadLine());
    return opcoes;
}

static string CriarSenha()
{
    string senha = Console.ReadLine();
    Console.WriteLine();

    while (string.IsNullOrWhiteSpace(senha) || senha.ToString().Length != 4 || senha.ToString().Length > 4)
    {
        Console.WriteLine("Sua senha deve conter:\n* Mínimo e máximo de 4 números\n* Não pode ser vazio\n\nDigite uma senha de 4 digitos:");
        senha = Console.ReadLine();
        Console.WriteLine();
    }

    return senha;
}

static int CriarConta()
{
    Random random = new();
    int conta = random.Next(0001, 99999);
    Thread.Sleep(2500);
    Console.WriteLine("Criando conta...");
    Thread.Sleep(2500);
    Console.WriteLine("Isso pode demorar alguns segundos...");
    Thread.Sleep(2000);
    Console.WriteLine("Tudo Pronto!");
    Thread.Sleep(1000);
    Console.WriteLine($"O número da sua conta é: {conta}\n\n");


    Thread.Sleep(3000);
    Console.Clear();

    Console.WriteLine($"Número da conta: {conta}\n\n");
    return conta;
}

void Erro()
{
    Console.Clear();
    Console.WriteLine("Verificando solicitação...\n");
    Thread.Sleep(2000);
    Console.WriteLine("Verificando saldo em conta...\n");
    Thread.Sleep(2000);
    Console.WriteLine("Parece que ocorreu um erro...\n\n");
    Thread.Sleep(2500);
    Console.WriteLine("Não é possivel utilizar valores negativos ou igual a 0 para fazer operações de deposito ou saque.\nTente novamente!\n");
}

void Sucesso()
{
    Console.Clear();
    Console.WriteLine("Verificando solicitação...\n");
    Thread.Sleep(2000);
    Console.WriteLine("Realizando operação...\n");
    Thread.Sleep(2500);
    Console.WriteLine("Sucesso!!!\n\n");
}