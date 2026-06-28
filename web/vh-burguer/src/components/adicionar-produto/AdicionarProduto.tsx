import React, { useEffect, useState } from 'react'
import styles from '@/components/adicionar-produto/AdicionarProduto.module.css'
import Link from 'next/link'
import { cadastrarProdutoService, editarProduto, obterProdutoPorId, urlToFile } from '@/pages/api/produtoService'
import { listarCategoriaService } from '@/pages/api/categoriaService'
import { erro, notificacao } from '@/utils/toasts'

interface ProdutoListagem {
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

type ProdutoForm = {
    Nome: string,
    Descricao: string,
    Imagem: File | null,
    Preco: string,
    categoriaIds: number[]
}

interface Categoria {
    categoriaId: number,
    nome: string
}

const ContentSalvarProduto = ({ produtoId }: { produtoId?: string }) => {
    const [isEdit, setIsEdit] = useState(produtoId == null ? false : true);
    const [produto, setProuduto] = useState<ProdutoListagem | null>(null);
    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");
    const [imagem, setImg] = useState<File | null>(null);
    const [preco, setPreco] = useState("");
    const [categoriaIds, setCategoriaIds] = useState<number[]>([]);
    const [categorias, setCategorias] = useState<Categoria[]>([]);

    async function carregarProduto() {
        if (isNaN(Number(produtoId))) return;

        const prod = await obterProdutoPorId(Number(produtoId));
        setProuduto(prod);
    }

    async function carregarCategorias() {
        const categs = await listarCategoriaService();
        setCategorias(categs);
    }

    useEffect(() => {
        carregarCategorias()
    }, [])

    useEffect(() => {
        if (produtoId) {
            carregarProduto();
        } else {
            setIsEdit(false)
        }
    }, [produtoId])

    const produtoAdicionado = {
        Nome: nome,
        Descricao: descricao,
        Imagem: imagem,
        Preco: preco,
        categoriaIds
    }

    async function guardarImagem(url: string) {
        if (!url) return;

        try {
            const arquivoFile = await urlToFile(url, "imgProduto.jpg");
            setImg(arquivoFile);
            notificacao('URL convertida com sucesso!');
        }
        catch {
            erro("Falha ao converter url!")
            erro("URL inválida!!!")
        }
    }

    return (
        <main id={styles.main}>
            <h1 id={styles.titulo}>{isEdit ? "Editar produto" : "CRIAR PRODUTO"}</h1>
            <form action="" id={styles.form_add_prod} onSubmit={(e) => {
                e.preventDefault();
                if (!isEdit) {
                    cadastrarProdutoService(produtoAdicionado);
                    console.log(produtoAdicionado)
                }

                editarProduto(Number(produtoId), produtoAdicionado)
            }}>
                <div className={styles.content_label}>
                    <label htmlFor="nome-produto" className='label'>Nome produto</label>
                    <input type="text" className={styles.input_pequena} name='nome-produto' defaultValue={produto?.nome} placeholder='BBQ Especial' onChange={(e) => setNome(e.target.value)} />
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="descricao">Descrição</label>
                    <input type="text" className={styles.input_grande} name='descricao' defaultValue={produto?.descricao} placeholder='Hamburguer com molho barbecue defumado com cebola' onChange={(e) => setDescricao(e.target.value)} />
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="preco" className='label'>Preço (R$)</label>
                    <input type="text" className={styles.input_pequena} name='preco' defaultValue={produto?.preco} placeholder='40,00' onChange={(e) => setPreco(e.target.value)} />
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="categoria" className='label'>categoria</label>
                    <select multiple name='categoria' onChange={(e) => setCategoriaIds((valoresAntigos) => {
                        const valorId = Number(e.target.value);

                        if (valoresAntigos.includes(valorId))
                            return valoresAntigos.filter((valorId) => valorId !== valorId)

                        return [...valoresAntigos, valorId]
                    })}>
                        {categorias.length < 0 ? (<option value=" "></option>) : categorias.map((categoria) => (
                            <option key={categoria.categoriaId} value={categoria.categoriaId}>{categoria.nome}</option>)
                        )}
                    </select>
                    <div className={styles.container_link}>
                        <Link href='/adicionar-categoria' id={styles.link_categoria}>Adicionar categoria</Link>
                    </div>
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="url-img" className='label'>URL da imagem</label>
                    <input type="text" className={styles.input_pequena} name='url-img' placeholder='https://unsplash.com/pt-br/fotografias/cheseburger-de-' onBlur={(e) => guardarImagem(e.target.value)} />
                </div>

                <button type='submit'>Salvar</button>
            </form>
        </main >
    )
}

export default ContentSalvarProduto