import Header from "@/components/header/Header";
import styles from "../home/home.module.css"
import Footer from "@/components/footer/Footer";

import ListaProduto from "@/components/lista-produtos/ListaProdutos";
import SubHeader from "@/components/sub-header/SubHeader";

const Home = () => {
    return (
        <>
            <Header />
            <main id={`${styles.main} layout_guid`}>
                <section id={styles.banner}>
                    <div id={styles.conteiner_banner}>
                        <p id={styles.titulo}>BEM-VINDOS AO VH BURGUER</p>
                        <img src="../imgs/foto_de_hamburgueres.png" alt="Foto que contem tres bonitos hamburgueres." id={styles.img_banner} />
                        <div id={styles.buttons_header}>
                            <button id={styles.btn_chamar_atendente}>
                                Chamar atendente
                            </button>

                            <button id={styles.btn_ver_cardapio}>
                                Ver cardapio
                            </button>
                        </div>
                    </div>
                </section>

                <section className={styles.destaques} id="destaques">
                    <div id={styles.conteiner_destaques}>
                        <div className={styles.dest_grande}>
                            <p className={styles.dest_text}>Os queridinhos da galera</p>
                            <h3 className={styles.text_enfase}>MAIS PEDIDOS</h3>
                        </div>

                        <div className={styles.dest_peq_cima}>
                            <p className={styles.dest_text}>Lanches com</p>
                            <h3 className={styles.text_enfase}>MUITO BACON</h3>
                        </div>

                        <div className={styles.dest_peq_baixo}>
                            <p className={styles.dest_text}>Se tiver muita fome</p>
                            <h3 className={styles.text_enfase}>SUPER COMBOS</h3>
                        </div>
                    </div>
                </section>

                <ListaProduto />

                <section className={styles.unidades} id="unidades">
                    <div id={styles.side_unidades}>
                        <h3 id={styles.text_un_titulo}>Nossas uniddade</h3>
                        <li id={styles.unidades_lista}>
                            <ul className={styles.text_un_ul}>Centro - Av. Aurora, 742</ul>
                            <ul className={styles.text_un_ul}>Jardim - Av. das Palmeiras, 1280</ul>
                            <ul className={styles.text_un_ul}>Norte - Av. Horizonte, 305</ul>
                            <ul className={styles.text_un_ul}>Sul - Av. Nova esperança, 910</ul>
                        </li>
                    </div>
                </section>
            </main >
            <Footer />
        </>
    );
}

export default Home;