﻿using tabuleiro;



namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            
            
            Posicao P;
            P = new Posicao(3, 4);
            Console.WriteLine(P);

            Console.ReadLine();

        }
    }
}