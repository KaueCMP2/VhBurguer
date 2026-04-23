import React from 'react'
import styles from './Header.module.css'
import Link from 'next/link'

const Header = () => {
    return (
        <header id={styles.header}>
            <div className={`${styles.container} layout_grid`}>

                <img className={styles.img} src="../imgs/logo_vh_burguer.svg" alt="Logo do vh burguer que contem como plano de fundo um hamburguer" />

                <nav id={styles.nav_menu}>
                    <a id={styles.a} href="#destaques">Destaques</a>
                    <a id={styles.a} href="#cardapio">Cardápio</a>
                    <a id={styles.a} href="#unidade">Unidade</a>
                    <Link id={styles.link} href='/login'>Login</Link>
                </nav>
                <button id={styles.btn_icon}>
                    <img src="../imgs/icon_hamburguer.svg" alt="Icone que representa um hamburguer para acesso ao menu lateral." className={styles.icon_hamburguer} />
                </button>
            </div>
        </header>
    )
}

export default Header