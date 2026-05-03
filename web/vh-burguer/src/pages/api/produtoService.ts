import { api } from "./api"

type Produto = {
    Nome: string,
    Descricao: string,
    Imagem: File | null,
    Preco: string,
    categoriaIds: number[]
}

export async function cadastrarProdutoService(dados: Produto) {
    try {
        const formData = new FormData();
        formData.append("Nome", dados.Nome);
        formData.append("Preco", dados.Preco);
        formData.append("Descricao", dados.Descricao);
        if (dados.Imagem)
            formData.append("imagem", dados.Imagem)

        dados.categoriaIds.forEach((id) => {
            formData.append("categoriaIds", id.toString());
        })
        await api.post("Produto"), { formData }
        console.log("Produto cadastrado");
    }
    catch (error: any) {
        throw new Error(error.response.data);
    }
}