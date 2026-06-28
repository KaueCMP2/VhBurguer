import { toast } from "react-toastify"

export const notificacao = (msg: string) => toast.success(msg);
export const erro = (msg: string) => toast.error(msg);

export const toastConfirmarExclusao = (aoConfirmar: () => void) => {
    toast(
        ({ closeToast }) => (
            <div style={{ fontFamily: "var(--font-fredoka)", color: "var(--fonte-escura)" }}>
                <p style={{ fontWeight: "500", fontSize: "16px" }}>Deseja realmente excluir?</p>

                <div style={{ display: "flex", gap: "10px", marginTop: "12px" }}>
                    {/* Botão Sim: Laranja Destaque */}
                    <button
                        onClick={() => { aoConfirmar(); closeToast(); }}
                        style={{
                            flex: 1, border: "none", padding: "8px", borderRadius: "8px",
                            backgroundColor: "var(--laranja-destaque)", color: "#fff",
                            cursor: "pointer", fontWeight: "bold"
                        }}
                    >
                        Sim
                    </button>

                    {/* Botão Cancelar: Vinho do projeto */}
                    <button
                        onClick={closeToast}
                        style={{
                            flex: 1, border: "none", padding: "8px", borderRadius: "8px",
                            backgroundColor: "var(--vinho)", color: "#fff",
                            cursor: "pointer", fontWeight: "bold"
                        }}
                    >
                        Cancelar
                    </button>
                </div>
            </div>
        ),
        {
            autoClose: false,
            closeOnClick: false,
            draggable: false,
            position: "top-center" // Centralizado no topo fica excelente para confirmações
        }
    );
};
