import React from 'react'
import styles from '@/components/historico-produto/HistoricoProduto.module.css'
import ItemAlteracao from '../item-alteracao/ItemAlteracao'

const HistoricoProduto = () => {
    return (
        <main id={styles.main}>
                <div className={styles.container_titulo}>
                    <h1 id={styles.titulo}>
                        Historico de alterações: Monstro
                    </h1>
                </div>

                <table id={styles.tabela}>
                    <thead id={styles.cabecalho_tabela}>
                        <tr id={styles.cabecalho}>
                            <th className={styles.titulo_tabela}>Data alteração</th>
                            <th className={styles.titulo_tabela}>Nome anterior</th>
                            <th className={styles.titulo_tabela}>Preço anterior</th>
                        </tr>
                    </thead>

                    <tbody id={styles.itens_tabela}>
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                    </tbody>
                </table>
        </main >
    )
}

export default HistoricoProduto