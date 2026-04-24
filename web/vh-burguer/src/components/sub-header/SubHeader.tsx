import React from 'react'
import styles from '@/components/sub-header/SubHeader.module.css'
import Link from 'next/link'

const SubHeader = () => {
    return (
        <header id={styles.header}>
            <div className={`${styles.conteiner_sub_header} _layout_guid`}>
                <img className={styles.logo_img} src="../imgs/logo_footer.svg" alt="Logo Vh burguer com hamburguer de fundo" />
                <Link href="/home-adm" id={styles.link_voltar}>Voltar</Link>
            </div>
        </header >
    )
}

export default SubHeader