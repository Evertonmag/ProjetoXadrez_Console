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
        Console.WriteLine($"\n\nTurno: {partida.turno}");
        if (!partida.terminada)
        {
            Console.WriteLine($"Aguardando Jogada: {partida.jogadorAtual}");
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }
        else
        {
            Console.WriteLine("XEQUEMATE!");
            Console.WriteLine("Vencedor: " + partida.jogadorAtual);
        }
    }

    public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
    {
        Console.WriteLine("Pecas Capturadas: ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Brancas: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
        Console.ForegroundColor = ConsoleColor.DarkBlue;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.colunas; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                imprimirPeca(tab.peca(i, j));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine();
        }
        Console.WriteLine("   a  b  c  d  e  f  g  h");
        Console.ResetColor();
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
            Console.Write("   ");
        }
        else
        {
            Console.Write(" ");
            if (peca.cor == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(peca);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(peca);
            }
            Console.Write(" ");
        }

    }


    public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {
        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.Green;

        for (int i = 0; i < tab.linhas; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.colunas; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (posicoesPossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }

                imprimirPeca(tab.peca(i, j));

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine();
        }
        Console.WriteLine("   a  b  c  d  e  f  g  h");
        Console.ResetColor();
    }
}
