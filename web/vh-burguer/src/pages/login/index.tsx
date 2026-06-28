import { useEffect, useState } from "react";
import styles from "./login.module.css";
import { login } from "../api/authService";
import secureLocalStorage from "react-secure-storage";
import { useRouter } from "next/router";
const Login = () => {
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [token, setToken] = useState("");

    const router = useRouter();
    async function logar() {
        setToken(await login(email, senha))
    }

    useEffect(() => {
        if (token == secureLocalStorage.getItem("Token")) {
            setTimeout(() => {
                router.push("/home-adm")
            }, 2000)
        }
    }, [token])

    return (
        <>
            <main className={styles.main}>
                <img src="../imgs/hamburguer_login.png" alt="Hambúrguer com ingredientes flutuando em camadas sobre fundo escuro." />
                <div className={styles.campo_login}>
                    <h1>Login</h1>
                    <form className={styles.formulario} onSubmit={(e) => {
                        e.preventDefault();
                        logar();
                    }}>
                        <div className={styles.campo_form}>
                            <label htmlFor="email">E-mail</label>
                            <input type="text" name="email" placeholder="email@exemplo.com" required onChange={(e) => setEmail(e.target.value)} />
                        </div>
                        <div className={styles.campo_form}>
                            <label htmlFor="senha">Senha</label>
                            <input type="password" name="senha" placeholder="*******" required onChange={(e) => setSenha(e.target.value)} />
                        </div>
                        <a className={styles.esq_senha} href="">Esqueceu sua senha?</a>
                        <button>Entrar</button>
                    </form>
                </div>
            </main>
        </>
    )
}

export default Login;