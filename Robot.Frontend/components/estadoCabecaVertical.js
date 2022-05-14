export default function EstadoCabecaVertical(props) {
  let estadoString = "";

  switch (props.estado) {
    case -1:
      estadoString = "Baixo";
      break;
    case 0:
      estadoString = "Em Repouso";
      break;
    case 1:
      estadoString = "Cima";
      break;
  }

  return <h2>{estadoString}</h2>;
}
