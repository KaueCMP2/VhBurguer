import secureLocalStorage from "react-secure-storage";
import { api } from "./api"

export async function loginService(email: string, senha: string) {
    try {
        //? Requisição
        const response = await api.post("Autenticacao/login", { email, senha });
        console.log("Usuario logado");

        const token = response.data.token;
        secureLocalStorage.setItem("tokenUser", token);
    } catch (error: any) {
        throw new Error("Emaill ou senha inválidos!");
    }
}