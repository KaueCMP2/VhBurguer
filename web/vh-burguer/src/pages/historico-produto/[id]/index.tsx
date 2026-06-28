import Footer from "@/components/footer/Footer";
import Header from "@/components/header/Header";
import SubHeader from "@/components/sub-header/SubHeader";
import HistoricoProduto from "@/components/historico-produto/HistoricoProduto";
import { obterLogPorId } from "@/pages/api/LogProdutoService";

const Historico = () => {
    return (
        <>
            <SubHeader />
            <HistoricoProduto />
            <Footer />
        </>
    );
}

export default Historico;