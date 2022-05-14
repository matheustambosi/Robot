import axios from "axios";
import style from "../styles/braco.module.css";
import Divider from "./divider";
import EstadoCotovelo from "./estadoCotovelo";
import EstadoPulso from "./estadoPulso";
import Router from "next/router";

export default function Braco(props) {
  return [
    <>
      <div className={style.header}>
        <h1>{props.title}</h1>
        <div className={style.container}>
          <div className={style.infobracos}>
            <h2>Cotovelo</h2>
            <EstadoCotovelo estado={props.braco?.cotovelo?.estado} />
            <div className={style.botoes}>
              <button className={style.botao} onClick={() => MovimentarBraco(props.esquerdo, 1, props.braco?.cotovelo?.estado, true)}>+</button>
              <button className={style.botao} onClick={() => MovimentarBraco(props.esquerdo, 1, props.braco?.cotovelo?.estado, false)}>-</button>
            </div>
          </div>
          <Divider />
          <div className={style.infobracos}>
            <h2>Pulso</h2>
            <EstadoPulso estado={props.braco?.pulso?.estado} />
            <div className={style.botoes}>
              <button className={style.botao} onClick={() => MovimentarBraco(props.esquerdo, 2, props.braco?.pulso?.estado, true)}>+</button>
              <button className={style.botao} onClick={() => MovimentarBraco(props.esquerdo, 2, props.braco?.pulso?.estado, false)}>-</button>
            </div>
          </div>
        </div>
      </div>
    </>,
  ];
}

export function MovimentarBraco(esquerdo, membro, estadoAtual, positivo) {
  let dto = {
    direcaoBraco: esquerdo ? 1 : 2,
    membroBraco: membro,
    proximoEstado: positivo ? estadoAtual + 1 : estadoAtual - 1
  };

  axios.post("https://localhost:44313/Robo/Movimentar/Braco", dto).then((res) => {
    if(res.status < 300)
        Router.reload()
  });
}

