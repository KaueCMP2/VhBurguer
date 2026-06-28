import React, { useState } from 'react'
import styles from '@/components/item-alteracao/ItemAlteracao.module.css'

interface ItemLogProduto {
    logId: number,
    produtoId: number,
    nomeAnterior: string,
    precoAnterior: number
    dataAlteracao: Date
}

const ItemAlteracao = ({ item }: { item: ItemLogProduto }) => {

    return (
        <tr className={styles.container_itens}>
            <td className={styles.item}>{String(item?.dataAlteracao)}</td>
            <td className={styles.item}>{item?.nomeAnterior}</td>
            <td className={styles.item}>R$: {item?.precoAnterior}</td>
        </tr>
    )
}

export default ItemAlteracao