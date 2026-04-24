import React from 'react'
import styles from '@/components/historico-produto/HistoricoProduto.module.css'

const HistoricoProduto = () => {
    return (
        <main id={styles.main}>
            <h1 id={styles.titulo}>
                Historico de alterações: Monstro
            </h1>

            <table className={styles.tabela}>
                <tr>
                    <th>Data alteração</th>
                    <th>Nome anterior</th>
                    <th>Preço anterior</th>
                </tr>
            </table>
        </main >
    )
}

export default HistoricoProduto