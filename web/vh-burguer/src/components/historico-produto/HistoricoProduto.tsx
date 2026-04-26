import React from 'react'
import styles from '@/components/historico-produto/HistoricoProduto.module.css'
import ItemAlteracao from '../item-alteracao/ItemAlteracao'

const HistoricoProduto = () => {
    return (
        <main id={styles.main}>
            <div id={styles.container} className='layout_guid'>
                <h1 id={styles.titulo}>
                    Historico de alterações: Monstro
                </h1>

                <table id={styles.tabela}>
                    <thead id={styles.corpo_tabela}>
                        <tr id={styles.cabecalho}>
                            <th className={styles.titulo_tabela}>Data alteração</th>
                            <th className={styles.titulo_tabela}>Nome anterior</th>
                            <th className={styles.titulo_tabela}>Preço anterior</th>
                        </tr>

                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                        <ItemAlteracao />
                    </thead>
                </table>
            </div>
        </main >
    )
}

export default HistoricoProduto