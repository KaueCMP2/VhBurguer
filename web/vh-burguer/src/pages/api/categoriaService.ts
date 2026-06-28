import { erro, notificacao } from "@/utils/toasts";
import { api } from "./api"

interface CategoriaForm {
    nome: string
}

export async function cadastrarCategoriaService(nomeCategoria: string) {
    try {
        await api.post("Categoria", nomeCategoria);
        console.log("Categoria criada");
    }
    catch (error: any) {
        throw new Error(error.response.data);
    }
}

export async function listarCategoriaService() {
    try {
        const response = await api.get("Categoria");
        console.log(response.data);
        return response.data;
    }
    catch (error: any) {
        throw new Error(error.response.data);
    }
}

export async function adicionarCategoria(categoria: CategoriaForm) {
    try {
        await api.post("Categoria", categoria)
        notificacao("Categoria adicionada com sucesso!");
    }
    catch (error: any) {
        erro("Erro ao adicionar categoria!");
        console.log(error.response.data);
    }
}