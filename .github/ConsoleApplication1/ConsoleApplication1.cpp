// ConsoleApplication1.cpp : Este arquivo contém a função 'main'. A execução do programa começa e termina ali.
//

#include <iostream>

#include <stdio.h>

#define NUM_ALUNOS 2

int main() {
    int numerosMecanograficos[NUM_ALUNOS];
    char nomes[NUM_ALUNOS][100];
    float notas[NUM_ALUNOS];

    // Leitura dos dados dos alunos
    for (int i = 0; i < NUM_ALUNOS; i++) {
        printf("Aluno %d:\n", i + 1);
        printf("Número mecanográfico: ");
        scanf("%d", &numerosMecanograficos[i]);
        getchar(); // Limpar o buffer após a leitura do número
        printf("Nome: ");
        scanf(" %[^\n]", nomes[i]); // Lê o nome incluindo espaços
        printf("Nota: ");
        scanf("%f", &notas[i]);
    }

    // Exibição dos alunos aprovados
    printf("\nAlunos aprovados: \n");
    for (int i = 0; i < NUM_ALUNOS; i++) {
        if (notas[i] >= 9.5) {
            printf(" Nome: %s\n", nomes[i]);
        }
    }

    return 0;
}

// Executar programa: Ctrl + F5 ou Menu Depurar > Iniciar Sem Depuração
// Depurar programa: F5 ou menu Depurar > Iniciar Depuração

// Dicas para Começar: 
//   1. Use a janela do Gerenciador de Soluções para adicionar/gerenciar arquivos
//   2. Use a janela do Team Explorer para conectar-se ao controle do código-fonte
//   3. Use a janela de Saída para ver mensagens de saída do build e outras mensagens
//   4. Use a janela Lista de Erros para exibir erros
//   5. Ir Para o Projeto > Adicionar Novo Item para criar novos arquivos de código, ou Projeto > Adicionar Item Existente para adicionar arquivos de código existentes ao projeto
//   6. No futuro, para abrir este projeto novamente, vá para Arquivo > Abrir > Projeto e selecione o arquivo. sln
