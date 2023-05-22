import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import CryptoJS from 'crypto-js';
import axios from 'axios';
import config from '../../appsettings.json'

import './login.scss';

export default function Login() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  async function handleLogin(e: any) {
    e.preventDefault();
    axios.get(apiUrl + '/Collaborator/' + email)
      .then(response => {
        const decrypted = CryptoJS.AES.decrypt(response.data.password, password).toString(CryptoJS.enc.Utf8);
        if (decrypted === 'coodesh') {
          const userData = {
            email: email,
            senha: response.data.password
          }
          localStorage.setItem("@detailUser", JSON.stringify(userData))
          navigate('/home', { replace: true })
        } else {
          alert("Usuario Incorreto!")
        }
      })
      .catch(error => {
        alert(error);
      });
  }

  return (
    <div className="container-login" onSubmit={handleLogin}>
      <h1>Coodesh Test</h1>
      <span>Aplicação para exportação e parsing de arquivo</span>

      <form className='form-login'>
        <input type="email" placeholder='Digite seu email...' name="email" id="email" value={email} onChange={e => setEmail(e.target.value)} />
        <input type="password" placeholder='*****' name="password" id="password" value={password} onChange={e => setPassword(e.target.value)} />
        <button type="submit">Acessar</button>
      </form>

      <Link className='button-link' to={'/register'}>
        Não possui uma conta ? Cadastra-se!
      </Link>
    </div>
  );
}