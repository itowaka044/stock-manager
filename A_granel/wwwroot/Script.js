console.log("teste");



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

        const inputId = `input-quantity-${produto.id}`;

        //  HTML do elemento com os detalhes do produto
        itemProduto.innerHTML = `
            <h3>${produto.name || 'Nome não disponível'}</h3>
            <p><strong>ID:</strong> ${produto.id || 'N/A'}</p>
            <p><strong>Data de Vencimento: ${produto.expDate}</p>
            <p><strong>Preço p/100 Gramas:</strong> R$ ${(produto.pricePer100G / 100)}</p>
            <p><strong>Quantidade (em Gramas):</strong> ${produto.quantity}</p>
            <div style="display: flex; width: 100%; height: 25px; gap: 5px">
                <input id="${inputId}" style="width: 50%; height: 25px" type="number"/> <button onclick="alterarQuantityProduto(${produto.id})" style="width: 50%; height: 25px">Alterar</button>
            </div>
            <button onclick="excluirProduto(${produto.id})" style="cursor: pointer;width: 100%; height: 25px; margin-top: 5px">Excluir</button>
            <hr>
        `;

        productListElement.appendChild(itemProduto);
        });

    } catch (error) {
        console.error('Falha ao carregar os produtos:', error);
        if (productListElement) {
            productListElement.innerHTML = '<p>Ocorreu um erro ao carregar os produtos.</p>';
        }
    }
}

window.addEventListener('DOMContentLoaded', carregarProdutos);



async function cadastrarProduto(){
    // pega os valores do formulario 
    const name = document.getElementById("name").value;
    console.log(name);
    const expDate = document.getElementById("expDate").value;
    console.log(expDate);
    const pricePer100G = document.getElementById("pricePer100G").value;
    console.log(pricePer100G);
    const quantity = document.getElementById("quantity").value;
    console.log(quantity);

    try{
        const response = await fetch("http://localhost:5067/Product",{
            method: "POST",
            headers:{
                "Content-type" : "application/json"
            },
            body: JSON.stringify({ // converte os dados para jason
                Name : name,
                ExpDate : expDate,
                PricePer100G : pricePer100G,
                Quantity : quantity
            })
        });
        // verifica a resposta
        if (!response.ok){
            throw new Error(`Erro na requisição: ${response.status} ${response.statusText}`);
        }

        const product = await response.json();

        alert("produto: " + product.name + " criado");
        carregarProdutos();
    } catch (error){
        console.log(error.message);
        alert("erro ao criar produto");
    }
}

async function excluirProduto(id) {
    console.log("excluirProduto ok");
    try {
        const response = await fetch(`http://localhost:5067/Product/${id}`, {
            method: 'DELETE',
            headers : {
                'Content-Type' : 'application/json'
            }
        });
        if(!response.ok){
            throw new Error("Erro ao deletar");
            alert("erro ao deletar produto, id: " + id);
        }
        carregarProdutos();
        const result = await response.json();
        console.log('Resposta do servidor:', result);
        
        } catch (error) {
            console.error('Falha ao excluir o produto:', error);
        }
}

async function alterarQuantityProduto(id) {

    const inputId = `input-quantity-${id}`;

    const inputElement = document.getElementById(inputId);

    const novaQuantidade = inputElement.value;

    try {
        const response = await fetch(`http://localhost:5067/Product/Quantity/${id}`, {
            method: 'PATCH',
            headers : {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                Quantity : novaQuantidade
            })
        });
        if(!response.ok){
            throw new Error("Erro ao alterar quantidade");
            alert("erro ao alterar quantidade, id: " + id);
        }
        carregarProdutos();
        console.log("alterar parte 2 ok");
        const result = await response.json();
        console.log('Resposta do servidor:', result);
        
        } catch (error) {
            console.error('Falha ao alterar quantidade:', error);
        }
}