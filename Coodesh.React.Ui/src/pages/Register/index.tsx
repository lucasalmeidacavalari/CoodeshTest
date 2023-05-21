import './register.scss';
import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import config from '../../appsettings.json'

export default function Register() {
  const apiUrl = config.ConfigSettings.DEFAULT;
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  async function handleRegister(e: any) {
    e.preventDefault();
    axios.post(apiUrl + '/Collaborator', { Email: email, Password: password })
      .then(response => {
        navigate('/home', { replace: true })
      })
      .catch(error => {
        console.log(error)
        alert("A dados inexistente ou E-mail já cadastrado!");
      });
  }

  return (
    <div className="container-home" onSubmit={handleRegister}>
      <h1>Coodesh Test</h1>
      <span>Crie uma nova conta!</span>

      <form className='form-home'>
        <input type="email" placeholder='Digite seu email...' name="email" id="email" value={email} onChange={e => setEmail(e.target.value)} />
        <input type="password" placeholder='*****' name="password" id="password" value={password} onChange={e => setPassword(e.target.value)} />
        <button type="submit">Registrar</button>
      </form>

      <Link className='button-link' to={'/'}>
        Já possui uma conta? Faça login!
      </Link>
    </div>
  );
}