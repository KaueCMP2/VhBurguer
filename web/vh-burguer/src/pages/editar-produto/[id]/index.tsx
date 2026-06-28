import ContentSalvarProduto from "@/components/adicionar-produto/AdicionarProduto";
import ContentAddProduto from "@/components/adicionar-produto/AdicionarProduto";
import Footer from "@/components/footer/Footer";
import SubHeader from "@/components/sub-header/SubHeader";
import { useRouter } from "next/router";
import React, { useEffect } from "react";

const AdicionarProduto = () => {
    const router = useRouter();
    const { id } = router.query;

    useEffect(() => {
        if (router.isReady)
            console.log(id);
    }, [router.isReady, id])

    return (
        <>
            <SubHeader />
            <ContentSalvarProduto produtoId={String(id)} />
            <Footer />
        </>
    );
}

export default AdicionarProduto