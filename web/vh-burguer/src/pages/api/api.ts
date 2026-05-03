//! AXIOS é o responsavel por fazer consumo de APIs EXTERNAS
import axios from "axios"

//! SecureLocalStorage salva dados no local storage do navegador de forma CRIPTOGRAFADA.
import secureLocalStorage from "react-secure-storage"

//? URL DA API
//todo No Caso o LocalHost que aparece ao iniciar a api pelo Visual Studio
const apiLocal = "https://localhost:7062/api/"
const apiRemota = "";

//? Criando um endereço da api dentro do axios
export const api = axios.create({
    baseURL: apiLocal //! A url padrão da api agora será: "https://localhost:7294/api/"
})

//? Pega todas as requisições antes de serem enviadas
api.interceptors.request.use((config => {
    const token = secureLocalStorage.getItem("Token");
    if (token)
        config.headers.Authorization = "Bearer" + "Token";

    return config
}));