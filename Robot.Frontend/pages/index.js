import { GetStaticProps } from "next";
import Braco from "../components/braco";
import Cabeca from "../components/cabeca";
import axios from "axios";
import https from "https";

export default function Home(props) {
  return [
    <main>
      <Cabeca cabeca={props.robo?.cabeca} />
      <div className="bracos" key="bracos">
        <Braco
          title="Braço Esquerdo"
          braco={props.robo?.bracoEsquerdo}
          esquerdo={true}
        />
        <Braco title="Braço Direito" braco={props.robo?.bracoDireito} />
      </div>
    </main>,
  ];
}

export async function getServerSideProps(context) {
  const agent = new https.Agent({  
    rejectUnauthorized: false
  });

  let response = await axios.get("https://localhost:44313/Robo", { httpsAgent: agent })

  return {
    props: {
      robo: response.data
    },
  };
}
