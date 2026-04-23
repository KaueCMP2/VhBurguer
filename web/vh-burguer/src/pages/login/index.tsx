import styles from "./login.module.css";
const Login = () => {
    return (
        <>
            <main className={styles.main}>
                <img src="../imgs/hamburguer_login.png" alt="Hambúrguer com ingredientes flutuando em camadas sobre fundo escuro."/>
                <div className={styles.campo_login}>
                    <h1>Login</h1>
                    <form className={styles.formulario}>
                        <div className={styles.campo_form}>
                            <label htmlFor="email">E-mail</label>
                            <input type="text" name="email" placeholder="email@exemplo.com" required />
                        </div>
                        <div className={styles.campo_form}>
                            <label htmlFor="senha">Senha</label>
                            <input type="password" name="senha" placeholder="*******" required />
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