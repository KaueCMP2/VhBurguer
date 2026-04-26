import React from 'react'
import styles from '@/components/item-alteracao/ItemAlteracao.module.css'

const ItemAlteracao = () => {
    return (
        <tr className={styles.container_itens}>
            <td className={styles.item}>12/12/12</td>
            <td className={styles.item}>Monstro</td>
            <td className={styles.item}>R$55,00</td>
        </tr>
    )
}

export default ItemAlteracao