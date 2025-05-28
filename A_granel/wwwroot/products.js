async function carregarProdutos() {
    const productListElement = document.getElementById('lista-produtos');
    if (!productListElement) {
        console.error('Elemento com ID "lista-produtos" não encontrado no HTML.');
        return;
    }
    try {
        const response = await fetch('http://localhost:5067/Product');

        if (!response.ok) {
        throw new Error(`Erro na requisição: ${response.status} ${response.statusText}`);
        }

        const produtos = await response.json();

        productListElement.innerHTML = '';

        if (produtos.length === 0) {
        productListElement.innerHTML = '<p>Nenhum produto encontrado.</p>';
        return;
        }
        produtos.forEach(produto => {

        const itemProduto = document.createElement('div'); 

        itemProduto.classList.add('produto-item'); 

        itemProduto.innerHTML = `
            <h3>${produto.name || 'Nome não disponível'}</h3>
            <p><strong>ID:</strong> ${produto.id || 'N/A'}</p>
            <p><strong>Data de Vencimento: ${produto.expDate}</p>
            <p><strong>Preço p/100 Gramas:</strong> R$ ${produto.pricePer100G}</p>
            <p><strong>Quantidade (em Gramas):</strong> ${produto.quantity}</p>
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