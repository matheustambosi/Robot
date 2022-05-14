export default function EstadoPulso(props) {
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
    case 3:
      estadoString = "135deg";
      break;
    case 4:
      estadoString = "180deg";
      break;
  }

  return <h3>{estadoString}</h3>;
}
