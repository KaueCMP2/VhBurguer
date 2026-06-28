import React from 'react'
import styles from '../card-produto/CardProduto.module.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleInfo, faEnvelope, faPencil, faSliders, faTrash } from '@fortawesome/free-solid-svg-icons';
import Link from 'next/link';
import { deletarProduto } from '@/pages/api/produtoService';
import { toastConfirmarExclusao } from '@/utils/toasts';
import { usePathname } from 'next/navigation';

interface Produto {
  produtoID: number,
  nome: string,
  preco: number,
  descricao: string,
  imagemUrl: string,
  statusProduto: boolean,
  categoriaIds: number[],
  categorias: string[],
  usuarioID: number,
  usuarioNome: string,
  usuarioEmail: string
}

const CardProduto = ({ produto }: { produto: Produto }) => {
  async function removerProduto() {
    const id: number = produto.produtoID;
    toastConfirmarExclusao(async () => {
      await deletarProduto(produto)
    })
  }

  const pathname = usePathname();

  return (
    <article className={styles.card}>
      <img src={produto.imagemUrl} alt="Um lindo hamburguer, sobre uma tabua de madeira e uma faca do lado." className={styles.img_card} />
      <div className={styles.nome_produto}>
        <h3 className={styles.titulo_card}>{produto.nome}</h3>
      </div>
      <div className={styles.desc_card_content}>
        <p className={styles.desc_card}>{produto.descricao}</p>
      </div>
      <div className={styles.preco_content}>
        <span className={styles.preco}>R$: {produto.preco}</span>
        {pathname == "/home-adm" ? (

          <div className={styles.container_icons}>
            <Link href={`/historico-produto/${produto.produtoID}`}>
              <FontAwesomeIcon icon={faCircleInfo} style={{ color: "rgb(255, 163, 0)", }} fontSize='35' />
            </Link>

            <button onClick={(e) => {
              e.preventDefault();
              removerProduto();
            }}>
              <FontAwesomeIcon className={styles.icon} icon={faTrash} style={{ color: "rgb(255, 163, 0)", }} fontSize='30' />
            </button>

            <Link href={`/editar-produto/${produto.produtoID}`}>
              <FontAwesomeIcon icon={faPencil} style={{ color: "rgb(255, 163, 0)", }} fontSize='30' />
            </Link>
          </div>
        ) : ""}
      </div>
    </article>
  )
}

export default CardProduto