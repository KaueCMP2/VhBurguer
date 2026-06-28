import React, { useState } from 'react'
import Header from '../header/Header'
import Footer from '../footer/Footer'
import styles from '@/components/criar-categoria/ContentCriarCategoria.module.css'
import { adicionarCategoria } from '@/pages/api/categoriaService'

const ContentCriarCagoria = () => {
    const [nome, setNome] = useState("");

    const categoria = {
        nome
    };

    return (
        <>
            <main id={styles.main}>
                <h1 id={styles.titulo}>CRIAR CATEGORIA</h1>
                <form action="" id={styles.form_add_cat} onSubmit={(e) => {
                    e.preventDefault();
                    adicionarCategoria(categoria)
                }}>
                    <div className={styles.content_label}>
                        <label htmlFor="nome_categoria" className='label'>Nome categoria</label>
                        <input type="text" className="nome_categoria" name='nome-categoria' placeholder='Premium' onChange={(e) => setNome(e.target.value)} />
                    </div>

                    <div id={styles.content_botoes}>
                        <button type='submit' id={styles.btn_salvar}>Salvar</button>
                        <button type='submit' id={styles.btn_cancelar}>Cancelar</button>
                    </div>
                </form>
            </main>
        </>
    )
}

export default ContentCriarCagoria