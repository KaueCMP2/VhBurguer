import React, { useEffect } from "react";
import { useState } from "react";
import { listarCategoriaService } from "../api/categoriaService"
import { cadastrarProdutoService } from "../api/produtoService";
import { notificacao, erro } from "@/utils/toasts"
import styles from "@/pages/produto/produto.module.css"
import Toast from "@/components/toast/Toast";
import SubHeader from "@/components/sub-header/SubHeader";
import Link from "next/link";
import Footer from "@/components/footer/Footer";

interface Categoria {
    categoriaId: number;
    nome: string;
}

const criarProduto = () => {
    const [nome, setNome] = useState<string>("");
    const [categoria, setCategoria] = useState<Categoria[]>([]);
    const [descricao, setDescricao] = useState<string>("");
    const [preco, setPreco] = useState<string>("");
    const [img, setImg] = useState<File | null>(null);
    const [categoriaSelecionada, setCategoriaSelecionada] = useState<number[]>([],);

    async function listarCategoriaEmProduto() {
        const list = await listarCategoriaService();
        setCategoria(list.data);
    }

    console.log(categoria);

    async function Cadastrar(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        try {

            await cadastrarProdutoService({
                Nome: nome,
                Descricao: descricao,
                Preco: preco,
                Imagem: img,
                categoriaIds: categoriaSelecionada,
            });

            notificacao("Produto cadastrado");
        }
        catch (error: any) {
            console.log(error.message);
        }
    }

    //? QUANDO O PRODUTO FOR FINALIZADO, A FUNÇÃO ListarCategoriaEmProduto É CHAMDA.
    useEffect(() => {
        listarCategoriaEmProduto();
    }, []) //! Estranho, a verdade é que a cada atualizacao a função vai ser chamada.

    return (
        <>
            <Toast />
            <SubHeader />
            <main id={styles.main} className="layout_guide">
                <h1>Criar produto</h1>
                <form id={styles.formulario} onSubmit={Cadastrar}>
                    <div className={styles.inserir_dados}>
                        <label htmlFor="nome">Nome do produto</label>
                        <input type="text" name="nome" placeholder="BBQ Especial" />
                    </div>

                    <div className={styles.inserir_dados} id={styles.descricao}>
                        <label htmlFor="">Descrição</label>
                        <textarea
                            value={descricao}
                            onChange={(e) => setDescricao(e.target.value)}
                        ></textarea>
                    </div>

                    <div className={styles.inserir_dados}>
                        <label htmlFor="preco">Preço(R$)</label>
                        <input type="text" name="preco" placeholder="40,00" />
                    </div>

                    <div className={styles.inserir_dados} id={styles.selectDiv}>
                        <label htmlFor="categorias">Categoria</label>
                        <select
                            onChange={(e) =>
                                setCategoriaSelecionada(
                                    Array.from(e.target.selectedOptions).map((option) =>
                                        Number(option.value),
                                    ),
                                )
                            }
                            id={styles.select}
                        >

                            {categoria.map((item) => (
                                <option value={item.categoriaId} key={item.categoriaId}>
                                    {item.nome}
                                </option>
                            ))}

                        </select>
                        <Link href="/login" id={styles.adicionarC}>
                            Adicionar categoria
                        </Link>
                    </div>

                    <div className={styles.inserir_dados}>
                        <label htmlFor="url_img">URL da Imagem</label>
                        <input
                            type="file"
                            onChange={(e) => {
                                if (e.target.files && e.target.files[0])
                                    setImg(e.target.files[0]);
                                else return;
                            }}
                            name="url_img"
                            placeholder="https://unsplash.com/pt-br/fotografias/cheseburger-de-"
                        />
                    </div>

                    <div className={styles.enviar_botoes}>
                        <button id={styles.add_save}>Salvar</button>
                    </div>
                </form>
            </main>
            <Footer />
        </>
    );
};

export default criarProduto;