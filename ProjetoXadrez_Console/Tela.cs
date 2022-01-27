using tabuleiro;
using xadrez;

namespace ProjetoXadrez_Console;
internal class Tela
{
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