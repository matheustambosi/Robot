export default function EstadoCabecaHorizontal(props) {
  let estadoString = "";

  switch (props.estado) {
    case -2:
      estadoString = "-90deg";
      break;
    case -1:
      estadoString = "-45deg";
      break;
    case 0:
      estadoString = "Em Repouso";
      break;
    case 1:
      estadoString = "45deg";
      break;
    case 2:
      estadoString = "90deg";
      break;
  }

  return <h2>{estadoString}</h2>;
}
