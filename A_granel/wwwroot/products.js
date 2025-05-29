async function carregarProdutos() {
    const productListElement = document.getElementById('lista-produtos');
    // Tratamento de  erro 
    try {
        // Faz uma requisição GET para o endpoint que retorna os produtos
        const response = await fetch('http://localhost:5067/Product');

        if (!response.ok) {
        throw new Error(`Erro na requisição: ${response.status} ${response.statusText}`);
        }

        const produtos = await response.json();

        productListElement.innerHTML = '';

        // Verifica se não há produtos na lista
        if (produtos.length === 0) {
        productListElement.innerHTML = '<p>Nenhum produto encontrado.</p>';
        return;
        }
        produtos.forEach(produto => {

        const itemProduto = document.createElement('div'); 

        itemProduto.classList.add('produto-item'); 

        //  HTML do elemento com os detalhes do produto
        itemProduto.innerHTML = `
            <h3>${produto.name || 'Nome não disponível'}</h3>
            <p><strong>ID:</strong> ${produto.id || 'N/A'}</p>
            <p><strong>Data de Vencimento: ${produto.expDate}</p>
            <p><strong>Preço p/100 Gramas:</strong> R$ ${(produto.pricePer100G / 100)}</p>
            <p><strong>Quantidade (em Gramas):</strong> ${produto.quantity}</p>
            <div style="display: flex; width: 100%; height: 25px; gap: 5px">
                <input style="width: 50%; height: 25px" type="number"/> <button style="width: 50%; height: 25px">Alterar</button>
            </div>
            <button style="width: 100%; height: 25px; margin-top: 5px">Excluir</button>
            <hr>
        `;

        productListElement.appendChild(itemProduto);
        });

    } catch (error) {
        console.error('Falha ao carregar os produtos:', error);
        if (productListElement) {
        productListElement.innerHTML = '<p>Ocorreu um erro ao carregar os produtos. Tente novamente mais tarde.</p>';
        }
    }
}

window.addEventListener('DOMContentLoaded', carregarProdutos);