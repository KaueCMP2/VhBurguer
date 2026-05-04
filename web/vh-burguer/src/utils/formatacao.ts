const FormatarPreco = (preco : number) => {
    return (
        preco.toLocaleString("pt-br", {
            style: "currency", //? R$: 
            currency: "BRL" //? 25,00
        })
    )

}

export default FormatarPreco;