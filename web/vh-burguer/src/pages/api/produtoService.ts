import { api } from "./api"

type Produto = {
    ProdutoId: number,
    Nome: string,
    Descricao: string,
    Preco: string,
    Imagem: File | null,
    CategoriaIds: number[]
}

export async function cadastrarProdutoService(dados: Produto) {
    try {
        const formData = new FormData();
        formData.append("Nome", dados.Nome);
        formData.append("Preco", dados.Preco);
        formData.append("Descricao", dados.Descricao);
        if (dados.Imagem)
            formData.append("imagem", dados.Imagem)

        dados.CategoriaIds.forEach((id : number) => {
            formData.append("categoriaIds", id.toString());
        })
        await api.post("Produto"), { formData }
        console.log("Produto cadastrado");
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}

export async function listarProduto() {
    try {
        const response = await api.get("Produto")

        const produtos = response.data.map((produto: Produto) => ({
            ...produto,
            ImagemUr: `${api.defaults.baseURL} ${produto.Imagem}`
        }));

        return produtos
    } catch (error: any) {
        return Error(error.response.data)
    }
}

export async function obterPorId(id: number) {
    try {
        const response = await api.get("Produto/" + id)

        const produtos = response.data.map((produto: Produto) => ({
            ...produto,
            imagemUrl: `${api.defaults.baseURL} ${produto.Imagem}`
        }));

    } catch (error: any) {

    }
}