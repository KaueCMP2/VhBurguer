import React from 'react'
import styles from '../Footer/Footer.module.css'

const Footer = () => {
    return (
        <footer id={styles.footer}>
            <div id={styles.container_footer}>
                <div id={styles.aside_itens}>
                    <img className={styles.logo_img} src="../imgs/logo_footer.svg" alt="Logo Vh burguer com hamburguer de fundo" />
                    <div id={styles.social_icons}>
                        <a href="">
                            <img src="../imgs/tiktok.png" alt="logo tiktok" className={styles.icon_rede_social} />
                        </a>
                        <a href="">
                            <img src="../imgs/face.png" alt="logo facebook" className={styles.icon_rede_social} />
                        </a>
                        <a href="">
                            <img src="../imgs/insta.png" alt="logo instagram" className={styles.icon_rede_social} />
                        </a>
                        <a href="">
                            <img src="../imgs/youtube.png" alt="logo youtube" className={styles.icon_rede_social} />
                        </a>
                    </div>
                </div>
                <div id={styles.line}></div>
                <p id={styles.cop_text}>Copyright © 2025 VH Burguer | Todos os direitos reservados</p>
            </div>
        </footer>
    )
}

export default Footer