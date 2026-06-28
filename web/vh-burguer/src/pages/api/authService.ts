import secureLocalStorage from "react-secure-storage";
import { api } from "./api"
import { erro, notificacao } from "@/utils/toasts";

export async function login(email: string, senha: string) {
    try {
        //? Requisição
        const response = await api.post("Autenticacao/login", { email, senha });
        notificacao("Login efetuado com sucesso!")

        const token = response.data.token;
        secureLocalStorage.setItem("Token", token);
        return token;
    }
    catch (error: any) {
        erro("Emaill ou senha inválidos!");
    }
}