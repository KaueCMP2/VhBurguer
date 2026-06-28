import React, { useEffect, useState } from 'react'
import styles from '../lista-produtos/ListaProdutos.module.css'
import CardProduto from '../card-produto/CardProduto'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEnvelope, faSliders } from '@fortawesome/free-solid-svg-icons';
import Link from 'next/link';
import { listarProdutos } from '@/pages/api/produtoService';

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

const ListaProduto = () => {
    const [produtos, setProdutos] = useState<Produto[]>([]);
    async function carregarProdutos() {
        const prods = await listarProdutos()
        setProdutos(prods)
    }

    useEffect(() => {
        carregarProdutos();
    }, [])

    return (
        <section className={styles.cardapio} id="cardapio">
            <h2 id={styles.titulo}>CARDÁPIO</h2>
            <div id={styles.container}>
                <div id={styles.botoes}>
                    <button id={styles.btn_filtro}>
                        <span className={styles.texto_btn_filtro}>Filtrar</span>
                        <FontAwesomeIcon icon={faSliders} />
                    </button>

                    <div className={styles.links_esquerda}>
                        <Link href='/adicionar-produto' className={styles.link_navegacao}>
                            Adicionar Produtos
                        </Link>

                        <Link href='/promocao' className={styles.link_navegacao}>
                            Promos
                        </Link>
                    </div>
                </div>
                <div id={styles.content}>
                    {produtos.length <= 0 ? (<p>Nenhum produtos encontrado...</p>)
                        : produtos.map((produto) => (
                            <CardProduto key={produto.produtoID}
                                produto={produto} />)
                        )
                    }
                </div>
            </div>
        </section >
    )
}

export default ListaProduto