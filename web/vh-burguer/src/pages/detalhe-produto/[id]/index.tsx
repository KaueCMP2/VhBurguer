import Footer from '@/components/footer/Footer';
import SubHeader from '@/components/sub-header/SubHeader';
import React from 'react'
import styles from '@/pages/detalhe-produto/detalhe_produto.module.css'

const DetalheProduto = () => {
    return (
        <>
            <SubHeader />

            <main id={styles.main}>
                <section id={styles.detalhes_produto}>
                    <h1 id={styles.titulo}>DETALHE DO X-BACON</h1>
                    <div className={styles.container_detalhes}>
                        <div className={styles.descricao}>
                            <img src="../imgs/hamburguer_alcatra.png" alt="Um lindo hamburguer, sobre uma tabua de madeira e uma faca do lado." className={styles.img_desc} />
                            <div className={styles.titulo_descricao_content}>
                                <h2 id={styles.titulo_descricao}>Descricão</h2>
                                <p className={styles.paragrafo_descricao}>Um pão brioche macio segura a fera: duas (ou três) carnes altas e suculentas, queijo chehdar derretido escorrendo pelas laterais, bacon crocante, cebola caramelizada no ponto adocicado, alface fresca, tomate e um molho especial intenso que amarra tudo. Para completar o ataque, uma camada extra de onion rings ou molho defumado que transforma cada mordida numa explosão.</p>
                            </div>

                            <div className={styles.descricao_components}>
                                <div className={styles.preco_descricao_content}>
                                    <h2 id={styles.preco_descricao}>Preco (R$)</h2>
                                    <p><s>R$:45,00</s> <strong>R$:35,00</strong></p>
                                </div>

                                <div className={styles.categoria_descricao_content}>
                                    <h2 id={styles.categoria_descricao}>Categoria</h2>
                                    <ul className={styles.lista_categorias}>
                                        <li>Premium</li>
                                        <li>Artesanal</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </main>

            <Footer />
        </>
    )
}

export default DetalheProduto;