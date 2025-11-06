using System;

namespace TiposAbstratosDeDados
{
    // Nó da lista encadeada
    class NoLista
    {
        public int chave; // Chave do nó
        public string nome; // Nome do nó
        public NoLista prox; // Ponteiro para o próximo nó

        // Construtor
        public NoLista(int c, string n) // Inicializa o nó com chave e nome
        {
            nome = n;
            chave = c;
            prox = null;
        }
    }

    // Lista encadeada
    class Lista
    {
        private NoLista prim, ult; // Ponteiros para o primeiro e último nó da lista
        int cod; // variável para leitura da chave a ser removida

        // Construtor
        public Lista()
        {
            prim = ult = null; // Inicializa a lista vazia
        }

        // Insere um novo nó no final da lista
        public void Inserir(NoLista item)
        {
            // Se a lista estiver vazia, o novo nó será o primeiro
            if (prim == null)
                prim = item;
            // Caso contrário, o novo nó será o próximo do último nó
            else
                ult.prox = item;
            ult = item;
        }

        // Imprime a lista e remove um nó com a chave especificada
        public void Imprimir()
        {
            // Imprime a lista
            NoLista aux = prim;
            while (aux != null)
            {
                // Imprime o nome e a chave do nó atual
                Console.WriteLine(aux.nome + " - " + aux.chave);
                aux = aux.prox;
            }

            // Solicita a chave do nó a ser removido
            Console.Write("Digite a chave para excluir (ou 6 -> cancelar) : ");
            cod = Convert.ToInt32(Console.ReadLine());
            // Remove o nó com a chave especificada, se não for -1
            if (cod != -1)
            {
                // Pesquisa o nó com a chave especificada
                NoLista n = Pesquisar(cod);

                // Se o nó não for encontrado, exibe uma mensagem
                if (n == null)
                    Console.WriteLine("Valor não encontrado!");
                else
                    // Remove o nó com a chave especificada
                    Remover(cod);

            }
        }

        // Pesquisa um nó com a chave especificada e exibe nome e chave se encontrado
        public NoLista Pesquisar(int c)
        {
            NoLista aux = prim; // Inicia a busca a partir do primeiro nó
            while (aux != null && aux.chave != c) // Percorre a lista até encontrar o nó ou chegar ao fim
            {
                aux = aux.prox;
            }
            // Se encontrou, exibe Nome e Chave
            if (aux != null)
            {
                Console.WriteLine(aux.nome + " - " + aux.chave);
            }
            return aux; // Retorna o nó encontrado ou null se não encontrado
        }

        // Edita o nome do nó com a chave especificada
        // Retorna true se a edição for bem-sucedida, false se a chave não for encontrada
        public bool Editar(int c, string novoNome)
        {
            NoLista aux = prim; // Inicia a busca a partir do primeiro nó
            while (aux != null && aux.chave != c) // Percorre a lista até encontrar o nó ou chegar ao fim
            {
                aux = aux.prox;
            }

            if (aux != null) // nó encontrado
            {
                string nomeAntigo = aux.nome;
                aux.nome = novoNome;
                Console.WriteLine($"Chave {aux.chave} atualizada: nome '{nomeAntigo}' -> '{aux.nome}'.");
                return true;
            }

            // nó não encontrado
            Console.WriteLine("Valor não encontrado!");
            return false;
        }

        // Remove um nó com a chave especificada
        public bool Remover(int c)
        {
            NoLista aux = prim, ant = null; // Inicia a busca a partir do primeiro nó
            while (aux != null && aux.chave != c) // Percorre a lista até encontrar o nó ou chegar ao fim
            {
                ant = aux;
                aux = aux.prox;
            }
            if (aux != null) // nó encontrado
            {
                if (ant != null) // não é o primeiro 
                    ant.prox = aux.prox; // atualiza o próximo do nó anterior
                else // é o primeiro
                    prim = aux.prox; // atualiza o primeiro
                if (aux == ult) // é o último
                    ult = ant; // atualiza o último

                // Mensagem informando chave e nome excluídos
                Console.WriteLine($"Chave {aux.chave} e nome {aux.nome} excluídos.");

                aux.prox = null; // desconecta o nó da lista
                return true; // remoção bem-sucedida
            }
            return false; // nó não encontrado
        }
    }
}
