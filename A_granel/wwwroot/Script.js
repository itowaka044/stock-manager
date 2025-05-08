console.log("teste");

async function getValues(){

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
            body: JSON.stringify({
                Name : name,
                ExpDate : expDate,
                PricePer100G : pricePer100G,
                Quantity : quantity
            })
        });
        if (!response.ok){
            throw new Error("erro ao criar produto");
        }

        const product = await response.json();

        alert("produto: " + product.name + " criado");
    } catch (error){
        console.log(error.message);
        alert("erro ao criar produto")
    }


}