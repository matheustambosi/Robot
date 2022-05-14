import style from "../styles/cabeca.module.css";
import Divider from "./divider";
import EstadoCabecaHorizontal from "./estadoCabecaHorizontal";
import EstadoCabecaVertical from "./estadoCabecaVertical";
import axios from "axios";
import Router from "next/router";

export default function Cabeca(props) {
  return [
    <>
      <div className={style.header}>
        <h1>Cabeça</h1>
        <div className={style.container}>
          <div className={style.infocabeca}>
              <h2>Horizontal</h2>
              <EstadoCabecaHorizontal estado={props.cabeca?.eixoHorizontal} />
              <div className={style.botoes}>
                <button className={style.botao} onClick={() => MovimentarCabeca(true, props.cabeca?.eixoHorizontal, true)}>+</button>
                <button className={style.botao} onClick={() => MovimentarCabeca(true, props.cabeca?.eixoHorizontal, false)}>-</button>
              </div>
            </div>
            <Divider />
            <div className={style.infocabeca}>
              <h2>Vertical</h2>
              <EstadoCabecaVertical estado={props.cabeca?.eixoVertical} />
              <div className={style.botoes}>
                <button className={style.botao} onClick={() => MovimentarCabeca(false, props.cabeca?.eixoVertical, true)}>+</button>
                <button className={style.botao} onClick={() => MovimentarCabeca(false, props.cabeca?.eixoVertical, false)}>-</button>
              </div>
            </div>
        </div>
      </div>
    </>,
  ];
}

export function MovimentarCabeca(horizontal, estadoAtual, positivo) {
  let dto = {
    direcao: horizontal ? 1 : 2,
    proximoEstado: positivo ? estadoAtual + 1 : estadoAtual - 1
  };

  axios.post("https://localhost:44313/Robo/Movimentar/Cabeca", dto).then((res) => {
    if(res.status < 300)
      Router.reload()
  });
}
