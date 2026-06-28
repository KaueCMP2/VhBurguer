import { erro, notificacao, toastConfirmarExclusao } from "@/utils/toasts"
import { api } from "./api"
import { ApiError } from "next/dist/server/api-utils"

type ProdutoForm = {
    Nome: string,
    Descricao: string,
    Imagem: File | null,
    Preco: string,
    categoriaIds: number[]
}

interface ProdutoListagem {
    produtoID: number,
    nome: string,
    preco: number,
    descricao: string,
    imagemUrl: string,
    statusProduto: boolean,
    categoriaIds: number[],
    categorias: string[],
    usuarioID: number,
    usuarioNome: string,
    usuarioEmail: string
}

export async function urlToFile(url: string, fileName: string = "imagem_produto.jpg"): Promise<File> {
    const response = await fetch(url);
    const blob = await response.blob();
    const mimeType = blob.type || "image/jpeg";
    notificacao("URL válida!")
    return new File([blob], fileName, { type: mimeType });
}

export async function listarProdutos() {
    try {
        const response = await api.get("Produto");
        const produtos = response.data.map((produto: ProdutoListagem) => ({
            ...produto,
            imagemUrl: `${api.defaults.baseURL}Produto/${produto.imagemUrl}`
        }));
        console.log(produtos[0].imagemUrl);
        return produtos;
    } catch (error: any) {
        throw new Error(error.response.data)
    }
}

export async function obterProdutoPorId(id: number) {
    try {
        const response = await api.get(`Produto/${id}`)
        console.log(response.data)
        return response.data
    } catch (erro: any) {
        throw new Error(erro.response.data)
    }
}

export async function cadastrarProdutoService(dados: ProdutoForm) {
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
        await api.post("Produto", formData)
        notificacao("Produto cadastrado");
    }
    catch (error: any) {
        throw new Error(error.response?.data ||
            error.response?.data.message ||
            error.response?.data.errors
        );
    }
}

export async function editarProduto(id: number, dados: ProdutoForm) {
    try {
        const formData = new FormData();
        formData.append("Nome", dados.Nome);
        formData.append("Preco", dados.Preco);
        formData.append("Descricao", dados.Descricao);
        if (dados.Imagem)
            formData.append("imagem", dados.Imagem)

        formData.append("StatusProduto", "true")
        dados.categoriaIds.forEach((id) => {
            formData.append("categoriaIds", id.toString());
        })
        await api.put(`Produto/${id}`, formData)
        notificacao("Produto editado com sucesso");
    }
    catch (error: any) {
        throw new Error(error.response?.data ||
            error.response?.data.message ||
            error.response?.data.errors
        );
    }
}

export async function deletarProduto(produto: ProdutoListagem) {
    try {
        await api.delete(`Produto/${produto.produtoID}`)
        return notificacao("Produto excluido com sucesso!")
    } catch (error: any) {
        erro(
            error.response?.data ||
            error.response?.data.message ||
            error.response?.data.errors
        );
    }
}