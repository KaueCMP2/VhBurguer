import { api } from "./api"
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
        return response;
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}