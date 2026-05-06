import { api } from "./api";

export async function listarIdProduto(produtoId: number) {
    try {
        const response = await api.get("LogProduto/produto/" + produtoId);
    } catch (error: any) {
        throw new Error(error.response.data);
    }
}