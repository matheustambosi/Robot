export default function EstadoCotovelo(props) {
  let estadoString = "";

  switch (props.estado) {
    case 0:
      estadoString = "Em Repouso";
      break;
    case 1:
      estadoString = "Levemente Contraído";
      break;
    case 2:
      estadoString = "Contraído";
      break;
    case 3:
      estadoString = "Fortemente Contraído";
      break;
  }

  return <h3>{estadoString}</h3>;
}
