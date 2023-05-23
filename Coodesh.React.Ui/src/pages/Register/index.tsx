import './register.scss';
import { useState } from 'react';
import CryptoJS from 'crypto-js';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import config from '../../appsettings.json'
import Snackbar from '../../components/SnackBar';

export default function Register() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showSnackbar, setShowSnackbar] = useState(false); 

  async function handleRegister(e: any) {
    setShowSnackbar(false);
    e.preventDefault();
    const passwordCrypto = CryptoJS.AES.encrypt('coodesh', password).toString();
    axios.post(apiUrl + '/Collaborator', { Email: email, Password: passwordCrypto })
      .then(response => {
        navigate('/home', { replace: true })
        const userData = {
          email: email,
          senha: passwordCrypto
        }
        localStorage.setItem("@detailUser", JSON.stringify(userData))
      })
      .catch(error => {
        setShowSnackbar(true);
      });
  }

  return (
    <div className="container-login" onSubmit={handleRegister}>
      <h1>Coodesh Test</h1>
      <span>Crie uma nova conta!</span>

      <form className='form-login'>
        <input type="email" placeholder='Digite seu email...' name="email" id="email" value={email} onChange={e => setEmail(e.target.value)} />
        <input type="password" placeholder='*****' name="password" id="password" value={password} onChange={e => setPassword(e.target.value)} />
        <button type="submit">Registrar</button>
      </form>

      <Link className='button-link' to={'/'}>
        Já possui uma conta? Faça login!
      </Link>

      {showSnackbar && (
        <Snackbar message="Existem dados inválidos ou o e-mail já está cadastrado!" duration={3000} />
      )}
    </div>
  );
}
