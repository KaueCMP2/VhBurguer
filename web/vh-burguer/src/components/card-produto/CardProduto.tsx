import React from 'react'
import styles from '../card-produto/CardProduto.module.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleInfo, faEnvelope, faPencil, faSliders, faTrash } from '@fortawesome/free-solid-svg-icons';
import Link from 'next/link';

const CardProduto = () => {
  return (
    <article className={styles.card}>
      <img src="../imgs/hamburguer_alcatra.png" alt="Um lindo hamburguer, sobre uma tabua de madeira e uma faca do lado." className={styles.img_card} />
      <div className={styles.nome_produto}>
        <h3 className={styles.titulo_card}>Monster</h3>
      </div>
      <div className={styles.desc_card_content}>
        <p className={styles.desc_card}>Hámburguer brutal, suculento e exageradamente saboroso</p>
      </div>
      <div className={styles.preco_content}>
        <span className={styles.preco}>R$: 35,00</span>
        <div className={styles.container_icons}>
          <Link href='/historico-produto'>
            <FontAwesomeIcon icon={faCircleInfo} style={{ color: "rgb(255, 163, 0)", }} fontSize='35' />
          </Link>

          <button>
            <FontAwesomeIcon className={styles.icon} icon={faTrash} style={{ color: "rgb(255, 163, 0)", }} fontSize='30' />
          </button>

          <Link href='/detalhe-produto'>
            <FontAwesomeIcon icon={faPencil} style={{ color: "rgb(255, 163, 0)", }} fontSize='30' />
          </Link>
        </div>
      </div>
    </article>
  )
}

export default CardProduto