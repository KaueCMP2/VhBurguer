import { api } from "./api"

//? Base para cadastro de produtos
type ProdutoFormaulario = {
    ProdutoId: number,
    Nome: string,
    Descricao: string,
    Preco: string,
    Imagem: File | null,
    CategoriaIds: number[]
}

interface ProdutoListagem {
    ProdutoId: number,
    Nome: string,
    Descricao: string,
    Preco: string,
    Imagem: File | null,
    CategoriaIds: number[]
    StatusProduto: boolean,
    ImagemUrl: string
}

export async function cadastrarProduto(dados: ProdutoFormaulario) {
    try {
        const formData = new FormData();
        formData.append("Nome", dados.Nome);
        formData.append("Preco", dados.Preco);
        formData.append("Descricao", dados.Descricao);
        if (dados.Imagem)
            formData.append("imagem", dados.Imagem)

        dados.CategoriaIds.forEach((id: number) => {
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

        const produtos = response.data.map((produto: ProdutoListagem) => ({
            ...produto,
            ImagemUr: `${api.defaults.baseURL} ${produto.Imagem}`
        }));

        const produtosAtivos = produtos.data.filter(
            (produto: ProdutoListagem) => produto.StatusProduto === true
        );

        return produtos
    } catch (error: any) {
        return Error(error.response.data)
    }
}


export async function obterProdutoPorId(id: number) {
    try {
        const response = await api.get("Produto/" + id);

        const produto = {
            ...response.data,
            imagemUrl: `${api.defaults.baseURL}${response.data.imagemUrl}`
        };

        return produto;

    } catch (error: any) {
        throw new Error(error.response.data)
    }
}

export async function editarProduto(produtoId: number, dados: ProdutoFormaulario) {
    try {
        const formData = new FormData();
        formData.append("Nome", dados.Nome);
        formData.append("Preco", dados.Preco);
        formData.append("Descricao", dados.Descricao);
        if (dados.Imagem)
            formData.append("imagem", dados.Imagem)

        dados.CategoriaIds.forEach((id: number) => {
            formData.append("categoriaIds", id.toString());
        })
        await api.put(("Produto/" + produtoId), formData);
        console.log("Produto cadastrado");
    } catch (error: any) {
        throw new Error(error.response.data)
    }
}

export async function excluirProdutoPorId(produtoId: number) {
    try {
        await api.delete("Produto/" + produtoId)
    } catch (error: any) {
        throw new Error(error.response.data)
    }
}