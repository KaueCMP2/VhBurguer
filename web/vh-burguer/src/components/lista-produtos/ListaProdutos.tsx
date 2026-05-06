import React, { useEffect, useState } from 'react'
import styles from '../lista-produtos/ListaProdutos.module.css'
import CardProduto from '../card-produto/CardProduto'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEnvelope, faSliders } from '@fortawesome/free-solid-svg-icons';
import Link from 'next/link';
import { excluirProdutoPorId, listarProduto } from '@/pages/api/produtoService';
import { toastConfirmarExclusao } from '@/utils/toasts';

type produtos = {
    produtoId: number,
    nome: string,
    preco: number,
    descricao: string,
    imagemUrl: string
};

const ListaProduto = () => {
    const [produtos, setProdutos] = useState<produtos[]>([]);

    async function listar() {
        try {
            const lista = await listarProduto();
            setProdutos(lista);
        } catch (error: any) {

            console.log(error.message)
        }
    }

    function confirmarExclusao(produtoId: number) {
        toastConfirmarExclusao(async () => {
            try {
                await excluirProdutoPorId(produtoId)
            } catch (error: any) {
                throw Error(error.message)
            } 
        })
    }

    useEffect(() => {
        listar()
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
                    {produtos.length > 0 ? produtos.map((item) => (
                        <CardProduto
                            key={item.produtoId}
                            produtoId={item.produtoId}
                            nome={item.nome}
                            descricao={item.descricao}
                            imagemUrl={item.imagemUrl}
                            preco={item.preco}
                            onDelete={confirmarExclusao}
                        />
                    ))
                        : (
                            <p> Carregando produtos...</p>
                        )}

                </div>
            </div>
        </section >
    )
}

export default ListaProduto