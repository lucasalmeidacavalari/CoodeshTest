import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
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
    axios.get(apiUrl + '/Collaborator?Email=' + email + '&Password=' + password)
      .then(response => {
        if (response.data[0]) {
          navigate('/home', { replace: true })
        }else{
          alert("Usuario Incorreto!")
        }
      })
      .catch(error => {
        alert(error);
      });
  }

  return (
    <div className="container-home" onSubmit={handleLogin}>
      <h1>Coodesh Test</h1>
      <span>Aplicação para exportação e parsing de arquivo</span>

      <form className='form-home'>
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