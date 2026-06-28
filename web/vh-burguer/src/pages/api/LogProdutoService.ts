import { erro } from "@/utils/toasts";
import { api } from "./api";

export async function obterLogPorId(id: number) {
    try {
        const response = await api.get(`LogProduto/produto/${id}`)
        return response.data
    }
    catch (error: any) {
        erro(error.response?.data || error.response?.data.message || error.response?.data.errors)
    }
}