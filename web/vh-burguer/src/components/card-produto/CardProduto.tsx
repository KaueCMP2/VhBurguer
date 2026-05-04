import React from 'react'
import styles from '../card-produto/CardProduto.module.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleInfo, faEnvelope, faPencil, faSliders, faTrash } from '@fortawesome/free-solid-svg-icons';
import Link from 'next/link';
import FormatarPreco from '@/utils/formatacao';
import { useState } from 'react';
import { listarProduto } from '@/pages/api/produtoService';
import { erro } from '@/utils/toasts';

type produto = {
  produtoId: number
  nome: string,
  preco: number,
  descricao: string,
  imagemUrl: string
};

const CardProduto = (produto: produto) => {
  return (
    <article className={styles.card}>
      <link rel="stylesheet" href={"/detalhe-produto" + produto.produtoId} />
      <img src={produto.imagemUrl} alt="Um lindo hamburguer, sobre uma tabua de madeira e uma faca do lado." className={styles.img_card} />
      <div className={styles.nome_produto}>
        <h3 className={styles.titulo_card}>{produto.nome}</h3>
      </div>
      <div className={styles.desc_card_content}>
        <p className={styles.desc_card}>{produto.descricao}</p>
      </div>
      <div className={styles.preco_content}>
        <span className={styles.preco}>{FormatarPreco(produto.preco)}</span>
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