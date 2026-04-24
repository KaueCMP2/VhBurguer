import React from 'react'
import styles from '@/components/adicionar-produto/AdicionarProduto.module.css'
import Link from 'next/link'

const ContentAddProduto = () => {
    return (
        <main id={styles.main}>
            <h1 id={styles.titulo}>CRIAR PRODUTO</h1>
            <form action="" id={styles.form_add_prod}>
                <div className={styles.content_label}>
                    <label htmlFor="nome-produto" className='label'>Nome produto</label>
                    <input type="text" className={styles.input_pequena} name='nome-produto' placeholder='BBQ Especial' />
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="descricao">Descrição</label>
                    <input type="text" className={styles.input_grande} name='descricao' placeholder='Hamburguer com molho barbecue defumado com cebola' />
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="preco" className='label'>Preço (R$)</label>
                    <input type="text" className={styles.input_pequena} name='preco' placeholder='40,00' />
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="categoria" className='label'>categoria</label>
                    <input type="select" className={styles.input_pequena} name='categoria' placeholder='Selecione a categoria' />
                    <div className={styles.container_link}>
                        <Link href='/adicionar-categoria' id={styles.link_categoria}>Adicionar categoria</Link>
                    </div>
                </div>

                <div className={styles.content_label}>
                    <label htmlFor="url-img" className='label'>URL da imagem</label>
                    <input type="text" className={styles.input_pequena} name='url-img' placeholder='https://unsplash.com/pt-br/fotografias/cheseburger-de-' />
                </div>

                <button type='submit'>Salvar</button>
            </form>
        </main>
    )
}

export default ContentAddProduto