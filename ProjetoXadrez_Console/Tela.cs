using tabuleiro;
using xadrez;

namespace ProjetoXadrez_Console;
internal class Tela
{
    public static void imprimirPartida(PartidaDeXadrez partida)
    {
        imprimirTabuleiro(partida.tab);
        Console.WriteLine();
        imprimirPecasCapturadas(partida);
        Console.WriteLine($"\n\nTurno: {partida.turno}" +
                          $"\nAguardando Jogada: {partida.jogadorAtual}");
        if (partida.xeque)
        {
            Console.WriteLine("XEQUE!");

        }
    }

    public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
    {
        Console.WriteLine("Pecas Capturadas: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Brancas: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Pretas: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
        Console.ResetColor();
    }

    public static void imprimirConjunto(HashSet<Peca> conjunto)
    {
        Console.Write("[");
        foreach (Peca x in conjunto)
        {
            Console.Write(x + " ");
        }
        Console.Write("]\n");
    }

    public static void imprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.colunas; j++)
            {
                imprimirPeca(tab.peca(i, j));
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.WriteLine("  a b c d e f g h");
    }

    public static PosicaoXadrez lerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");

        return new PosicaoXadrez(coluna, linha);
    }

    public static void imprimirPeca(Peca peca)
    {
        if (peca == null)
        {
            Console.Write("- ");
        }
        else
        {
            if (peca.cor == Cor.Branca)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                /*Console.BackgroundColor = ConsoleColor.White;*/
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                /*Console.BackgroundColor = ConsoleColor.White;*/
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }

    }

    public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {
        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < tab.linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.colunas; j++)
            {
                if (posicoesPossiveis[i, j])
                    Console.BackgroundColor = fundoAlterado;
                else
                    Console.BackgroundColor = fundoOriginal;
                imprimirPeca(tab.peca(i, j));
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.ResetColor();
    }
}

/*if ((i + j) % 2 == 0)
{
    Console.BackgroundColor = ConsoleColor.White;
}
else
    Console.BackgroundColor = ConsoleColor.Black;*/

/*Console.BackgroundColor = ConsoleColor.Black;*/