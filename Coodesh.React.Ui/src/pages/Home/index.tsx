import { useState } from 'react';
import axios from 'axios';
import './home.scss';
import GridCard from '../../components/GridCard';
import config from '../../appsettings.json';

export default function Home() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const [arquivo, setArquivo] = useState();

  const handleFileChange = (event: any) => {
    const selectedFile = event.target.files[0];
    setArquivo(selectedFile);
  };

  const handleSubmit = async (event: any) => {
    event.preventDefault();

    if (arquivo) {
      const fileReader = new FileReader();

      fileReader.onload = async (e: any) => {
        const content = e.target.result;

        const lines = content.split('\n');

        for (let i = 0; i < lines.length; i++) {
          const linha = lines[i];

          // 1º Intervalo: Início 1 e Fim 1
          const intervalo1 = linha.slice(0, 1);

          // 2º Intervalo: Início 2 e Fim 26
          const intervalo2 = linha.slice(1, 26);

          // 3º Intervalo: Início 27 e Fim 56
          const intervalo3 = linha.slice(26, 56);

          // 4º Intervalo: Início 57 e Fim 66
          const intervalo4 = linha.slice(56, 66);

          // 5º Intervalo: Início 67 e Fim 86
          const intervalo5 = linha.slice(66, 86);

          try {
            const response = await axios.post(apiUrl, { linha });
            console.log(response.data); // Fazer algo com a resposta do servidor
          } catch (error) {
            console.error(error);
          }
        }
      };

      fileReader.readAsText(arquivo);
    }
  };

  return (
    <div className='home-container'>
      <h1>Export Arquivo</h1>

      <form className='home-form' onSubmit={handleSubmit}>
        <label htmlFor="dados">Selecione um arquivo:</label>
        <input type="file" name="dados" id="dados" onChange={handleFileChange} /><br />

        <button type="submit" className='btn-register'>Carregar</button> <br />
      </form>

      <GridCard />
    </div>
  );
}
