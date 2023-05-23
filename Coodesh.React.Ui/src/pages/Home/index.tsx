import { useEffect, useState } from 'react';
import './home.scss';
import GridCard from '../../components/GridCard';
import config from '../../appsettings.json';
import { processFileContent } from '../../util/fileUtil';
import GridFileFormat from '../../components/GridFileFormat';
import { useNavigate } from 'react-router-dom';
import Snackbar from '../../components/SnackBar';

export default function Home() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const navigate = useNavigate();
  const [arquivo, setArquivo] = useState<null>(null);
  const [enviado, setEnviado] = useState(false);
  const [recarregarPagina, setRecarregarPagina] = useState(false);
  const [errorMessage, setErrorMessage] = useState<string>('');
  const [showSnackbar, setShowSnackbar] = useState(false);

  const handleFileChange = (event: any) => {
    const selectedFile = event.target.files[0];
    setArquivo(selectedFile);
  };

  const handleSubmit = async (event: any) => {
    setShowSnackbar(false);
    event.preventDefault();

    if (arquivo && !enviado) {
      setEnviado(true);

      const fileReader = new FileReader();

      fileReader.onload = async (e: any) => {
        const content = e.target.result;
        const errorText = await processFileContent(content, apiUrl) ?? '';
        if (errorText) {
          setErrorMessage(errorText);
          setShowSnackbar(true);
        }
        setEnviado(false);
      };

      fileReader.readAsText(arquivo);
      setTimeout(() => {
        setRecarregarPagina(true);
      }, 4000);
    }
  };

  const handleLogout = async () => {
    localStorage.removeItem("@detailUser");
    navigate('/', { replace: true })
  }

  useEffect(() => {
    if (recarregarPagina) {
      window.location.reload();
    }
  }, [recarregarPagina]);

  return (
    <div className='home-container'>
      <h1>Export Arquivo</h1>

      <form className='home-form' onSubmit={handleSubmit}>
        <label htmlFor="dados">Selecione um arquivo:</label>
        <input type="file" name="dados" id="dados" onChange={handleFileChange} /><br />

        <GridFileFormat />

        <button type="submit" className='btn-register' disabled={enviado}>
          {enviado ? 'Enviando...' : 'Carregar'}
        </button> <br />
      </form>

      <GridCard />

      <button className='btn-logout' onClick={handleLogout}>Sair</button>

      {showSnackbar && (
        <Snackbar message={errorMessage} duration={3000} />
      )}
    </div>
  );
}
