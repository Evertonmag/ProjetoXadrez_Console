using tabuleiro;
using xadrez;

namespace ProjetoXadrez_Console;
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
            tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
            tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 2));

            Tela.imprimirTabuleiro(tab);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}