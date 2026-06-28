import React, { useEffect, useState } from 'react'
import styles from '@/components/historico-produto/HistoricoProduto.module.css'
import ItemAlteracao from '../item-alteracao/ItemAlteracao'
import { useRouter } from 'next/router'
import { obterLogPorId } from '@/pages/api/LogProdutoService'
import { obterProdutoPorId } from '@/pages/api/produtoService'

interface ItemLogProduto {
    logId: number,
    produtoId: number,
    nomeAnterior: string,
    precoAnterior: number
    dataAlteracao: Date
}

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

const HistoricoProduto = () => {
    const [itemLogs, setItemLogs] = useState<ItemLogProduto[]>([])
    const [produto, setProduto] = useState<Produto | null>(null);

    const router = useRouter();
    const { id } = router.query;

    async function carregarProd() {
        const prod = await obterProdutoPorId(Number(id));
        setProduto(prod);
    }

    async function carregarLog() {
        const itens = await obterLogPorId(Number(id));
        setItemLogs(itens);
    }

    useEffect(() => {
        if (router.isReady) {
            console.log(id)
            carregarProd();
            carregarLog();
        }

    }, [router.isReady, id])

    return (
        <main id={styles.main}>
            <div className={styles.container_titulo}>
                <h1 id={styles.titulo}>
                    {`Historico de alterações: ${produto?.nome}`}
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
                    {itemLogs.length <= 0 ? (<tr><td>Nenhuma atualização...</td></tr>) : itemLogs.map((item) => (

                        < ItemAlteracao key={item.logId}
                            item={item} />
                    ))}
                </tbody>
            </table>
        </main >
    )
}

export default HistoricoProduto